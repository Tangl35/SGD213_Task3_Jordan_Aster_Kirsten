using UnityEngine;

public class AmmoPickup : PickupBase
{
    // Calls Reload() in WeaponBase and increases ammo up to maxAmmo.
    public override void ApplyPickup(GameObject player)
    {
        WeaponBase weapon = player.GetComponent<WeaponBase>();

        if (weapon != null)
        {
            weapon.Reload(pickupValue);
        }
    }
}
