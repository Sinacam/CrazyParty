using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReslut : PlayerBehaviour {

    public RectTransform r;
    // Use this for initialization
    void Awake () {

        //good
        /* 有加InChildren但會改到find的咚咚 QQ
         * 這個就正常 不會改到elf
        r = GameObject.Find("man_head").GetComponentInChildren<RectTransform>();
        r.sizeDelta = new Vector2(Persist.goodScores[0] * 8, 70);
        r = GameObject.Find("elf_head").GetComponentInChildren<RectTransform>();
        r.sizeDelta = new Vector2(Persist.goodScores[1] * 8, 70);
        r = GameObject.Find("girl_head").GetComponentInChildren<RectTransform>();
        r.sizeDelta = new Vector2(Persist.goodScores[2] * 8, 70);
        r = GameObject.Find("krampus_head").GetComponentInChildren<RectTransform>();
        r.sizeDelta = new Vector2(Persist.goodScores[3] * 8, 70);
        */
        //這裡有個小bug，man的會跑到elf去顯示QQ
        GameObject[] scores = GameObject.FindGameObjectsWithTag("score");

        int i = 0;
        foreach (GameObject s in scores)
        {
            s.GetComponent<RectTransform>().sizeDelta = new Vector2(Persist.goodScores[i] * 8, 70);
            i++;
        }

        print(Persist.goodScores[0]);
        print(Persist.goodScores[1]);
        print(Persist.goodScores[2]);
        print(Persist.goodScores[3]);

        
        //evil
        GameObject[] badscores = GameObject.FindGameObjectsWithTag("badscore");

        int j = 0;
        foreach (GameObject b in badscores)
        {
            b.GetComponent<RectTransform>().sizeDelta = new Vector2(Persist.evilScores[j] * 8, 70);
            //b.GetComponent<RectTransform>().sizeDelta = new Vector2(1 * 8, 70);
            j++;
        }
        
        print(Persist.evilScores[0]);
        print(Persist.evilScores[1]);
        print(Persist.evilScores[2]);
        print(Persist.evilScores[3]);
        

    }
	
}
