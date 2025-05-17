using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : EnemyBaseState
{
    private float idleTime = 2f;
    private float timer = 0f;

    private bool isAlerted = false;
    private float alertTimer = 0f;
    private float alertDuration = 2f;

    public override void EnterState(EnemyStateMachine stateMachine)
    {
        timer = 0f;
        isAlerted = false;
        alertTimer = 0f;

        Debug.Log("Entering Idle State");

        stateMachine.movement.StopMoving();
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        //
        if (stateMachine.fovTrigger.playerSpotted)
        {
            if (!isAlerted)
            {
                isAlerted = true;
                alertTimer = 0f;

                Debug.Log("Enemy idle alert! Confirming player presence...");

                return;
            }
            else
            {
                alertTimer += Time.deltaTime;

                if (alertTimer >= alertDuration)
                {
                    stateMachine.SwitchState(gameObject.AddComponent<ChaseState>());
                    return;
                }
            }
        }
        // Player lost before alert finished — cancel alert
        else if (isAlerted)
        {
            isAlerted = false;
            alertTimer = 0f;

            Debug.Log("Player lost during idle alert.");
        }

        if (!isAlerted)
        {
            timer += Time.deltaTime;
            if (timer >= idleTime)
            {
                stateMachine.SwitchState(gameObject.AddComponent<PatrolState>());
            }
        }
    }

    public override void ExitState(EnemyStateMachine stateMachine)
    {
        isAlerted = false;
        alertTimer = 0f;
    }

}
