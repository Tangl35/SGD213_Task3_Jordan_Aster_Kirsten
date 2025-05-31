using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= Damage; 
        }
    }
}
