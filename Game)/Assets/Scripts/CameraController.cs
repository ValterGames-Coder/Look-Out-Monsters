using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject pl;
    public float speedCamera;

    [SerializeField] private float leftlimit;
    [SerializeField] private float rightlimit;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(pl.transform.position.x, pl.transform.position.y, transform.position.z), speedCamera);


        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftlimit, rightlimit),
            transform.position.y, transform.position.z
            );
    }
}
