using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocal : MonoBehaviour
{
    public string landving;
    Text text;

    public string TextRus;
    public string TextEng;

    void Start()
    {
        text = GetComponent<Text>();

        landving = PlayerPrefs.GetString("Laungunge");

        if (landving == "" || landving == "Eng")
        {
            text.text = TextEng;
        }
        else if(landving == "Rus")
        {
            text.text = TextRus;
        }
    }
}
