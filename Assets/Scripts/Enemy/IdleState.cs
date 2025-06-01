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

    // Checks to see if player has been spotted
    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        // Detect if player is spotted by enemy
        if (stateMachine.fovTrigger.playerSpotted)
        {

            if (!isAlerted)
            {
                Debug.Log("Player spotted — switching to ChaseState");

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
                    Debug.Log("Player confirmed. Switching to ChaseState.");
                    stateMachine.SwitchState(stateMachine.chaseState);
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
                stateMachine.SwitchState(stateMachine.patrolState);
            }
        }
    }

    // Resets player alert values before exiting state.
    public override void ExitState(EnemyStateMachine stateMachine)
    {
        isAlerted = false;
        alertTimer = 0f;
    }

}
