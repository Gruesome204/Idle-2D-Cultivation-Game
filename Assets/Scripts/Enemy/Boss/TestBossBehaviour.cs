using UnityEngine;

public class TestBossBehaviour : MonoBehaviour, IDamageable,IHealable
{
    public BaseBossData baseBossData;

    [SerializeField]private int currentHealth;

    void Start()
    {
        InitializeBoss();
    }

    void InitializeBoss()
    {
        // Set up the boss properties from the data
        currentHealth = baseBossData.health;
        GetComponent<SpriteRenderer>().sprite = baseBossData.bossSprite;

        // Optional: Initialize other properties
        Debug.Log($"Boss {baseBossData.bossName} initialized with {baseBossData.health} health.");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{baseBossData.bossName} took {damage} damage, remaining health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{baseBossData.bossName} has been defeated!");
        Destroy(gameObject);
    }

    public void PerformSpecialAttack()
    {
        if (baseBossData.specialAttackPrefab != null)
        {
            Instantiate(baseBossData.specialAttackPrefab, transform.position, Quaternion.identity);
            Debug.Log($"{baseBossData.bossName} used their special attack!");
        }
    }

    public void AddHealth(int amountHealing)
    {
        currentHealth += amountHealing;
    }
}
