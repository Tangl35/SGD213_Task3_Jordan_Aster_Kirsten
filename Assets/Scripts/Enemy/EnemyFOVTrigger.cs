using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOVTrigger : MonoBehaviour
{
    public Transform player;
    public EnemyStateMachine stateMachine;
    public float viewAngle = 120f;
    public LayerMask obstacleMask;

    public bool playerSpotted;

    private bool isPlayerInRange;

    // When player enters collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
        }
    }

    // When player exits collider
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Player is spotted, returns playerSpotted as true.
        if (isPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit, ~obstacleMask))
            {
                if (raycastHit.collider.transform == player)
                {
                    playerSpotted = true;
                    return;
                }
            }
        }

        // If enemy losses sight of player
        playerSpotted = false;
    }
}
