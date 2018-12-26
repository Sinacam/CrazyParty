using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{
    public SyncListInt goodScores = new SyncListInt(), evilScores = new SyncListInt();
    public int playerId;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
            GotoLoadNext();*/
    }

    public void GotoLoadNext()
    {
        if (!isServer)
            return;

        goodScores.Clear();
        evilScores.Clear();
        for (int i = 0; i < 4; i++)
        {
            goodScores.Add(0);
            evilScores.Add(0);
        }

        Persist.net.ServerChangeScene("LoadingNext");

    }
}
