using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class MeeleEnemyBehaviour: MonoBehaviour
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;

    public BaseStatsData baseStatsData;
    private Aggro aggro;
    [SerializeField] private GameObject currentTarget;
    public GameObject player;
    private bool isAggroed;
    public float moveSpeed;
    public float detectionRange;
    [SerializeField]float playerDistance;
    bool playerInRange;
    public float attackRange;
    bool playerInAttackRange;

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
        IsPlayerInDetectionRange();
        GetPlayerDistance();
        if (currentTarget != null)
        {
            IsPlayerInAttackRange();   
        }

        

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

        if(playerInAttackRange)
        {
            Debug.Log("Attack Player");
            currentTarget.GetComponent<IDamageable>().TakeDamage(baseStatsData.baseDamage);
        }
    }
    private void IsPlayerInDetectionRange()
    {
        Debug.Log("Player in Detection Range");
        playerInRange = playerDistance <= detectionRange;
    }
    private void IsPlayerInAttackRange()
    {
        playerInAttackRange = playerDistance <= attackRange;
    }

    private void GetPlayerDistance()
    {
        playerDistance = Vector3.Distance(player.transform.position, transform.position);
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
