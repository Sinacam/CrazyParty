using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HitMoleController : PlayerBehaviour {
    public GameObject Mole;

    public static int numOfHole = 2;

    public Vector2[] holePosition = new Vector2[numOfHole];
    public bool[] holeOccupied = new bool[numOfHole];
    // Use this for initialization
    void Start () {
		
	}

    float Timer = 0;
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            if (isLocalPlayer){

                Debug.Log(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name == "Mole(Clone)");
                    if (hit.collider.gameObject.name == "Mole(Clone)")
                    {
                        CmdDestroyMole(hit.collider.gameObject);
                    }
                }
            }
        }

        Timer += Time.deltaTime;

        if(Timer > 10)
        {
            LevelDone();
        }
    }

    [Command]
    void CmdDestroyMole(GameObject go)
    {
        NetworkServer.Destroy(go);
    }
}
