using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealthState : EnemyBaseState
{
    // Stops enemy and disables - return to ObjectPool
    public override void EnterState(EnemyStateMachine stateMachine)
    {
        Debug.Log("Enemy died.");
        stateMachine.movement.StopMoving();
        stateMachine.GetComponent<Collider>().enabled = false;

        // Write code to return to object pool and potentially respwn new enemy??
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        // Do nothing — enemy is dead
    }

    public override void ExitState(EnemyStateMachine stateMachine)
    {
        
    }
}
