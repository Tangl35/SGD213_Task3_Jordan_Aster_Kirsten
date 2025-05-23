using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthPickup : PickupBase
{
    // Calls Heal() in HealthBase and increases health up to maxHealth value.
    public override void ApplyPickup(GameObject player)
    {
        HealthBase health = player.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Heal(pickupValue);
        }
    }
}

