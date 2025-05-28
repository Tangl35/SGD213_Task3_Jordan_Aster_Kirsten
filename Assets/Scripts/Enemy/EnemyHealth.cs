using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private EnemyStateMachine stateMachine;

    protected override void Start()
    {
        base.Start();
        stateMachine = GetComponent<EnemyStateMachine>();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;

        Debug.Log("Enemy health reset.");
    }

    public override void Die()
    {
        base.Die();

        if (stateMachine != null)
        {
            stateMachine.SwitchState(stateMachine.deathState);
        }

        Destroy(gameObject);
 
        Debug.Log("Enemy is dead. Destroying...");

    }
}
