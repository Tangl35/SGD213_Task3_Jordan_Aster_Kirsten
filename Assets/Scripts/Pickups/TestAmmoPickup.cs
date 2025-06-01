using UnityEngine;

public class TestAmmoPickup : MonoBehaviour
{
    // Used for testing ApplyPickup code without OnTriggerEnter function through PickupBase
    public GameObject testPlayer; // Player object added into inspector
    public AmmoPickup testPickup;

    // Start is called before the first frame update
    void Start()
    {
        testPickup = GetComponent<AmmoPickup>();

        // Checks to see if AmmoPickup script on GameObject health pickup asset
        if (testPickup == null)
        {
            Debug.Log("AmmoPickup script not found on this object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press B to simulate pickup
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (testPlayer && testPickup != null)
            {
                testPickup.TriggerPickup(testPlayer); // Handles pickup and destroys object
                Debug.Log("Tested AmmoPickup via key press B.");
            }
        }
    }
}
