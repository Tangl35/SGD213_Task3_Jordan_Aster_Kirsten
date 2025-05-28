using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [Header("Core Components")]
    public EnemyMovement movement;
    public EnemyFOVTrigger fovTrigger;
    public EnemyHealth enemyHealth;

    // Current active state
    private EnemyBaseState currentState;

    [HideInInspector] public EnemyBaseState idleState;
    [HideInInspector] public EnemyBaseState patrolState;
    [HideInInspector] public EnemyBaseState chaseState;
    [HideInInspector] public EnemyBaseState deathState;


    void Start()
    {
        // Ensure required references are assigned
        if (movement == null)
        {
            movement = GetComponent<EnemyMovement>();
        }

        if (fovTrigger == null)
        {
            fovTrigger = GetComponentInChildren<EnemyFOVTrigger>();
        }

        fovTrigger = GetComponentInChildren<EnemyFOVTrigger>();

        // Create instances of states
        idleState = new IdleState();
        patrolState = new PatrolState();
        chaseState = new ChaseState();
        deathState = new DeathState();

        enemyHealth = GetComponent<EnemyHealth>();

        // Start in idle state
        currentState = idleState;
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
