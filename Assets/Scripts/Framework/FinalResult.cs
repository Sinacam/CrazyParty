using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FinalResult : NetworkBehaviour {
	
	void Start () {
        Debug.Log(playerControllerId);
        //ClientScene.RemovePlayer()
	}
	
	void Update () {
        /*
		if (Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("Lobby");
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			SceneManager.LoadScene("Lobby");
		}*/
	}
}
