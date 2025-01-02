using UnityEngine;
using System.Collections.Generic;
public class SlimeKingBoss : MonoBehaviour, IDamageable, IHealable
{
    public BaseStatsData baseStatsData;
    public ParticleSystem damageParticles;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damage;
    [SerializeField] private float speed;

    void Start()
    {
        InitializeBoss();
    }

    void InitializeBoss()
    {
        // Set up the boss properties from the data
        maxHealth = baseStatsData.baseHealth; 
        currentHealth = baseStatsData.baseHealth;
        damage = baseStatsData.baseDamage;
        speed = baseStatsData.baseSpeed;

        GetComponent<SpriteRenderer>().sprite = baseStatsData.baseSprite;

        // Optional: Initialize other properties
        Debug.Log($"Boss {baseStatsData.baseName} initialized with {baseStatsData.baseHealth} health.");
    }


    public void TakeDamage(int damage)
    {
        PlayDamageEffect(this.transform.position);
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log($"{baseStatsData.baseName} has been defeated!");
        Destroy(gameObject);
    }

    public void PerformSpecialAttack()
    {
        if (baseStatsData.baseSpecialAttackPrefab != null)
        {
            Instantiate(baseStatsData.baseSpecialAttackPrefab, transform.position, Quaternion.identity);
            Debug.Log($"{baseStatsData.baseName} used their special attack!");
        }
    }

    public void AddHealth(int amountHealing)
    {
        currentHealth += amountHealing;
        currentHealth = Mathf.Min(currentHealth, baseStatsData.baseHealth);
    }

    public void PlayDamageEffect(Vector3 position)
    {
        damageParticles.transform.position = position;
        damageParticles.Play();
    }
}
