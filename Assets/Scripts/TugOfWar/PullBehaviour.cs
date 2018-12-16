using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Audio;

public class PullBehaviour : PlayerBehaviour
{

   

    float dir
    {
        get { return role % 2 == 0 ? 1 : -1; }
    }

    override public void Init()
    {
        transform.position += new Vector3(dir * 7, 0, 0);
    }

    float elapsed;

    void Update()
    {
        if (!isLocalPlayer)
            return;

        elapsed += Time.deltaTime;

        if (elapsed > 10 )
        {
            float pos = GameObject.Find("bow1").transform.position.x;

            if (pos < 0 && dir < 0)
            {
                print("left team win!");
                LevelDone(1, 0);
                print(goodScore);
            }
            else if (pos > 0 && dir >0)
            {
                print("right team win!");
                //right member ++ goodscore
                //evilScore = 1;
                LevelDone(1, 0);
                print(goodScore);
            }
            else
            {
                print("player lose");
                LevelDone(0,0);
                print(goodScore);
                print(evilScore);
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelDone(1, 0);
        }
    }

    void OnMouseDown()
    {
        if (!isLocalPlayer)
            return;

        GetComponent<AudioSource>().Play();
        Cmdmove();
        
    }


    [Command]
    void Cmdmove()
    {
        GameObject.Find("rope").transform.position += new Vector3(dir/4, 0, 0);
    }



}
