using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicComtroller : MonoBehaviour
{
    
    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Music").Length == 1)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
