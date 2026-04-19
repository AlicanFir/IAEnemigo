using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool playerInteracted { get; set; }
    public bool playerInCollider { get; set; }

    private Camera cam;
    [SerializeField] private Vector3 cameraSecondLocation;
    [SerializeField] private float cameraSpeed = 5f;

    private void Awake()
    {
        cam = Camera.main;
        playerInCollider = false;
        playerInteracted = false;
    }

    private void Update()
    {
        if (cam.transform.position == cameraSecondLocation) return; //si esta ya en la segunda posicion salimos.
        
        if (playerInCollider && playerInteracted)
        {
            //muevo la cámara a la siguiente posicion
            cam.transform.position = Vector3.Lerp(cam.transform.position, cameraSecondLocation, cameraSpeed* Time.deltaTime);
            Debug.Log("Next room");
        }
    }
}
