using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

    }

    //可樂搖滿房間
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Step one
        ShakeCola[] clones = FindObjectsOfType<ShakeCola>();

        // Step two
        foreach (var shakeCola in clones)
            shakeCola.getEnd();
        //print("success!");

    }
}
