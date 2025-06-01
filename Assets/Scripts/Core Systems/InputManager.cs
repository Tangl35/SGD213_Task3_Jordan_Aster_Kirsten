using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
    //refrence to weaponscript
{ 
    private WeaponBase weapon;
    private WeaponBase shooting;
    private WeaponBase grenade;

    public WeaponBase Weapon 
    { 
        get { return weapon; } 
        set { weapon = value; }
    }
 

    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<WeaponBase>();
    }

    // Update is called once per frame
    void Update()
    {
     //input for shooting
     //input for grenade
     //input for weapon swapping
    }
}
