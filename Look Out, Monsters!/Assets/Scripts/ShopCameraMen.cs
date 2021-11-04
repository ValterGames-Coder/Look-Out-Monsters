using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCameraMen : MonoBehaviour
{
    public Vector2 StartPoz;
    public Vector2 EndPoz;
    public GameObject cam;
    public float speed;
    private float progress;

    private void Start()
    {
        StartPoz = cam.transform.position;
    }

    public void Update()
    {

    }
    public void Poz()
    {
        cam.transform.position = Vector2.Lerp(StartPoz, EndPoz, progress);
        progress += speed;
    }
}
