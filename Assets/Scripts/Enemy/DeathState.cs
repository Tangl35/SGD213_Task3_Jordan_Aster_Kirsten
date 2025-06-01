using UnityEngine;

public class DeathState : EnemyBaseState
{
    // Stops enemy and disables - return to ObjectPool
    public override void EnterState(EnemyStateMachine stateMachine)
    {
        Debug.Log("Enemy died.");

        // Stop movement
        stateMachine.movement.StopMoving();

        stateMachine.GetComponent<Collider>().enabled = false;
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        // Do nothing — enemy is dead
    }

    public override void ExitState(EnemyStateMachine stateMachine)
    {
        // Does not require an exit of state.
    }
}
