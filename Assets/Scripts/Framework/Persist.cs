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

    NetworkController _net;
    SceneList _sl;

    static Lobby GetLobby()
    {
        return (Lobby)GameObject.Find("LobbyManager").GetComponent(typeof(Lobby));
    }

    static Persist instance;

    static public SyncListInt goodScores
    {
        get { return GetLobby().goodScores; }
    }

    static public SyncListInt evilScores
    {
        get { return GetLobby().evilScores; }
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
