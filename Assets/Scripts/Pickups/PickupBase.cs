using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class PickupBase : MonoBehaviour
{
    public int pickupValue = 1;

    public virtual void OnTriggerEnter(Collider other)
    {
        // Check if player collided with pickup.
        if (!other.CompareTag("Player"))
        {
            return;
        }

        ApplyPickup(other.gameObject);

        // Return to object pool instead of destroying
        PooledObject.Instance.ReturnToPool(gameObject);

    }

    public virtual void ApplyPickup(GameObject player)
    {

    }
  
}
