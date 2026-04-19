using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Transform LeftCameraPosition;
    [SerializeField] private Transform RightCameraPosition;
    
    private bool moveCamera = false;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerInteract>(out PlayerInteract playerInteract)) // si es el player entonces cambia la camara
        {
            moveCamera = true;
        }
    }

    private void Update()
    {
        if (moveCamera)
        {
            cam.transform.position = Vector3.Lerp(RightCameraPosition.position, LeftCameraPosition.position, 3f * Time.deltaTime);
        }
        
    }
}
