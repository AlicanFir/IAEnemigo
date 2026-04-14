using UnityEngine;

public abstract class State : MonoBehaviour
{
    //Todo estado en una maquina de estados se ejecuta en tres fases:

    
    public abstract void OnEnterState(FSMController controller);

    public abstract void OnUpdateState();

    public abstract void OnExitState();

}
