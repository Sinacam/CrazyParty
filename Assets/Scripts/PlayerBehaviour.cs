using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehaviour : NetworkBehaviour
{
    [SyncVar]
    public int role = 0;

    bool levelDone = false;

    // Called after GameObject instantiation but before spawning on clients, therefore has no effect on client side.
    virtual public void Init()
    {

    }
    
    public void LevelDone()
    {
        if (!levelDone)
        {
            levelDone = true;
            CmdLevelDone();
        }
    }

    [Command]
    void CmdLevelDone()
    {
        Persist.net.ServerLevelDone();
    }
}
