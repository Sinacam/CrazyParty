using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Persist : NetworkBehaviour
{
    void Start()
    {
        _net = (NetworkController)gameObject.GetComponent(typeof(NetworkController));
        _sl = (SceneList)gameObject.GetComponent(typeof(SceneList));
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(_lobby == null)
        {
            var l = Resources.FindObjectsOfTypeAll<Lobby>()[0];
            l.gameObject.SetActive(true);
            _lobby = l;
        }
    }

    Lobby _lobby;

    NetworkController _net;
    SceneList _sl;

    static public Persist instance;

    static public SyncListInt goodScores
    {
        get { return instance._lobby.goodScores; }
        set { instance._lobby.goodScores = value; }
    }

    static public SyncListInt evilScores
    {
        get { return instance._lobby.evilScores; }
        set { instance._lobby.evilScores = value; }
    }

    static public NetworkController net
    {
        get { return instance._net; }
    }

    static public List<LevelScene> levelScenes
    {
        get { return instance._sl.levelScenes; }
    }

    static public Dictionary<string, int> sceneId
    {
        get { return instance._sl.sceneId; }
    }
}
