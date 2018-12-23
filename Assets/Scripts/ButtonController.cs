using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void GotoLoadNext()
    {
        var l = (Lobby)GameObject.Find("LobbyController").GetComponent(typeof(Lobby));
        l.GotoLoadNext();
    }
}
