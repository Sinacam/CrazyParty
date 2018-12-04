using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShakeCola : PlayerBehaviour
{
    private GameObject colaColor;
    private Vector2 yposition = new Vector2(0, 0);
    public bool playerFinish = false; //玩家是否要結束
                                      // Use this for initialization
    void Start()
    {
        colaColor = GameObject.Find("ColaColor");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        { //只有本機玩家可以操控
            return;
        }

        if (Input.GetMouseButton(0)) //滑鼠左鍵
        {
            CmdShakeCola();
        }

        if (playerFinish)
        { //如果玩家已經結束遊戲
            Debug.Log("leveldone");
            LevelDone();
        }
    }

    public void getEnd()
    { //Endline如果偵測到可樂已經搖滿房間，會呼叫這個function，設定該玩家已可結束遊戲
        //print("get end!");
        playerFinish = true;
    }

    [Command] //執行shake cola動作（要從client傳到server)
    void CmdShakeCola()
    {
        colaColor.transform.Translate(yposition + new Vector2(0, 10));
    }
}
