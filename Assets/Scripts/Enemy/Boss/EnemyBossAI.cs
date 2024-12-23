using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class EnemyBossAI : MonoBehaviour
{

    public BaseBossData baseBossData;
    public Transform target;
    public float moveSpeed;
    public float detectionRange = 10f;
     bool playerIsCloseEnough;

    void Start()
    {
        target = FindObjectOfType<PlayerCharakter>().transform;
        moveSpeed = baseBossData.speed;
    }   

    void Update()
    {
            float distance = Vector3.Distance(target.position,transform.position);
             playerIsCloseEnough = distance <= detectionRange; 

    if(playerIsCloseEnough){


                Vector3 direction = (target.position - transform.position).normalized;
                transform.Translate((direction * moveSpeed) * Time.deltaTime);
    }


    }

}
