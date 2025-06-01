using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug; // For debugging purposes


public class WeaponSemiauto : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform firePoint; // Point from which the bullet will be fired
    private float nextFireTime = 0f; // Time when the weapon can fire again
    public int currentAmmo = 10; // Initialize with a default value
    public float fireRate = 0.5f; // Time between shots
    public string weaponName = "Semi-Auto Weapon";

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        nextFireTime = Time.time + fireRate; // Set the next fire time
        currentAmmo--; // Decrease ammo count

        // Instantiate the bullet and set its position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add force to the bullet to make it move
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * 1000f); // Adjust force as needed
        }
        Debug.Log("Fired " + weaponName + ". Remaining ammo: " + currentAmmo);
    }
}
