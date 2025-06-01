using UnityEngine;

public class ChaseState : EnemyBaseState
{
    private float lostPlayerTimer = 0f;
    private float lostPlayerDelay = 5f;

    public override void EnterState(EnemyStateMachine stateMachine)
    {
        Debug.Log("Chasing player");
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        if (stateMachine.fovTrigger.playerSpotted)
        {
            lostPlayerTimer = 0f; // Reset if player still spotted.

            stateMachine.movement.MoveTo(stateMachine.fovTrigger.player.position);
        }
        else
        {
            lostPlayerTimer += Time.deltaTime;

            if (lostPlayerTimer >= lostPlayerDelay)
            {
                // Player is lost, stop chasing
                Debug.Log("Player lost. Returning to patrol...");

                // Reset enemy health
                stateMachine.enemyHealth.ResetHealth();

                stateMachine.SwitchState(stateMachine.patrolState);
            }
        }
    }

    public override void ExitState(EnemyStateMachine stateMachine)
    {
        stateMachine.movement.StopMoving();
    }
}
