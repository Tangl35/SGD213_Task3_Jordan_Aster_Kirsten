using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    // Array of waypoints the enemy will move between when patrolling.
    public Transform[] patrolPoints;

    // Tracks patrol points enemy is headed to.
    public int currentPatrolIndex = 0;

    // Start is called before the first frame update.
    void Start()
    {
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
    }

    // Tells Nav Mesh to move enemy to a given position.
    public void MoveTo(Vector3 position)
    {
        if (agent.destination != position)
        {
            agent.SetDestination(position);
        }
    }

    // Checks to see if enemy reached destination. Threshold defines how close is 'close enough'.
    public bool ReachedDestination(float threshold = 0.5f)
    {
        return !agent.pathPending && agent.remainingDistance <= threshold;
    }

    // Returns the position of current control point.
    public Vector3 GetCurrentPatrolPoint()
    {
        return patrolPoints[currentPatrolIndex].position;
    }

    // Enemy moves to next patrol point and loops.
    public void GoToNextPatrolPoint()
    {
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    // Stops enemy and clears current path.
    public void StopMoving()
    {
        agent.ResetPath();
    }
}
