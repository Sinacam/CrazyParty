using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuManager : MonoBehaviour {
    public static float soundVolume = 0.5f;
    [SerializeField] GameObject sliderBar;
    [SerializeField] Slider slider;
    [SerializeField] AudioSource bgm;
	// Use this for initialization
	void Start () {
        sliderBar.SetActive(false);
        bgm.Play();
	}
	
	// Update is called once per frame
	void Update () {
     
    }
    public void PlayCtrl()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void SliderSetActived()
    {
        if (sliderBar.active)
        {
            sliderBar.SetActive(false);
        }
        else
        {
            sliderBar.SetActive(true);
        }
    }
    public void VolumeCtrl()
    {
        soundVolume = slider.value;
        bgm.volume = soundVolume;
    }
}
