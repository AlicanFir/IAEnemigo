using System.Collections.Generic;
using DG.Tweening;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public class NPC : IInteractuable
{
    [SerializeField] private List<string> dialogueLines = new List<string>();
    private int actualLine;
    [SerializeField] private GameManager gameManager;

    private bool imInteracting = false;
    [SerializeField] private BehaviorGraphAgent behaviorAgent;
    
    protected void Awake()
    {
        actualLine = 0;
        behaviorAgent = GetComponent<BehaviorGraphAgent>();
    }
    
    public override void Interact(GameObject interactor)
    {
        //transform.DOLookAt(interactor.transform.position, 2f, AxisConstraint.Y);
        behaviorAgent.BlackboardReference.SetVariableValue("ImInteracting", true);
        gameManager.playerInteracted = true;
        Debug.Log(dialogueLines[actualLine]);
    }

    public bool IsInteracting()
    {
        return true;
    }
}

