using UnityEngine;

public class TestGrenadePickup : MonoBehaviour
{
    // Used for testing ApplyPickup code without OnTriggerEnter function through PickupBase
    public GameObject testPlayer; // Player object added into inspector
    public GrenadePickup testPickup;

    // Start is called before the first frame update
    void Start()
    {
        testPickup = GetComponent<GrenadePickup>();

        // Checks to see if GrenadePickup script on GameObject health pickup asset
        if (testPickup == null)
        {
            Debug.Log("GrenadePickup script not found on this object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Press G to simulate pickup
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (testPlayer && testPickup != null)
            {
                testPickup.TriggerPickup(testPlayer); // Handles pickup and destroys object
                Debug.Log("Tested GrenadePickup via key press G.");
            }
        }
    }
}
