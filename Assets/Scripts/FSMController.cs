using System;
using UnityEngine;

public class FSMController : MonoBehaviour
{
    private State currentState; //Estado actual de la maquina
    private PatrolState patrolState;

    private void Awake()
    {
        patrolState = GetComponent<PatrolState>();
        ChangeState(patrolState);
    }

    private void Update()
    {
        currentState?.OnUpdateState();
    }

    public void ChangeState(State newState)
    {
        currentState?.OnExitState();
        currentState = newState;
        currentState?.OnEnterState(this);
    }
}
