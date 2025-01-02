using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class EnemyBossAI : MonoBehaviour
{

    public BaseBossData baseBossData;
    private Aggro aggro;
    private GameObject currentTarget;
    //  public Transform target;
    public float moveSpeed;
    public float detectionRange = 10f;
     bool playerIsCloseEnough;

    void Start()
    {
       // target = FindObjectOfType<PlayerCharakter>().transform;
        moveSpeed = baseBossData.baseSpeed;
        aggro = GetComponent<Aggro>();
    }   

    void Update()
    {
        //float distance = Vector3.Distance(target.position,transform.position);
        //playerIsCloseEnough = distance <= detectionRange; 

        //if(playerIsCloseEnough)
        //{
        //    Vector3 direction = (target.position - transform.position).normalized;
        //    transform.Translate((direction * moveSpeed) * Time.deltaTime);
        //}

        UpdateTarget();
        if(currentTarget != null) 
        {
            Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
            transform.Translate((direction * moveSpeed) * Time.deltaTime);
        }

     //   aggro.ReduceAggro(decayRate: 1.0f);
    }

    void UpdateTarget()
    {
        GameObject highestAggroTarget = aggro.GetHighestAggroTarget();
        if (highestAggroTarget != currentTarget)
        {
            currentTarget = highestAggroTarget;
            Debug.Log($"New target acquired: {currentTarget?.name}");
        }
    }
}
