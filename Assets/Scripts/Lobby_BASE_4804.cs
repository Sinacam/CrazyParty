using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetTouch(0).phase == TouchPhase.Began) && Persist.net.IsClientConnected())
            Persist.net.ServerChangeScene("LoadingNext");
    }
}
