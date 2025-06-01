using UnityEngine;

public class EnemyFOVTrigger : MonoBehaviour
{
    public Transform player;
    public EnemyStateMachine stateMachine;
    public float viewAngle = 360f;

    public bool playerSpotted;

    private bool isPlayerInRange;

    // When player enters collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    // When player exits collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If Player is in trigger range, check visibility.
        if (isPlayerInRange)
        {
            Vector3 origin = transform.position + Vector3.up * 1.5f; // Raise origin to avoid self-hit
            Vector3 directionToPlayer = (player.position - origin).normalized;

            // Calculate angle between enemy's forward direction and direction of player
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            // If Player within field of view
            if (angleToPlayer < viewAngle / 2f)
            {
                // Optional: limit distance, or use Mathf.Infinity
                if (Physics.Raycast(origin, directionToPlayer, out RaycastHit hit, Mathf.Infinity))
                {
                    Debug.DrawRay(origin, directionToPlayer * 20f, Color.red);

                    // If ray hits player, mark as spotted
                    if (hit.collider.CompareTag("Player"))
                    {
                        playerSpotted = true;
                        return; // Early return to avoid setting false later
                    }
                }
            }
        }

        // If enemy losses sight of player
        playerSpotted = false;
    }
}
