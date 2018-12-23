using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowCurrentScore : PlayerBehaviour {

 
    // Use this for initialization
    void Start () {

        //if (isLocalPlayer)
            //return;

        //Text currentScore = GameObject.Find("score").GetComponentInChildren<Text>();

        //currentScore.text = (Persist.goodScores[0] + Persist.evilScores[0]).ToString();

       // print(Persist.goodScores[0]);


        GameObject[] scores = GameObject.FindGameObjectsWithTag("score");

        int i = 0;
        foreach (GameObject s in scores)
        {
            s.GetComponent<Text>().text = (Persist.goodScores[i] + Persist.evilScores[i]).ToString();
            i++;
        }
        print(Persist.goodScores[0] + Persist.evilScores[0]);
        print(Persist.goodScores[1] + Persist.evilScores[1]);
        print(Persist.goodScores[2] + Persist.evilScores[2]);
        print(Persist.goodScores[3] + Persist.evilScores[3]);

    }
	
	// Update is called once per frame
	void Update () {
 
    }

}
