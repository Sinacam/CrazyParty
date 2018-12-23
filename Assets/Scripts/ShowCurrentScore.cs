using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ShowCurrentScore : PlayerBehaviour {

 
    // Use this for initialization
    void Start () {

        if (isLocalPlayer)
            return;

        Text currentScore = gameObject.GetComponentInChildren<Text>();
        //currentScore.text = "123";
        currentScore.text = (goodScore + evilScore).ToString();

        print(goodScore);
    }
	
	// Update is called once per frame
	void Update () {
 
    }

}
