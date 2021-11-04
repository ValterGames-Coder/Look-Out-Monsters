using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_On : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
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
}
