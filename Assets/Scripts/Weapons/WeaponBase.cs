using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int currentAmmo = 30;
    public int maxAmmo = 100;


    // When player collides with Ammo pickup, currentAmmo is increased.
    public void Reload(int ammoAmount)
    {
        currentAmmo = Mathf.Min(currentAmmo + ammoAmount, maxAmmo); // ensures player cannot have infinite ammo

        Debug.Log("Ammo added: " + ammoAmount);
    }

}
