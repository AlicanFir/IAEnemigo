using System;
using UnityEngine;

public abstract class IInteractuable : MonoBehaviour
{
    protected void Awake()
    {
        
    }

    public abstract void Interact(GameObject interactor);
}
