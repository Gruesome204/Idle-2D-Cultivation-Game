using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class RangedEnemyBehaviour: MonoBehaviour
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;

    public BaseStatsData baseStatsData;
    private Aggro aggro;
    private GameObject currentTarget;
    public GameObject player;
    private bool isAggroed;
    float distance;
    bool playerInRange;
    public float moveSpeed;
    public float detectionRange;
    public float attackRange;

    void Start()
    {
        player = FindObjectOfType<PlayerCharakter>().transform.gameObject;
        aggro = GetComponent<Aggro>();
        InitializeBehaviour();
    }

    void InitializeBehaviour()
    {
        moveSpeed = baseStatsData.baseSpeed;
        detectionRange = baseStatsData.baseDetectionRange;
        attackRange = baseStatsData.baseAttackRange;

    }
    void Update()
    {
        GetPlayerDistance();

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

    private void GetPlayerDistance()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
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
