﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitMoleController : PlayerBehaviour
{
    public int numOfPlayer;

    public Vector2[] holePosition;
    public bool[] holeOccupied;
    int localGoodScore, localEvilScore;

    // Use this for initialization
    void Start()
    {
        int i;
        localGoodScore = 0;
        localEvilScore = 0;

    }

    float timer = 0;

    void Update()
    {
        int i;
        if (!isLocalPlayer)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                if (hit.collider.gameObject.name == "Mole(Clone)")
                {
                    CmdDestroyMole(hit.collider.gameObject, this.role, this.playerId);
                    localGoodScore++;
                    //Persist.goodScores[this.playerId]++;
                }
            }
        }

        if (Input.touchCount > 0)
        {
            for (i = 0; i < Input.touchCount; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position), Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                    if (hit.collider.gameObject.name == "Mole(Clone)")
                    {
                        CmdDestroyMole(hit.collider.gameObject, this.role, this.playerId);
                        localEvilScore++;
                        //Persist.goodScores[this.playerId]++;
                    }
                }
            }
        }

        timer += Time.deltaTime;

        if (timer > 10)
        {
            LevelDone(localGoodScore, localEvilScore);

            for (i = 0; i < 4; i++)
            {
                Debug.Log(Persist.goodScores[i] + " " + Persist.evilScores[i]);
            }
        }
    }

    [Command]
    void CmdDestroyMole(GameObject go, int thisRole, int thisPlayerId)
    {
        if (go != null)
            NetworkServer.Destroy(go);
    }

}
