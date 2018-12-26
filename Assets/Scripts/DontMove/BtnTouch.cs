using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BtnTouch : MonoBehaviour{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   

   
 public void Onclick() { 
        if (DontMoveCtrl.isRedBgm){
            Debug.Log("已被破壞!");
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
