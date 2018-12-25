using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager : MonoBehaviour {
    public string[] playerNames;//玩家名稱
    public int[] playerScore;//玩家分數
	// Use this for initialization
	void Start () {
        for(int i =0;i<playerNames.Length;i++)//在LevelTemplate.unity初始化
        {
            if (playerNames[i] == "")
            {
                PlayerPrefs.SetInt(("playerScore" + (i + 1).ToString()),0);
            }
            else
            {
                PlayerPrefs.SetInt(playerNames[i], 0);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
