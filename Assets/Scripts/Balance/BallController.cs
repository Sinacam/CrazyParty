using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : PlayerBehaviour
{
    public float sensitivity = 10f;
    public float windStrength = 10f;
    Rigidbody rb;
    float elapsed;

    void Start()
    {
        rb = (Rigidbody)gameObject.GetComponent(typeof(Rigidbody));
    }

    static Vector3 gravity()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            return Input.gyro.gravity.normalized;
        }
        else
            return Input.acceleration.normalized;
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

#if UNITY_STANDALONE
        var x = Input.GetAxis("Horizontal") * sensitivity;
        var y = Input.GetAxis("Vertical") * sensitivity;
#else
        var grav = gravity();
        var x = grav.x * sensitivity;
        var y = grav.y * sensitivity;
#endif

        var winds = GameObject.FindGameObjectsWithTag("wind");
        foreach (var w in winds)
        {
            var diff = w.transform.position - transform.position;
            var a = WindController.GetAzimuth(diff) * Mathf.Deg2Rad;
            x -= Mathf.Cos(a) * windStrength;
            y -= Mathf.Sin(a) * windStrength;
        }

        rb.AddForce(new Vector3(x * Time.deltaTime, y * Time.deltaTime, 0));

        elapsed += Time.deltaTime;

        if(transform.position.sqrMagnitude > 16)
        {
            LevelDone(0, 0);
        }

        if(elapsed > 10)
        {
            LevelDone(10, 0);
        }
    }
}
