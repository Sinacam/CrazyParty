using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // 螢幕翻轉為 正向, 話筒在上, 且不能翻轉
        Screen.orientation = ScreenOrientation.Portrait;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reorientate() //重新調整orientation
    {
        // 可自由翻轉, 但可以設定方向的限制
        Screen.orientation = ScreenOrientation.AutoRotation;

        // 設定是否可以 向左倒
        Screen.autorotateToLandscapeLeft = true;

        // 設定是否可以 向右倒
        Screen.autorotateToLandscapeRight = true;

        // 設定是否可以 正向
        Screen.autorotateToPortrait = false;

        // 設定是否可以 倒向
        Screen.autorotateToPortraitUpsideDown = false;
    }
}
