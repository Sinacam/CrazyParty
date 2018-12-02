using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Space))
=======
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
>>>>>>> master
            SceneManager.LoadScene("Lobby");
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
			SceneManager.LoadScene("Lobby");
    }
}
