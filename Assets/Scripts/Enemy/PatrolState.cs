using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyBaseState
{

    private bool isAlerted = false;
    private float alertTimer = 0f;
    private float alertDuration = 2f;


    public override void EnterState(EnemyStateMachine stateMachine)
    {
        isAlerted = false;
        alertTimer = 0f;

        Debug.Log("Entering Patrol State");

        // Start moving to current patrol point
        stateMachine.movement.MoveTo(stateMachine.movement.GetCurrentPatrolPoint());
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        if (stateMachine.fovTrigger.playerSpotted)
        {
            if (!isAlerted)
            {
                isAlerted = true;
                alertTimer = 0f;
                stateMachine.movement.StopMoving();

                // Optional: trigger alert sound
                Debug.Log("Enemy alerted! Waiting before chasing...");
            }
            else
            {
                alertTimer += Time.deltaTime;
                if (alertTimer >= alertDuration)
                {
                    stateMachine.SwitchState(gameObject.AddComponent<ChaseState>());
                }
            }

            return; // Pause patrol while alerting
        }


        // Resume patrol if not alerted
        if (!isAlerted && stateMachine.movement.ReachedDestination())
        {
            stateMachine.movement.GoToNextPatrolPoint();
            stateMachine.SwitchState(gameObject.AddComponent<IdleState>()); // brief pause before next patrol
        }
    }

    public override void ExitState(EnemyStateMachine stateMachine)
    {
        isAlerted = false;
        alertTimer = 0f;
    }
}
