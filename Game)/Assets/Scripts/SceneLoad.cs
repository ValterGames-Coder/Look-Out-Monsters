using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{
    public GameObject PauseG;
    public GameObject SettingsPanel;
    public GameObject panelQ;
    [SerializeField] private Dropdown dropdown;

    [SerializeField] private Text HighScore;
    //public Image bar;

    public static bool Game = false;
    public bool panelSet;

    private void Start()
    {
        PlayerPrefs.GetInt("LEVEL");
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("D") == 0)
        {
            dropdown.value = 0;
        }
        else if (PlayerPrefs.GetInt("D") == 1)
        {
            dropdown.value = 1;
        }
        else if (PlayerPrefs.GetInt("D") == 2)
        {
            dropdown.value = 2;
        }
    }

    private void Update()
    {
        HighScore.text = PlayerPrefs.GetFloat("Save").ToString("F1");
    }

    public void Load(int maxlevel)
    {
        int level = Random.Range(3, maxlevel);
        SceneManager.LoadScene(level);
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Drobdown(int value)
    {
        if (value == 0)
        {
            PlayerPrefs.SetInt("LEVEL", value);
            dropdown.value = 0;

        }
        else if (value == 1)
        {
            PlayerPrefs.SetInt("LEVEL", value);
            dropdown.value = 1;
        }
        else if (value == 2)
        {
            PlayerPrefs.SetInt("LEVEL", value);
            dropdown.value = 2;
        }

        PlayerPrefs.SetInt("D", dropdown.value);
    }
    public void Resume()
    {
        PauseG.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Panel()
    {
        panelSet = true;
        SettingsPanel.GetComponent<Animation>().Play("nim");

    }

    public void PanelQuit()
    {
        panelQ.SetActive(true);
    }

    public void PanelQuitOff()
    {
        panelQ.SetActive(false);
    }

    public void PanelOff()
    {
        SettingsPanel.GetComponent<Animation>().Play("nim2");
        panelSet = false;
    }

    public void Pause()
    {
        PauseG.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
