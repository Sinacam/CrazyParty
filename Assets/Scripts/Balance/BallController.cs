using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : PlayerBehaviour
{
    public float sensitivity = 10f;
    public float windStrength = 10f;

    Rigidbody rb;
    float elapsed;

    bool useGyro;

    void Start()
    {
        rb = (Rigidbody)gameObject.GetComponent(typeof(Rigidbody));
        useGyro = Input.gyro.enabled;
    }
    
    void Update()
    {
        if (!isLocalPlayer)
            return;

        float x = 0, y = 0;

#if UNITY_ANDROID
        Vector3 gravity;
        if (useGyro)
            gravity = Input.gyro.gravity.normalized;
        else
            gravity = Input.acceleration.normalized;

        x += gravity.x * sensitivity;
        y += gravity.y * sensitivity;
#else
        x += Input.GetAxis("Horizontal") * sensitivity;
        y += Input.GetAxis("Vertical") * sensitivity;
#endif


        var winds = GameObject.FindGameObjectsWithTag("wind");
        foreach (var w in winds)
        {
            var a = WindController.GetAzimuth(w.transform.position) * Mathf.Deg2Rad;
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
            LevelDone(1, 0);
        }
    }
}
