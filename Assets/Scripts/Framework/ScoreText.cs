using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    bool rendered = false;
	void Update ()
    {
        if (rendered)
            return;

        GameObject.Find("man_head").GetComponentInChildren<Text>().text = Persist.goodScores[0].ToString();
        GameObject.Find("elf_head").GetComponentInChildren<Text>().text = Persist.goodScores[1].ToString();
        GameObject.Find("girl_head").GetComponentInChildren<Text>().text = Persist.goodScores[2].ToString();
        GameObject.Find("krampus_head").GetComponentInChildren<Text>().text = Persist.goodScores[3].ToString();

        rendered = true;
    }
}
