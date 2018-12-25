using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Room : NetworkBehaviour {

    public GameObject man, girl, elf, krampus;

    GameObject m, g, e, k;
    // Use this for initialization
    void Start ()
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
    }

    // Update is called once per frame
    void Update ()
    {
        
        if (isServer)
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
    private void OnDestroy()
    {
        var mm = GameObject.Find("MyMatchMaker");
        //Debug.Log(mm);
        //Destroy(mm);
    }
}
