using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class EnemyBossAI : MonoBehaviour
{

    public BaseBossData baseBossData;
    private Aggro aggro;
    private GameObject currentTarget;
    public GameObject player;
    public float moveSpeed;
    public float detectionRange = 10f;
    private bool isAggroed;
    bool playerInRange;

    void Start()
    {
        player = FindObjectOfType<PlayerCharakter>().transform.gameObject;
        moveSpeed = baseBossData.baseSpeed;
        aggro = GetComponent<Aggro>();
    }   

    void Update()
    {
        float distance = Vector3.Distance(player.transform.position,transform.position);
        playerInRange = distance <= detectionRange;

        isAggroed = aggro != null && aggro.GetHighestAggroTarget() != null;

        if (isAggroed)
        {
            currentTarget = aggro.GetHighestAggroTarget();
        }
        else if (playerInRange)
        {
            currentTarget = player;
        }
        else
        {
            currentTarget = null;
        }

        if (currentTarget != null)
        {
            MoveTowardTarget();
        }

        UpdateTarget();

    }

    void MoveTowardTarget()
    {
        Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void UpdateTarget()
    {
        GameObject highestAggroTarget = aggro.GetHighestAggroTarget();
        if (highestAggroTarget != currentTarget)
        {
            currentTarget = highestAggroTarget;
            //Debug.Log($"New target acquired: {currentTarget?.name}");
        }
    }
}
