using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowReslut : PlayerBehaviour {

	// Use this for initialization
	void Awake () {

        GameObject[] scores = GameObject.FindGameObjectsWithTag("score");

        int i = 0;
        foreach (GameObject s in scores)
        {
            s.GetComponent<RectTransform>().sizeDelta = new Vector2(Persist.goodScores[i] * 8, 70);
            //s.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(Persist.evilScores[i] * 8, 70);
            i++;
        }
        print(Persist.goodScores[0]);
        print(Persist.goodScores[1]);
        print(Persist.goodScores[2]);
        print(Persist.goodScores[3]);

        
        //evil的都不動~~~
        GameObject[] badscores = GameObject.FindGameObjectsWithTag("badscore");

        int j = 0;
        foreach (GameObject b in badscores)
        {
            b.GetComponent<RectTransform>().sizeDelta = new Vector2(Persist.evilScores[i] * 8, 70);
            j++;
        }
        
        print(Persist.evilScores[0]);
        print(Persist.evilScores[1]);
        print(Persist.evilScores[2]);
        print(Persist.evilScores[3]);
        

    }
	
}
