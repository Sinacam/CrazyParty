using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour
{
    AudioSource winAudio;

    // Use this for initialization
    void Start()
    {
         winAudio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
    }

    //可樂搖滿房間
    void OnTriggerEnter2D(Collider2D collision)
    {
        //播放音效
        winAudio.Play();
        Invoke("callEndLine", 0.5f); //延後一秒讓音效播完
    }

    void callEndLine() //遊戲結束
    {
        // Step one
        ShakeCola[] clones = FindObjectsOfType<ShakeCola>();

        // Step two
        foreach (var shakeCola in clones)
            shakeCola.getEnd();

    }
}
