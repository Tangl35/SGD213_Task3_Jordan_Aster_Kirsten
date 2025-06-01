using UnityEngine;

public class InputManager : MonoBehaviour
   
{
    float VerticalInput;
    float HorizontalInput;

    private WeaponBase weapon;
    private WeaponManager shooting;
    private WeaponBase grenade;
    private PlayerMovement movement;

    public WeaponBase Weapon 
    { 
        get { return weapon; } 
        set { weapon = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<WeaponManager>();
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //  shooting.StartShooting();
        //}

        //input for grenade
        //input for weapon swapping
    }
}
