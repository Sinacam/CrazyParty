using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour {
    [SerializeField] AudioSource bgm;
	// Use this for initialization
	void Start () {
        bgm.volume = MainMenuManager.soundVolume;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
