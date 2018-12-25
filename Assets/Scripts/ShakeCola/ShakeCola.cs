using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShakeCola : PlayerBehaviour
{
    private GameObject colaColor; //不同Group有不同cola
    //private GameObject colaColor2;
    private Vector2 yposition = new Vector2(0, 0);
    private int group = 0; //group no.
    private int countShake = 0; //計算每個玩家shake幾次
    private int[] groupScore; //計算各個group的score

    public bool playerFinish = false; //玩家是否要結束

    // Use this for initialization
    void Start()
    {
        colaColor = GameObject.Find("ColaColor");
        groupScore = new int[2];

        //分隊
        if (isLocalPlayer)
        {
            print("role:" + role);
            group = role % 2; //group為0或1
            print("group:" + group);
        }

        Invoke("getEnd", 10f); //10秒到會自動結束
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        { //只有本機玩家可以操控
            return;
        }

        //if (Input.GetMouseButton(0)) //滑鼠左鍵(手機點擊）
        //{
        //    CmdShakeCola();
        //}

        if (playerFinish)
        { //如果玩家已經結束遊戲
            //判斷哪個group贏了
            if((groupScore[0] > groupScore[1]) && (group == 0))
            {
                LevelDone(1, 0);
            }
            //Debug.Log("leveldone");
            else if((groupScore[0] < groupScore[1]) && (group == 1))
            {
                LevelDone(1, 0);
            }
            else
            {
                LevelDone(0, 0);
            }

            //遊戲結束，調整手機顯示方式
            GameObject.Find("Main Camera").GetComponent<Orientation>().reorientate();
        }
    }

    public void getEnd()
    { //Endline如果偵測到可樂已經搖滿房間，會呼叫這個function，設定該玩家已可結束遊戲
        playerFinish = true;
    }

    [Command] //執行shake cola動作（要從client傳到server)
    public void CmdShakeCola()
    {
        GetComponent<AudioSource>().Play(); //播放音效
        countShake += 1;
        print("countShake:" + countShake);
        groupScore[group] += countShake;
        colaColor.transform.Translate(yposition + new Vector2(0, 20));
    }
}
