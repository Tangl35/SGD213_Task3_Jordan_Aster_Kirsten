using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public int currentHealth = 100;
    public int maxHealth = 100;


    // Player collides with Health pickup and increases player health.
    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth); // ensures player cannot have infinite health.

        Debug.Log("Health increased: " + amount);
    }

}
