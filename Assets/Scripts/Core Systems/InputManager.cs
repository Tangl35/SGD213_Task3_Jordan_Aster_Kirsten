using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
    //refrence to weaponscript
{
    float VerticalInput;
    float HorizontalInput;

    private WeaponBase weapon;
    private WeaponBase shooting;
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
        shooting = GetComponent<WeaponBase>();
        movement = GetComponent<PlayerMovement>();
    }
    private void PlayerInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        //input for shooting
        //input for grenade
        //input for weapon swapping
    }
}
