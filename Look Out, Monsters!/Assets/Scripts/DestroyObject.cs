﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject, time);
    }

}
