using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{
    void Update()
    {
        if (Persist.net.IsClientConnected()) {
			if (Input.GetKeyDown(KeyCode.Space))
				Persist.net.ServerChangeScene("LoadingNext");
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
				Persist.net.ServerChangeScene("LoadingNext");
		}
		
		
    }
}
