using UnityEngine;

/// <summary>
/// Enemy Base State works with IdleState, PatrolState, ChaseState and DeathState for EnemyAI controller.
/// </summary>
public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateMachine stateMachine);
    public abstract void UpdateState(EnemyStateMachine stateMachine);
    public abstract void ExitState(EnemyStateMachine stateMachine);
}