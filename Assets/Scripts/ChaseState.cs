using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : State
{
    private FSMController myController;
    public override void OnEnterState(FSMController controller)
    {
        myController = controller;
    }

    public override void OnUpdateState()
    {
        
    }

    public override void OnExitState()
    {
        
    }
}
