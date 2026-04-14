using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PatrolState : State
{
    [SerializeField] private Transform patrolRoute;

    private NavMeshAgent agent;
    private List<Vector3> patrolPoints = new List<Vector3>();
    private int currentPatrolIndex = 0;

    private FSMController myController;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        foreach (Transform point in patrolRoute)
        {
            patrolPoints.Add(point.position);
            Debug.Log("Se añade el punto: " + point.name);
        }

        StartCoroutine(PatrolAndWait());
    }

    private IEnumerator PatrolAndWait()
    {
        while (true)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex]);
            yield return new WaitUntil(ReachedDestination);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;  
        }
    }

    private bool ReachedDestination()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }

    public override void OnEnterState(FSMController controller)
    {
        
    }

    public override void OnUpdateState()
    {
        
    }

    public override void OnExitState()
    {
        
    }
}
