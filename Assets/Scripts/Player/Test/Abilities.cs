using System;
using System.Collections;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [SerializeField] GameObject ShootProjectilePrefab;

    private Vector3 mousePosition;

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootProjectile(mousePosition);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
        }
    }

    private void ShootProjectile(Vector3 mousePosition)
    {
        GameObject projectileGO = (GameObject)Instantiate(ShootProjectilePrefab, transform.position, ShootProjectilePrefab.transform.rotation);
        BulletOneBehaviour bulletOneBehaviour = projectileGO.GetComponent<BulletOneBehaviour>();
        bulletOneBehaviour.directionToTarget = (mousePosition - Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y))).normalized;
    }



    }


