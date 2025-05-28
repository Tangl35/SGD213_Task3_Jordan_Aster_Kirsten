using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthBase
{
    private EnemyStateMachine stateMachine;
    public EnemySpawner spawner;

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
        // Let spawner no enemy has died
        if (spawner != null)
        {
            spawner.OnEnemyDeath();
        }

        base.Die();

        if (stateMachine != null)
        {
            stateMachine.SwitchState(stateMachine.deathState);
        }

        // Disable the GameObject
        gameObject.SetActive(false);

        Debug.Log("Enemy is dead. Destroying...");

    }
}
