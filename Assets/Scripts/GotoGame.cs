using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GotoGame : NetworkBehaviour
{

    public void gotoGame()
    {
        if (!isServer)
            return;

        Persist.net.ServerChangeScene("LoadingNext");
    }
	
}
