using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadingNext : NetworkBehaviour
{
    public Text t;
    void Start()
    {
        StartCoroutine(NextLevelIn(1));
        /*
        Debug.Log(Persist.goodScores[0]);
        Debug.Log(Persist.goodScores[1]);
        Debug.Log(Persist.goodScores[2]);
        Debug.Log(Persist.goodScores[3]);*/
        t = GameObject.Find("man_head").GetComponentInChildren<Text>();
        t.text = Persist.goodScores[0].ToString();
        t = GameObject.Find("elf_head").GetComponentInChildren<Text>();
        t.text = Persist.goodScores[1].ToString();
        t = GameObject.Find("girl_head").GetComponentInChildren<Text>();
        t.text = Persist.goodScores[2].ToString();
        t = GameObject.Find("krampus_head").GetComponentInChildren<Text>();
        t.text = Persist.goodScores[3].ToString();

    }

    IEnumerator NextLevelIn(float t)
    {
        yield return new WaitForSeconds(t);
        var s = Persist.levelScenes[new System.Random().Next(0, Persist.levelScenes.Count)];
        Persist.net.ServerChangeScene(s.name);
    }
}
