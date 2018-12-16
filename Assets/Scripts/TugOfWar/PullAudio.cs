using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PullAudio : MonoBehaviour {

    public AudioSource audioData;

    // Use this for initialization
    void Start () {
        //audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            audioData.Play();
        }
		
	}
}
