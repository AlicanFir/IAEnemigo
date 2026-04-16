using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput input;
    
    [Header("InteractionDetection")] 
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionRadius;
    
    private void Awake()
    {
        input = GetComponent<PlayerInput>();

    }

    private void OnEnable()
    {
        input.actions["Interact"].started += Interact; 
    }
    
    private void OnDisable()
    {
        input.actions["Interact"].started -= Interact;
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        Collider[] colliders = Physics.OverlapSphere(interactionPoint.position, interactionRadius);
        if (colliders[0] == null) return; // si el array esta vacio se acaba
        
        //hay elementos en el collider
        foreach (var col in colliders)
        {
            if (col.TryGetComponent<IInteractuable>(out IInteractuable interactuable))
            {
                interactuable.Interact(this.gameObject);
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactionPoint.position, interactionRadius);
    }


}
