using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WindController : PlayerBehaviour
{
    public float sensitivity = 10, cutoff = 2;
    GameObject ball;
    float elapsed;

    public static float GetAzimuth(Vector3 v)
    {
        var deg = Vector3.Angle(Vector3.right, v);
        if (v.y < 0)
            return 360 - deg;
        else
            return deg;
    }

    void AddAzimuth(float deg)
    {
        CmdAddAzimuth(deg);
    }

    void SetAzimuth(float deg)
    {
        CmdAddAzimuth(deg - GetAzimuth(transform.position));
    }

    [Command]
    void CmdAddAzimuth(float deg)
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, deg);
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

#if UNITY_STANDALONE
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        

        var a = GetAzimuth(transform.position);
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

        Debug.Log("a = " + GetAzimuth(transform.position) + ", da = " + da);

        AddAzimuth(da);

#else
        if (Input.touchCount > 0)
        {
            var v2 = Input.GetTouch(0);
            SetAzimuth(GetAzimuth(new Vector3 { v2.x, v2.y, 0 }));
        }
#endif

        elapsed += Time.deltaTime;

        if (GameObject.FindWithTag("balanceBall").transform.position.sqrMagnitude > 16)
        {
            LevelDone(0, 10);
        }

        if (elapsed > 10)
        {
            LevelDone(0, 0);
        }
    }
}
