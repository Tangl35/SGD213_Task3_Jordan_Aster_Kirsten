using UnityEngine;

/// This script manages the player's health and updates the health bar on the HUD.
/// It interacts with the HUDManager to set health values.
public class HealthBar : MonoBehaviour // Renamed from HealthDisplayManager
{
    [Header("Health Settings")]
    [Tooltip("The player's current health.")]
    public int currentHealth = 100;

    [Tooltip("The player's maximum health.")]
    public int maxHealth = 100;

    [Header("Simulation Settings")]
    [Tooltip("Key to simulate taking damage.")]
    public KeyCode damageKey = KeyCode.DownArrow; // Down arrow key
    [Tooltip("Amount of damage to take when the damage key is pressed.")]
    public int damageAmount = 10;

    [Tooltip("Key to simulate healing.")]
    public KeyCode healKey = KeyCode.UpArrow; // Up arrow key
    [Tooltip("Amount of health to restore when the heal key is pressed.")]
    public int healAmount = 5;

    /// Start is called before the first frame update.
    /// Initializes the HUD with the player's initial health.
    void Start()
    {
        // Ensure HUDManager instance exists before trying to update it.
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetMaxHealth(maxHealth);
            HUDManager.Instance.SetHealth(currentHealth);
        }
        else
        {
            Debug.LogError("HUDManager.Instance is null. Please ensure HUDManager is in the scene and set up correctly.", this);
            enabled = false; // Disable this script if HUDManager is not found.
        }
    }

    /// Update is called once per frame.
    /// Handles input for simulating health changes.
    void Update()
    {
        // Simulate taking damage
        if (Input.GetKeyDown(damageKey))
        {
            TakeDamage(damageAmount);
        }

        // Simulate healing
        if (Input.GetKeyDown(healKey))
        {
            Heal(healAmount);
        }
    }

    /// Decreases the player's health and updates the HUD.
    /// This method can be called by your actual damage system.
    /// <param name="amount">The amount of damage to take.</param>
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(0, currentHealth); // Ensure health doesn't go below zero

        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetHealth(currentHealth);
            Debug.Log($"Took {amount} damage. Current Health: {currentHealth}");
        }
        else
        {
            Debug.LogWarning("HUDManager.Instance is null. Cannot update health on HUD.");
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Player has been died!");
            // Add game over logic here
        }
    }

    /// Increases the player's health and updates the HUD.
    /// <param name="amount">The amount of health to restore.</param>
    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(maxHealth, currentHealth); // Ensure health doesn't exceed max health

        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetHealth(currentHealth);
            Debug.Log($"Healed {amount} health. Current Health: {currentHealth}");
        }
        else
        {
            Debug.LogWarning("HUDManager.Instance is null. Cannot update health on HUD.");
        }
    }

    /// Sets the player's maximum health and updates the HUD.
    /// <param name="newMaxHealth">The new maximum health value.</param>
    public void SetMaxPlayerHealth(int newMaxHealth)
    {
        maxHealth = Mathf.Max(0, newMaxHealth); // Ensure max health is not negative
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Clamp current health if it exceeds new max
        }

        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetMaxHealth(maxHealth);
            HUDManager.Instance.SetHealth(currentHealth); // Update current health display too
            Debug.Log($"Max Health set to: {maxHealth}");
        }
        else
        {
            Debug.LogWarning("HUDManager.Instance is null. Cannot update max health on HUD.");
        }
    }
}