using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Localision : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.GetString("Music") == "on")
        {
            Camera.main.GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            Camera.main.GetComponent<AudioListener>().enabled = true;
        }
    }

    public void Rus()
    {
        string langunge = "Rus";
        PlayerPrefs.SetString("Laungunge", langunge);
        SceneManager.LoadScene(0);
    }

    public void Eng()
    {
        string langunge = "Eng";
        PlayerPrefs.SetString("Laungunge", langunge);
        SceneManager.LoadScene(0);
    }

    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/_valtergames_/");
    }

    public void YouTube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCRoCgIdFT2_IlPJMoMiDzIg");
    }

    public void Discord()
    {
        Application.OpenURL("https://discord.gg/fYQAEFrARV");
    }
}
