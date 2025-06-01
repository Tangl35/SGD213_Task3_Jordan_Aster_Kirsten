
using UnityEngine;

public abstract class HealthBase : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;

    protected bool isDead = false;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    // Apply damage if isDead false.
    public virtual void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Apply health ammount if isDead is false
    public virtual void Heal(int amount)
    {
        if (isDead)
        {
            return;
        }

        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);

        Debug.Log("Health increased by " + amount);
    }

    public virtual void Die()
    {
        isDead = true;

        Debug.Log(gameObject.name + " has died.");
    }
}
