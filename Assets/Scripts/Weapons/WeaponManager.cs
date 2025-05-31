using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int grenadeCount = 3;
    public int maxGrenades = 5;

    //When player collides with grenade pickup, grenade count increased
    public void AddGrenades(int amount)
    {
        grenadeCount = Mathf.Min(grenadeCount + amount, maxGrenades); // ensures player cannot have infinite grenades.

        Debug.Log("Grenades added: " + amount);
    }
}

    // Method to throw a grenade
public void ThrowGrenade()
{
    if (grenadeCount > 0)
    {
        grenadeCount--;
        Debug.Log("Thrown a grenade. Remaining grenades: " + grenadeCount);
        // Adds logic to handle grenade throwing
    }
    else
    {
        Debug.LogWarning("No grenades left to throw!");
    }
}




public void currentweapon(int weaponID)
    {
        currentweapon = weaponID; // Sets the current weapon to the specified weapon ID
        Debug.Log("Switched to weapon ID: " + currentweapon);

        return currentweapon; // Returns the current weapon ID
    }


        // Primary and secondary weapon management
    public int primaryWeaponID = 0; // Variable to hold the current primary weapon ID
    public int primaryWeaponAmmoCount = 30;
    public int primaryWeaponAmmoLimit = 100;
        // When player collides with primary weapon ammo pickup, primary weapon ammo is increased.
      
    public void ReloadPrimaryWeapon(int ammoAmount)
    {
        primaryWeaponAmmoCount = Mathf.Min(primaryWeaponAmmoCount + ammoAmount, primaryWeaponAmmoLimit); // ensures player cannot have infinite ammo
        Debug.Log("Primary Weapon Ammo added: " + ammoAmount);
    }
 
    public int secondaryWeaponID = 1; // Variable to hold the current secondary weapon ID
    public int secondaryWeaponAmmoCount = 20;
    public int secondaryWeaponAmmoLimit = 50;


    // When player collides with secondary weapon ammo pickup, secondary weapon ammo is increased.
    public void ReloadSecondaryWeapon(int ammoAmount)
    {
        secondaryWeaponAmmoCount = Mathf.Min(secondaryWeaponAmmo + ammoAmount, secondaryWeaponAmmoLimit); // ensures player cannot have infinite ammo
        Debug.Log("Secondary Weapon Ammo added: " + ammoAmount);
    }

// Method to switch between primary and secondary weapons
public void SwitchWeapon(int weaponID)
{
    if (weaponID == primaryWeaponID)
    {
        Debug.Log("Switched to Primary Weapon ID: " + primaryWeaponID);
    }
    else if (weaponID == secondaryWeaponID)
    {
        Debug.Log("Switched to Secondary Weapon ID: " + secondaryWeaponID);
    }
    else
    {
        Debug.LogWarning("Invalid Weapon ID: " + weaponID);
    }
}

// Method to start shooting the current weapon
public void StartShooting(int weaponID)
{
    if (weaponID == primaryWeaponID)
    {
        Debug.Log("Started shooting Primary Weapon ID: " + primaryWeaponID);
        // Add logic to handle shooting the primary weapon
    }
    else if (weaponID == secondaryWeaponID)
    {
        Debug.Log("Started shooting Secondary Weapon ID: " + secondaryWeaponID);
        // Add logic to handle shooting the secondary weapon
    }
    else
    {
        Debug.LogWarning("Invalid Weapon ID for shooting: " + weaponID);
    }
}
