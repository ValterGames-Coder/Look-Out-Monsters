using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MC : MonoBehaviour
{ 
    public Sprite music_On, music_Off;
    public Button Music_Button;
    private void Start()
    {
        if (PlayerPrefs.GetString("Music") == "on")
        {
            Music_Button.GetComponent<Image>().sprite = music_On;
            Camera.main.GetComponent<AudioListener>().enabled = true;
        }
        else if (PlayerPrefs.GetString("Music") == "off")
        {
            Music_Button.GetComponent<Image>().sprite = music_Off;
            Camera.main.GetComponent<AudioListener>().enabled = false;
        }

    }

    public void MusicOn()
    {
        if(PlayerPrefs.GetString("Music") == "on")
        {
            Music_Button.GetComponent<Image>().sprite = music_Off;
            PlayerPrefs.SetString("Music", "off");
            Camera.main.GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            Music_Button.GetComponent<Image>().sprite = music_On;
            PlayerPrefs.SetString("Music", "on");
            Camera.main.GetComponent<AudioListener>().enabled = true;
        }
    }
}
