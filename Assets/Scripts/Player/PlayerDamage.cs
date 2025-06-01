using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerController PlayerController;
    public float Damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().health -= Damage; 
        }
    }
}
