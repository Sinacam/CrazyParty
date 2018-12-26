using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowReslut : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {

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

        var names = new string[] { "elf_head", "girl_head", "man_head", "krampus_head" };


        int maxTotal = 0, maxTotali = 0;
        for (int i = 0; i < 4; i++)
        {
            var sum = Persist.evilScores[i] + Persist.goodScores[i];
            if (maxTotal < sum)
            {
                maxTotal = sum;
                maxTotali = i;
            }
        }

        int maxEvil = 0, maxEvili = 0;
        for (int i = 0; i < 4; i++)
        {
            var sum = Persist.evilScores[i] + Persist.goodScores[i];
            if (maxEvil < sum)
            {
                maxEvil = sum;
                maxEvili = i;
            }
        }

        var w = GameObject.Find("winner");
        var wp = w.transform.position;
        wp.y = GameObject.Find(names[maxTotali]).transform.position.y;
        w.transform.position = wp;

        var e = GameObject.Find("evilking");
        var ep = e.transform.position;
        ep.y = GameObject.Find(names[maxEvili]).transform.position.y;
        e.transform.position = ep;

        GameObject.Find("self").transform.position = GameObject.Find(names[Persist.GetLobby().playerId]).transform.position;

        Debug.Log(Persist.GetLobby().playerId);

        for (int i = 0; i < 4; i++)
        {
            var gs = GameObject.Find(names[i]).transform.Find("goodscore").gameObject;
            var es = gs.transform.Find("badscore").gameObject;
            var gsrf = (RectTransform)gs.GetComponent(typeof(RectTransform));
            var esrf = (RectTransform)es.GetComponent(typeof(RectTransform));

            gsrf.sizeDelta = new Vector2(1f * Persist.goodScores[i] / maxTotal * 350, 70);
            esrf.sizeDelta = new Vector2(1f * Persist.evilScores[i] / maxTotal * 350, 70);

            Debug.Log("goodScores = " + Persist.goodScores[i]);
            Debug.Log("evilScores = " + Persist.evilScores[i]);
        }
    }
    public void StartShowGui()
    {
        Persist.instance.StartShowGui();
    }
}
