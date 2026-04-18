using System;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        gameManager.playerInCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        gameManager.playerInCollider = false;
    }
}
