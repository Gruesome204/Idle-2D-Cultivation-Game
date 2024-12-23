using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class EnemyAI : MonoBehaviour
{
public Transform player;
    public float detectionRange = 10f;
    private NavMeshAgent agent;

    void Start()
    {
        player = FindObjectOfType<PlayerCharakter>().transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void Patrol()
    {
        // Implement patrol behavior here
        // For example, move between predefined waypoints
    }
}
