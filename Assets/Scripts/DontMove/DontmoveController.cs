using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DontmoveController : PlayerBehaviour
{
    int localGoodScore, localBadScore;

    float timer = 0;
    // Use this for initialization
    void Start()
    {

        localGoodScore = 0;
        localBadScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;

        timer += Time.deltaTime;
        if (timer >= 12){
            int finalScore = localGoodScore - localBadScore;
            Debug.Log(localGoodScore + " " + localBadScore);
            LevelDone(finalScore, 0);
        }

        int i;
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.gameObject.tag == "dontmovebutton");
                if (hit.collider.gameObject.tag == "dontmovebutton")
                {
                    if (DontMoveCtrl.isRedBgm){
                        localBadScore++;
                    }
                    else {
                        localGoodScore++;
                    }
                    //GetComponent<AudioSource>().Play();
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }
}
