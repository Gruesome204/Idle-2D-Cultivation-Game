using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDamagable : MonoBehaviour, IDamageable
{

    [SerializeField] private int currentHealth = 100;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{this.gameObject.name} took {damage} damage, remaining health: {currentHealth}");
        if (currentHealth <= 0)
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
