using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WindController : PlayerBehaviour
{
    public float sensitivity = 10, cutoff = 2;
    GameObject ball;
    float elapsed;

    public float GetAzimuth()
    {
        var deg = Vector3.Angle(Vector3.right, transform.position);
        if (transform.position.y < 0)
            return 360 - deg;
        else
            return deg;
    }

    void AddAzimuth(float deg)
    {
        CmdAddAzimuth(deg);
    }

    [Command]
    void CmdAddAzimuth(float deg)
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, deg);
    }

    void Start()
    {
        ball = GameObject.Find("BalanceBall");
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var a = GetAzimuth();
        float da = 0;

        // Cutoff to avoid ambiguoous directions.
        if (a < 180 - cutoff && a > cutoff)
            da -= x;
        else if(a > 180 + cutoff && a < 360 - cutoff)
            da += x;

        if (a < 90 - cutoff || a > 270 + cutoff)
            da += y;
        else if(a > 90 + cutoff && a < 270 - cutoff)
            da -= y;

        da = Mathf.Clamp(da, -1f, 1f) * Time.deltaTime * sensitivity;

        Debug.Log("a = " + GetAzimuth() + ", da = " + da);

        AddAzimuth(da);

        elapsed += Time.deltaTime;

        if (ball.transform.position.sqrMagnitude > 16)
        {
            LevelDone(1, 0);
        }

        if(elapsed > 10)
        {
            LevelDone(0, 0);
        }
    }
}
