﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Used upon loading scene.
// Includes the player prefab, which depends on PlayerController.localPlayer.role.
public class SceneLoader : NetworkBehaviour {

    public GameObject prefab
    {
        get; set;
    }

    void OnStartLocalPlayer()
    {
        PlayerController.localPlayer.CmdSpawn(prefab);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
