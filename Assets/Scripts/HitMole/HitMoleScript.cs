using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitMoleScript : PlayerBehaviour
{

    public GameObject Mole;
    public NetworkIdentity[] networkIdentity;


    public Vector2[] holePosition;
    public bool[] holeOccupied;
    public GameObject[] moleList;
    public Collider2D coll;

    public static int numOfHole;

    // Use this for initialization
    void Start()
    {
        int i;
        numOfHole = holePosition.Length;

        for (i = 0; i < numOfHole; i++)
        {
            holePosition[i] = GameObject.Find("Hole" + (i + 1)).transform.position;
            holeOccupied[i] = false;
        }
        GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        if (!isServer)
            return;

        if (Random.Range(0, 100) <= 10)
            CmdSpawnMole();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;

        int i;
        RaycastHit2D hit;

        for (i = 0; i < numOfHole; i++)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(holePosition[i])), Vector2.zero);
            //Debug.Log(hit.collider);

            if (hit.collider == null)
            {
                holeOccupied[i] = false;
            }
        }
    }

    [Command]
    void CmdSpawnMole()
    {
        int i = Random.Range(0, numOfHole);

        if (holeOccupied[i] == false)
        {
            moleList[i] = Instantiate(Mole, holePosition[i], Quaternion.identity);
            NetworkServer.Spawn(moleList[i]);
            holeOccupied[i] = true;
        }
    }
}
