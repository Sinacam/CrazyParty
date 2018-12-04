using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour
{
    [HideInInspector]
    [SyncVar]
    public int role, playerId;

    bool levelDone = false;

    // Called after GameObject instantiation but before spawning on clients, has no effect on client side.
    virtual public void Init()
    {

    }

    public void LevelDone()
    {
        if(!levelDone)
        {
            levelDone = true;
            CmdLevelDone();
        }
    }
    
    public void LevelDone(int good, int evil)
    {
        if(!levelDone)
        {
            goodScore += good;
            evilScore += evil;
            levelDone = true;
            CmdLevelDone();
        }
    }
    
    public int goodScore
    {
        get { return Persist.goodScores[playerId]; }
        set { CmdGoodScore(value); }
    }

    public int evilScore
    {
        get { return Persist.evilScores[playerId]; }
        set { CmdEvilScore(value); }
    }

    [Command]
    void CmdLevelDone()
    {
        Persist.net.ServerLevelDone();
    }

    [Command]
    void CmdGoodScore(int s)
    {
        Persist.goodScores[playerId] = s;
        Persist.goodScores.Dirty(playerId);
    }

    [Command]
    void CmdEvilScore(int s)
    {
        Persist.evilScores[playerId] = s;
        Persist.evilScores.Dirty(playerId);
    }
}
