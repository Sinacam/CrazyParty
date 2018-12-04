using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PullBehaviour : PlayerBehaviour
{
    float dir
    {
        get { return role % 2 == 0 ? 1 : -1; }
    }

    override public void Init()
    {
        transform.position += new Vector3(dir * 7, 0, 0);
    }

    float elapsed;

    void Update()
    {
        if (!isLocalPlayer)
            return;

        elapsed += Time.deltaTime;

        if (elapsed > 10)
            LevelDone();
    }

    void OnMouseDown()
    {
        if (!isLocalPlayer)
            return;

        Cmdmove();
    }

    [Command]
    void Cmdmove()
    {
        GameObject.Find("rope").transform.position += new Vector3(dir, 0, 0);
    }

}
