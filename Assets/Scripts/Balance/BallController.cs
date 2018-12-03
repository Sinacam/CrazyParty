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
    
    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * sensitivity;
        var y = Input.GetAxis("Vertical") * sensitivity;

        var winds = GameObject.FindGameObjectsWithTag("wind");
        foreach (var w in winds)
        {
            var wc = (WindController)w.GetComponent(typeof(WindController));
            var a = wc.GetAzimuth() * Mathf.Deg2Rad;
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
