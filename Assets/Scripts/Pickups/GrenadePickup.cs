using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : PickupBase
{
    // Calls AddGrenades() function and increases grenade count up to maxGrenades.
    public override void ApplyPickup(GameObject player)
    {
        WeaponManager weaponManager = player.GetComponent<WeaponManager>();

        if (weaponManager != null)
        {
            weaponManager.AddGrenades(pickupValue);
        }
    }
}
