using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [Header("Core Components")]
    public EnemyMovement movement;
    public EnemyFOVTrigger fovTrigger;

    private EnemyBaseState currentState;

    void Start()
    {
        // Ensure required references are assigned
        if (movement == null)
        {
            movement = GetComponent<EnemyMovement>();
        }

        if (fovTrigger == null)
        {
            fovTrigger = GetComponent<EnemyFOVTrigger>();
        }

        // Start in idle state
        currentState = gameObject.AddComponent<PatrolState>();
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
