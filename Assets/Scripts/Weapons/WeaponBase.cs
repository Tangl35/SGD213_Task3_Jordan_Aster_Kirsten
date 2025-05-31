using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics; // For debugging purposes

public class WeaponBase : MonoBehaviour
{
    public int weaponID; // Unique identifier for the weapon
    public string weaponName; // Name of the weapon
    public float fireRate = 0.5f; // Time between shots in seconds
    public float damage = 10f; // Damage dealt per shot
    public float range = 100f; // Maximum range of the weapon
    public int currentAmmo = 30; // Current ammo count
    public int maxAmmo = 100;// Maximum ammo capacity


    // When player collides with Ammo pickup, currentAmmo is increased.
    public void Reload(int ammoAmount)
    {
        currentAmmo = Mathf.Min(currentAmmo + ammoAmount, maxAmmo); // ensures player cannot have infinite ammo

        Debug.Log("Ammo added: " + ammoAmount);
    }

}
    { // when player picks up a weapon
    public void weaponid(int id)
    {
    weaponid = id;
    Debug.Log("Weapon ID set to: " + weaponID);

    }
    // when player picks up a weapon, this sets the weapon name
    public void weaponname(string name)
    {
    weaponname = name;
       Debug.Log("Weapon Name set to: " + weaponName);
    }

    // when player picks up a weapon, this sets the fire rate
    public void fireRate(float rate)
    {
    fireRate = rate;
    Debug.Log("Fire Rate set to: " + fireRate);
    }
    // when player picks up a weapon, this sets the damage
    public void damage(float dmg)
    {
    damage = dmg;
    Debug.Log("Damage set to: " + damage);
    }
    // when player picks up a weapon, this sets the range
    public void range(float rng)
    {
    range = rng;
    Debug.Log("Range set to: " + range);
}
