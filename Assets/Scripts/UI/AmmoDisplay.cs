using UnityEngine;


/// This script simulates a weapon's ammo count and interacts with the HUDManager
/// to update the ammo display on the UI.
public class AmmoDisplay : MonoBehaviour // Renamed from WeaponAmmoController
{
    [Header("Weapon Stats")]
    [Tooltip("The current amount of ammo in the clip.")]
    public int currentClipAmmo = 30;

    [Tooltip("The maximum amount of ammo this weapon can hold in a single clip.")]
    public int maxClipAmmo = 30;

    [Tooltip("The total reserve ammo available for this weapon.")]
    public int totalReserveAmmo = 100;

    [Tooltip("The name of the weapon to display on the HUD.")]
    public string weaponName = "Assault Rifle";

    [Header("Simulation Settings")]
    [Tooltip("Key to simulate firing the weapon.")]
    public KeyCode fireKey = KeyCode.Mouse0; // Left mouse button
    [Tooltip("Key to simulate reloading the weapon.")]
    public KeyCode reloadKey = KeyCode.R;

   
    void Start()
    {
        // Ensure HUDManager instance exists before trying to update it.
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetAmmo(currentClipAmmo, maxClipAmmo);
            HUDManager.Instance.SetWeaponName(weaponName);
        }
        else
        {
            Debug.Log("HUDManager.Instance is null. Please ensure HUDManager is in the scene and set up correctly.", this);
            enabled = false; // Disable this script if HUDManager is not found.
        }
    }

    
    void Update()
    {
        // Simulate firing
        if (Input.GetKeyDown(fireKey))
        {
            Fire();
        }

        // Simulate reloading
        if (Input.GetKeyDown(reloadKey))
        {
            Reload();
        }
    }

    
    /// Simulates firing the weapon, decreasing ammo.
    
    public void Fire()
    {
        if (currentClipAmmo > 0)
        {
            currentClipAmmo--;
            Debug.Log($"{weaponName} fired! Ammo: {currentClipAmmo}/{maxClipAmmo}");
            UpdateHUDAmmo(); // Update the HUD after firing
        }
        else
        {
            Debug.Log($"{weaponName} is out of ammo! Reloading needed.");
            // Optionally, play an empty clip sound here
        }
    }

    
    /// Simulates reloading the weapon, transferring ammo from reserve to clip.
   
    public void Reload()
    {
        if (currentClipAmmo < maxClipAmmo && totalReserveAmmo > 0)
        {
            int ammoNeeded = maxClipAmmo - currentClipAmmo;
            int ammoToTransfer = Mathf.Min(ammoNeeded, totalReserveAmmo);

            currentClipAmmo += ammoToTransfer;
            totalReserveAmmo -= ammoToTransfer;

            Debug.Log($"{weaponName} reloaded! Clip: {currentClipAmmo}/{maxClipAmmo}, Reserve: {totalReserveAmmo}");
            UpdateHUDAmmo(); // Update the HUD after reloading
        }
        else if (totalReserveAmmo <= 0)
        {
            Debug.Log("No reserve ammo left to reload!");
        }
        else if (currentClipAmmo == maxClipAmmo)
        {
            Debug.Log("Clip is already full!");
        }
    }

    
    /// Helper method to send the current ammo state to the HUDManager.
    
    private void UpdateHUDAmmo()
    {
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetAmmo(currentClipAmmo, maxClipAmmo);
        }
    }

    
    /// Sets the weapon's name and updates the HUD.
   
    /// name="newName">The new weapon name.</param>
    public void SetWeaponDisplayName(string newName)
    {
        weaponName = newName;
        if (HUDManager.Instance != null)
        {
            HUDManager.Instance.SetWeaponName(weaponName);
        }
    }
}
