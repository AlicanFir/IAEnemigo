using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class NPC : IInteractuable
{
    [SerializeField] private List<string> dialogueLines = new List<string>();
    private int actualLine;

    protected void Awake()
    {
        actualLine = 0;
    }
    
    public override void Interact(GameObject interactor)
    {
        transform.DOLookAt(interactor.transform.position, 2f, AxisConstraint.Y);
        
        Debug.Log(dialogueLines[actualLine]);
        
        
    }
}

