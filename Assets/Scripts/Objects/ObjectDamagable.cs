using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamagable : MonoBehaviour, IDamageable
{

    [SerializeField] private int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{this.gameObject.name} took damage: {damage}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Destroy the enemy, play death animation, etc.
        Debug.Log("Enemy died.");
        Destroy(gameObject);
    }

}
