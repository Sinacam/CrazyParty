using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Lobby : NetworkBehaviour
{
    public SyncListInt goodScores = new SyncListInt(), evilScores = new SyncListInt();
    public int playerId;
    public GameObject panel, players;

    public GameObject man, girl, elf, krampus;

    GameObject m, g, e, k;
    bool inGame = false;
    // Use this for initialization
    void Start()
    {/*
        man.SetActive(false);
        girl.SetActive(false);
        elf.SetActive(false);
        krampus.SetActive(false);
        ClientScene.RegisterPrefab(man);
        ClientScene.RegisterPrefab(girl);
        ClientScene.RegisterPrefab(elf);
        ClientScene.RegisterPrefab(krampus);*/
        m = null;
        g = null;
        e = null;
        k = null;
        inGame = false;
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (isServer && !inGame)
        {

            //Debug.Log("count " + Persist.net.clientCount);
            switch (Persist.net.clientCount)
            {
                case 1:
                    //Debug.Log("case1");
                    if (m == null)
                    {
                        m = Instantiate(man);
                        NetworkServer.Spawn(m);
                    }
                    if (g != null)
                        NetworkServer.Destroy(g);
                    if (e != null)
                        NetworkServer.Destroy(e);
                    if (k != null)
                        NetworkServer.Destroy(k);
                    break;
                case 2:
                    if (m == null)
                    {
                        m = Instantiate(man);
                        NetworkServer.Spawn(m);
                    }
                    if (g == null)
                    {
                        g = Instantiate(girl);
                        NetworkServer.Spawn(g);
                    }
                    if (e != null)
                        NetworkServer.Destroy(e);
                    if (k != null)
                        NetworkServer.Destroy(k);
                    break;
                case 3:
                    if (m == null)
                    {
                        m = Instantiate(man);
                        NetworkServer.Spawn(m);
                    }
                    if (g == null)
                    {
                        g = Instantiate(girl);
                        NetworkServer.Spawn(g);
                    }
                    if (e == null)
                    {
                        e = Instantiate(elf);
                        NetworkServer.Spawn(e);
                    }
                    if (k != null)
                        NetworkServer.Destroy(k);
                    break;
                case 4:
                    if (m == null)
                    {
                        m = Instantiate(man);
                        NetworkServer.Spawn(m);
                    }
                    if (g == null)
                    {
                        g = Instantiate(girl);
                        NetworkServer.Spawn(g);
                    }
                    //Debug.Log("case4");
                    if (e == null)
                    {
                        e = Instantiate(elf);
                        NetworkServer.Spawn(e);
                    }
                    if (k == null)
                    {
                        k = Instantiate(krampus);
                        NetworkServer.Spawn(k);
                    }
                    break;
                default:
                    //Debug.Log("case5");
                    break;

            }
        }
    }


    public void GotoLoadNext()
    {
        if (!isServer)
            return;

        if (m != null)
            NetworkServer.Destroy(m);
        if (g != null)
            NetworkServer.Destroy(g);
        if (e != null)
            NetworkServer.Destroy(e);
        if (k != null)
            NetworkServer.Destroy(k);
        inGame = true;

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
