using UnityEngine;

/// This script manages the player's grenade count and updates the grenade display on the HUD.
/// It interacts with the HUDManager to set grenade values.
/// Attach this script to your Player GameObject or a Grenade Manager GameObject.
public class GrenadeCountDisplay : MonoBehaviour // Renamed from GrenadeDisplay
{
    [Header("Grenade Settings")]
    [Tooltip("The player's current grenade count.")]
    public int currentGrenades = 3;

    [Header("Simulation Settings")]
    [Tooltip("Key to simulate using a grenade.")]
    public KeyCode useGrenadeKey = KeyCode.G; // 'G' key

    /// Start is called before the first frame update.
    /// Initializes the HUD with the player's initial grenade count.
    void Start() 
    {
        // Ensure HUDManager instance exists before trying to update it.
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetGrenades(currentGrenades);
        }
        else
        {
            Debug.Log("HUDManager.Instance is null. Please ensure HUDManager is in the scene and set up correctly.", this);
            enabled = false; // Disable this script if HUDManager is not found.
        }
    }

    /// Update is called once per frame.
    /// Handles input for simulating grenade usage and pickup.
    void Update()
    {
        // Simulate using a grenade
        if (Input.GetKeyDown(useGrenadeKey))
        {
            UseGrenade();
        }
    }

    /// Decreases the player's grenade count by one and updates the HUD.
    /// This method can be called by your actual grenade throwing logic.
    public void UseGrenade()
    {
        if (currentGrenades > 0)
        {
            currentGrenades--;
            UpdateHUDGrenades();
            Debug.Log($"Used a grenade. Remaining: {currentGrenades}");
        }
        else
        {
            Debug.Log("No grenades left!");
            // Optionally, play an "out of grenades" sound here
        }
    }

    /// Increases the player's grenade count by a specified amount and updates the HUD.
    /// <param name="amount">The number of grenades to add.</param>
    public void AddGrenades(int amount)
    {
        currentGrenades += amount;
        UpdateHUDGrenades();
        Debug.Log($"Picked up {amount} grenades. Total: {currentGrenades}");
    }

    /// Helper method to send the current grenade count to the HUDManager.
    private void UpdateHUDGrenades()
    {
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetGrenades(currentGrenades);
        }
        else
        {
            Debug.Log("HUDManager.Instance is null. Cannot update grenade count on HUD.");
        }
    }
}