using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{
    public SyncListInt goodScores = new SyncListInt(), evilScores = new SyncListInt();

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {/*
        if (!isServer)
            return;

        if ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && Persist.net.IsClientConnected())
        {
            Persist.goodScores.Clear();
            Persist.evilScores.Clear();
            for (int i = 0; i < 4; i++)
            {
                Persist.goodScores.Add(0);
                Persist.evilScores.Add(0);
            }

            Persist.net.ServerChangeScene("LoadingNext");
        }*/
    }
    public void GotoLoadNext()
    {
        if (!isServer)
            return;

        Persist.goodScores.Clear();
        Persist.evilScores.Clear();
        for (int i = 0; i < 4; i++)
        {
            Persist.goodScores.Add(0);
            Persist.evilScores.Add(0);
        }

        Persist.net.ServerChangeScene("LoadingNext");
        
    }
}
