using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    [Header("Click Movement Settings")]
    [SerializeField] float speed = 5f;
    private Vector2 targetPosition;
    [SerializeField]private bool isMoving = false;

    //void Start()
    //{
    //  //  targetPosition = new Vector2(0.0f, 0.0f);
    //}

    private void Update()
    {

        //Mouse Click Movement
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = Input.mousePosition;
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(targetPosition.x, targetPosition.y, 0.0f));
            isMoving = true;


        }

        if(isMoving)
        {    
            this.transform.position = Vector2.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }



    }

}


