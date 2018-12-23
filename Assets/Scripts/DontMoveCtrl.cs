using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DontMoveCtrl : PlayerBehaviour
{
    float duration = 0.0f;
    float redStart = 0.0f;//redBgm 出現的時間點
    float redTimeSet = 0.0f;//redBgm 的持續時間
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] Sprite redBgm;
    [SerializeField] Sprite yellowBgm;
    [SerializeField] GameObject[] btns;
    [SerializeField] int SetbtnCounts = 10;//設定按鈕出現數量限制
    [HideInInspector]public static int  touchCountsInYellow = 0;//黃色BGM時按的次數(加分用)
    [HideInInspector] public static int  touchCountsInRed = 0;//紅色BGM時按的次數(扣分用)
    int btnCounts = 0;//紀錄畫面中出現的按鈕
    [HideInInspector] public static bool isRedBgm;
    void Start()
    {
        Input.multiTouchEnabled = true;
        redTimeSet = Random.Range(2.0f, 4.0f); //for 2-4s
        redStart =Random.Range(1.0f, 4.0f);  
        backGround.sprite = yellowBgm;
        isRedBgm = false;

    }
   
    void Update()
    {
        if (!isLocalPlayer)
            return;
        duration += Time.deltaTime;
        if (duration > 8)
        {
            if ((touchCountsInYellow -touchCountsInRed)>0)
            {
                print("Player win!");
                LevelDone(1, 0);
                print(goodScore);
            }
            else if ((touchCountsInYellow - touchCountsInRed) < 0)
            {
                print("Player lose!!");
                LevelDone(0, 1);
                print(evilScore);
            }
            else
            {
                print("tie!!");
                LevelDone(0, 0);
                print(goodScore);
                print(evilScore);
            }

        }
        if (redStart < duration)
        {
            if (btnCounts < SetbtnCounts)
            {
                backGround.sprite = redBgm;
                isRedBgm = true;
                float btnPositionX = Random.Range(0.0f, (float)Screen.width);//隨機產生點
                float btnPositionY = Random.Range(0.0f, (float)Screen.height);//隨機產生點
                float movePostionX = Random.Range(0.0f, (float)Screen.width);//按鈕移動方向
                float movePositionY = Random.Range(0.0f, (float)Screen.height);//按鈕移動方向
                GameObject btn = Instantiate(btns[Random.Range(0, 5)], new Vector3(btnPositionX, btnPositionY), Quaternion.identity);
                btn.GetComponent<Transform>().position += new Vector3(movePostionX, movePositionY);
                btnCounts++;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelDone(1, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 0.5f);
        btnCounts--;
    }
}
