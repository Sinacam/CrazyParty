using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBehaviour : PlayerBehaviour{
    Text countNum;
    int count = 10;
    int clickTime; //看玩家何時按的秒數
    bool playerClick = false; //看玩家是否按了

    public List<int> clickTimeList; //儲存每個玩家的點擊時間
    public bool playerFinish = false; //玩家是否要結束

    // Use this for initialization
    void Start() {
        countNum = GameObject.Find("CountNum").GetComponent<Text>();
        clickTimeList = new List<int>();
        InvokeRepeating("CountDown", 2, 1);
        Debug.Log(count);

        //Invoke("getEnd", 12f); //15秒到會自動結束

        //clickTimeList.Add(22);
        //clickTimeList.Add(3);
        //clickTimeList.Add(4);
        //clickTimeList.Add(55);

        //int minNum = clickTimeList[0];
        //int winRole = 0;
        //for (int i = 1; i < clickTimeList.Count; i++)
        //{
        //    if(minNum > clickTimeList[i])
        //    {
        //        minNum = clickTimeList[i];
        //        winRole = i;
        //    }
        //}
        //print(minNum);
        //print(winRole);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        { //只有本機玩家可以操控
            return;
        }

        if (playerFinish) //如果玩家已經結束遊戲
        {
            Debug.Log("遊戲結束！");

            if (clickTimeList.Count.Equals(0)) //完全沒玩家按按鈕
            {
                LevelDone(0, 0); //全部0分
            }
            else
            {
                Debug.Log("排序");
                //排序，得到最小秒數(最接近0的玩家）
                int minNum = clickTimeList[0];
                int winRole = 0;
                for (int i = 1; i < clickTimeList.Count; i++)
                {
                    if (minNum > clickTimeList[i])
                    {
                        minNum = clickTimeList[i];
                        winRole = i;
                    }
                }

                if (role == winRole) //如果是獲勝玩家，就得分
                {
                    LevelDone(1, 0);
                }
                else //其餘沒分
                {
                    LevelDone(0, 0);
                }
            }
        }
	}

    public void Click()
    {
        //Debug.Log("click");
        if(playerClick == false) //如果玩家還沒按過按鈕
        {
            clickTime = count; //紀錄玩家按下秒數
            Debug.Log("player click time:" + clickTime + "\n");
            playerClick = true;
            //存放到list中，以玩家各自編號為儲存空間
            clickTimeList[role] = clickTime;
            playerFinish = true;
        }
    }

    void CountDown() //倒數計時
    {
        count--;
        countNum.text = count.ToString();
        Debug.Log(count);
        if (count == 0)
        {
            CancelInvoke("CountDown"); //停止倒數
            Debug.Log("Game Over");
            playerFinish = true;
        }
    }

    //public void getEnd()
    //{ //10秒到，設定該玩家已可結束遊戲
    //    playerFinish = true;
    //}
}
