using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int grenadeCount = 3;
    public int maxGrenades = 5;

    //When player collides with grenade pickup, grenade count increased
    public void AddGrenades(int amount)
    {
        grenadeCount = Mathf.Min(grenadeCount + amount, maxGrenades); // ensures player cannot have infinite grenades.

        Debug.Log("Grenades added: " + amount);
    }
}
