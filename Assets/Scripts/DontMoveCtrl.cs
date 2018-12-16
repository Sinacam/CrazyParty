using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Audio;
using UnityEngine.UI;

public class DontMoveCtrl : PlayerBehaviour
{
    float playTime =4.0f;
    float duration = 0.0f;
    float redTimeSet = 0.0f;
    [SerializeField] SpriteRenderer backGround;
    [SerializeField] Sprite redBgm;
    [SerializeField] Sprite yellowBgm;
    [SerializeField] GameObject[]btns;
    void Start()
    {
        redTimeSet = Random.Range(0.0f, playTime);
        duration =Random.Range(0.0f, redTimeSet);
        backGround.sprite = yellowBgm;
    }
   
    void Update()
    {
        if (!isLocalPlayer)
            return;

        playTime = playTime-Time.deltaTime;

        if (playTime < redTimeSet)
        {
            backGround.sprite = redBgm;
            float btnPositionX = Random.Range(0.0f, (float)Screen.width);
            float btnPositionY = Random.Range(0.0f, (float)Screen.height);
            float movePostionX = Random.Range(0.0f, (float)Screen.width);
            float movePositionY = Random.Range(0.0f, (float)Screen.height);
            GameObject btn=Instantiate(btns[Random.Range(0, 5) % 4], new Vector3(btnPositionX, btnPositionY),Quaternion.EulerAngles(0,0,0));
            btn.GetComponent<Transform>().position += new Vector3(Random.Range(0.0f, (float)Screen.width), 0.0f, (float)Screen.height);
          
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelDone(1, 0);
        }
    }


}
