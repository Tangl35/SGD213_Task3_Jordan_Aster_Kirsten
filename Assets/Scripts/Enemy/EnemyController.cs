using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("References")]
    private EnemyStateMachine stateMachine;
    private EnemyMovement movement;
    private EnemyHealth enemyHealth;
    private EnemyFOVTrigger fovTrigger;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<EnemyStateMachine>();
        movement = GetComponent<EnemyMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
        fovTrigger = GetComponentInChildren<EnemyFOVTrigger>();

        currentHealth = maxHealth;
    }

    //
    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Debug.Log($"{gameObject.name} has died.");

        // Notify state machine to switch to DeathState
        stateMachine.SwitchState(new DeathState());

        fovTrigger.enabled = false;
    }
}
