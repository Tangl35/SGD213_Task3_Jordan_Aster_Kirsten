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
   
public void switchweapon(int weaponID)
    { 
        switchweapon = weaponID; // Sets the current weapon to the specified weapon ID
        Debug.Log("Switched to weapon ID: " + switchweapon);

return switchweapon; // Returns the current weapon ID
}


        // Primary and secondary weapon management
    public int primaryweapon = 0; // Variable to hold the current primary weapon ID
    public int primaryWeaponAmmo = 30;
    public int maxPrimaryWeaponAmmo = 100;
// When player collides with primary weapon ammo pickup, primary weapon ammo is increased.
   
public void ReloadPrimaryWeapon(int ammoAmount)
{
    primaryWeaponAmmo = Mathf.Min(primaryWeaponAmmo + ammoAmount, maxPrimaryWeaponAmmo); // ensures player cannot have infinite ammo
    Debug.Log("Primary Weapon Ammo added: " + ammoAmount);
}

    public int secondaryweapon = 1; // Variable to hold the current secondary weapon ID
    public int secondaryWeaponAmmo = 20;
    public int maxSecondaryWeaponAmmo = 50;


    // When player collides with secondary weapon ammo pickup, secondary weapon ammo is increased.
    public void ReloadSecondaryWeapon(int ammoAmount)
    {
        secondaryWeaponAmmo = Mathf.Min(secondaryWeaponAmmo + ammoAmount, maxSecondaryWeaponAmmo); // ensures player cannot have infinite ammo
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
