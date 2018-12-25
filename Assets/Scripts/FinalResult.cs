using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalResult : MonoBehaviour {
	
	void Start () {
		
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			SceneManager.LoadScene("Lobby");
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			SceneManager.LoadScene("Lobby");
		}
	}
}
