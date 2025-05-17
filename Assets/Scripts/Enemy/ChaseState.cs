using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyBaseState
{
    public override void EnterState(EnemyStateMachine stateMachine)
    {
        Debug.Log("Chasing player");
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        if (!stateMachine.fovTrigger.playerSpotted)
        {
            stateMachine.SwitchState(new IdleState()); // Or return to patrol immediately
            return;
        }

        stateMachine.movement.MoveTo(stateMachine.fovTrigger.player.position);
    }

    public override void ExitState(EnemyStateMachine stateMachine)
    {
        stateMachine.movement.StopMoving();
    }
}
