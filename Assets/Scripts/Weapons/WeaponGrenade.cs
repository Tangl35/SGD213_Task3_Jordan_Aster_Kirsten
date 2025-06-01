using UnityEngine;
using Debug = UnityEngine.Debug; // For debugging purposes

public class WeaponGrenade : MonoBehaviour
{
    public GameObject grenadePrefab; // Prefab for the grenade
    public Transform throwPoint; // Point from which the grenade will be thrown
    private float nextThrowTime = 0f; // Time when the weapon can throw again
    public int currentGrenades = 3; // Current grenade count
    public float throwRate = 1.0f; // Time between throws in seconds
    public string weaponName = "Grenades";
    public int maxGrenades = 5; // Maximum number of grenades
   
    
    void Start()
    {
        // Initialize grenade count if needed
        currentGrenades = Mathf.Min(currentGrenades, maxGrenades);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextThrowTime && currentGrenades > 0)
        {
            ThrowGrenade();
        }
    }
    void ThrowGrenade()
    {
        nextThrowTime = Time.time + throwRate; // Set the next throw time
        currentGrenades--; // Decrease grenade count
        // Instantiate the grenade and set its position and rotation
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        // Add force to the grenade to make it move
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * 500f); // Adjust force as needed
        }

        Debug.Log("Thrown " + weaponName + ". Remaining grenades: " + currentGrenades);
    }
}