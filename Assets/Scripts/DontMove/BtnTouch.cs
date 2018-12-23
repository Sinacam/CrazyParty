using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void btnClick()
    {
        if (DontMoveCtrl.isRedBgm){
            DontMoveCtrl.touchCountsInRed++;
            Destroy(transform.gameObject);
        }
        else
        {
            DontMoveCtrl.touchCountsInYellow++;
            Destroy(transform.gameObject);
        }
        
    }
}
