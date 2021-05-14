using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Music").Length == 1)
            DontDestroyOnLoad(gameObject.transform);   
        else
            Destroy(gameObject);
        
    }
}
