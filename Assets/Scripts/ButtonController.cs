using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonController : NetworkBehaviour
{
    public void GotoLoadNext()
    {
        var l = (Lobby)GameObject.Find("LobbyController").GetComponent(typeof(Lobby));
        l.GotoLoadNext();
    }
}
