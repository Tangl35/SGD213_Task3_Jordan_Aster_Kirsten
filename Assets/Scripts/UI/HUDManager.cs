using System;
using UnityEngine;
using UnityEngine.UI; // Required for UI components like Text and Slider

public class HUDManager : MonoBehaviour

   
{
    public static HUDManager Instance { get; private set; }


    [Header("UI Elements")]
    [Tooltip("Reference to the Slider component that displays the player's health.")]
    public Slider healthSlider;

    [Tooltip("Reference to the Text component that displays the current ammo count.")]
    public Text ammoText;

    [Tooltip("Reference to the Text component that displays the current grenade count.")]
    public Text grenadeText;

    [Tooltip("Reference to the Text component that displays the current weapon name.")]
    public Text weaponNameText;

    private int maxHealth = 100;
    private int currentHealth = 100;
    private int currentAmmo = 30; // Default ammo count
    private int maxAmmo = 30;     // Default max ammo
    private int currentGrenades = 3; // Default grenade count
    private string weaponName = "Pistol"; // Default weapon name

    public event Action<int, int> OnHealthChanged; // CurrentHealth, MaxHealth
    // Event for ammo changes (current, max)
    public event Action<int, int> OnAmmoChanged;
    // Event for grenade changes
    public event Action<int> OnGrenadeChanged;
    // Event for weapon name changes
    public event Action<string> OnWeaponNameChanged;

    void Awake()
    {
        // Ensure only one instance of HUDManager exists.
        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            // If another instance already exists, destroy this one.
            Debug.LogWarning("Duplicate HUDManager found, destroying this one.", this);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // Initialize UI elements with current values.
        UpdateHealthDisplay();
        UpdateAmmoDisplay();
        UpdateGrenadeDisplay();
        UpdateWeaponNameDisplay();
    }

    public void SetHealth(int newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
        UpdateHealthDisplay();
        OnHealthChanged?.Invoke(currentHealth, maxHealth); 
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = Mathf.Max(0, maxHealth); // Ensure max health is not negative
        // If current health exceeds new max health, clamp it.
        if (currentHealth > this.maxHealth)
        {
            currentHealth = this.maxHealth;
        }
        UpdateHealthDisplay();
        OnHealthChanged?.Invoke(currentHealth, this.maxHealth); // Invoke the event
    }

    public void SetAmmo(int currentAmmo, int maxAmmo)
    {
        this.currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
        this.maxAmmo = Mathf.Max(0, maxAmmo); // Ensure max ammo is not negative
        UpdateAmmoDisplay();
        OnAmmoChanged?.Invoke(this.currentAmmo, this.maxAmmo); // Invoke the event
    }

    public void SetGrenades(int grenadeCount)
    {
        currentGrenades = Mathf.Max(0, grenadeCount); // Ensure grenades are not negative
        UpdateGrenadeDisplay();
        OnGrenadeChanged?.Invoke(currentGrenades); // Invoke the event
    }

    public void SetWeaponName(string weapon)
    {
        weaponName = weapon;
        UpdateWeaponNameDisplay();
        OnWeaponNameChanged?.Invoke(weaponName); // Invoke the event
    }

    private void UpdateHealthDisplay()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.Log("Health Slider UI element is not assigned in HUDManager.");
        }
    }

    private void UpdateAmmoDisplay()
    {
        if (ammoText != null)
        {
            ammoText.text = $"Ammo: {currentAmmo}/{maxAmmo}";
        }
        else
        {
            Debug.Log("Ammo Text UI element is not assigned in HUDManager.");
        }
    }

    private void UpdateGrenadeDisplay()
    {
        if (grenadeText != null)
        {
            grenadeText.text = $"Grenades: {currentGrenades}";
        }
        else
        {
            Debug.Log("Grenade Text UI element is not assigned in HUDManager.");
        }
    }

    private void UpdateWeaponNameDisplay()
    {
        if (weaponNameText != null)
        {
            weaponNameText.text = weaponName;
        }
        else
        {
            Debug.Log("Weapon Name Text UI element is not assigned in HUDManager.");
        }
    }
}