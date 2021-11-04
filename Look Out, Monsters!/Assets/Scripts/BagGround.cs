using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGround : MonoBehaviour
{
    [SerializeField] private Vector2 paralax;
    private Transform cameraTransform;
    private Vector3 CameraPos;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        CameraPos = cameraTransform.position;
    }
    void LateUpdate()
    {
        Vector3 DeltaM = cameraTransform.position - CameraPos;
        transform.position += new Vector3(DeltaM.x * paralax.x, DeltaM.y * paralax.y, transform.position.z);
        CameraPos = cameraTransform.position;

    }
}
