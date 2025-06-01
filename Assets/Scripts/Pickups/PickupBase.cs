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

        // Used as test code. Functions in TriggerPickup can be added back into OnTriggerEnter when Player scripts completed.
        TriggerPickup(other.gameObject);

    }

    // Allows for testing of pickups to implement ApplyPickup functionality and destroy object.
    // Functions can be added back into OnTriggerEnter once Player is in play.
    public virtual void TriggerPickup(GameObject player)
    {
        ApplyPickup(player);

        Destroy(gameObject); // In use until PooledObject Instance functionality is implemented.

        // Return to object pool instead of destroying. Cannot be implemented without PooledObject Instance functionality.
        // PooledObject.Instance.ReturnToPool(gameObject);
    }


    public virtual void ApplyPickup(GameObject player)
    {

    }
  
}
