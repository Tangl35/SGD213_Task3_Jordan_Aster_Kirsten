using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthPickup : MonoBehaviour
{
    // Used for testing ApplyPickup code without OnTriggerEnter function through PickupBase
    public GameObject testPlayer; // Player object added into inspector
    public HealthPickup testPickup;

    // Start is called before the first frame update
    void Start()
    {
        testPickup = GetComponent<HealthPickup>();

        // Checks to see if HealthPickup script on GameObject health pickup asset
        if (testPickup == null)
        {
            Debug.Log("HealthPickup script not found on this object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press H to simulate pickup
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (testPlayer && testPickup != null)
            {
                testPickup.TriggerPickup(testPlayer); // Handles pickup and destroys object
                Debug.Log("Tested HealthPickup via key press H.");
            }
        }
    }
}
