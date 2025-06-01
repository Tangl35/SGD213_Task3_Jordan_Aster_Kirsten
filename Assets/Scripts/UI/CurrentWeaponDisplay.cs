using UnityEngine;

/// This script manages the display of the current weapon's name on the HUD.

public class CurrentWeaponDisplay : MonoBehaviour
{
    [Header("Weapon Display Settings")]
    [Tooltip("The name of the current weapon to display on the HUD.")]
    public string initialWeaponName = "Assault Rifle"; // Initial weapon name

    [Header("Simulation Settings")]
    [Tooltip("Key to simulate switching to Weapon 1 (e.g., Assault Rifle).")]
    public KeyCode weapon1Key = KeyCode.Alpha1; // '1' key
    [Tooltip("Key to simulate switching to Weapon 2 (e.g., Pistol).")]
    public KeyCode weapon2Key = KeyCode.Alpha2; // '2' key


   
    void Start()
    {
        // Ensure HUDManager instance exists before trying to update it.
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetWeaponName(initialWeaponName);
        }
        else
        {
            Debug.Log("HUDManager.Instance is null. Please ensure HUDManager is in the scene and set up correctly.", this);
            enabled = false; // Disable this script if HUDManager is not found.
        }
    }

    
    void Update()
    {
        // Simulate weapon switching for demonstration
        if (Input.GetKeyDown(weapon1Key))
        {
            SetCurrentWeapon("Assault Rifle");
        }
        else if (Input.GetKeyDown(weapon2Key))
        {
            SetCurrentWeapon("Pistol");
        
        }
    }

    /// Sets the current weapon name and updates the HUD.
    /// <param name="newWeaponName">The name of the weapon to display.</param>
    public void SetCurrentWeapon(string newWeaponName)
    {
        initialWeaponName = newWeaponName; // Update the internal state
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetWeaponName(initialWeaponName);
            Debug.Log($"Weapon switched to: {initialWeaponName}");
        }
        else
        {
            Debug.Log("HUDManager.Instance is null. Cannot update weapon name on HUD.");
        }
    }
}
