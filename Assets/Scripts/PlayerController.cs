using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : PlayerBehaviour
{
    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

        transform.Translate(x, y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            LevelDone();

        goodScore += 42;
        evilScore -= 42;

        string s = "";
        foreach (var i in Persist.goodScores)
            s += i + " ";

        Debug.Log(s);
    }
}
