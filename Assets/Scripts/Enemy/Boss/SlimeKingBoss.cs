using UnityEngine;
using System.Collections.Generic;
public class SlimeKingBoss : MonoBehaviour, IDamageable, IHealable
{
    public BaseBossData baseBossData;
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
        maxHealth = baseBossData.baseHealth; 
        currentHealth = baseBossData.baseHealth;
        damage = baseBossData.baseDamage;
        speed = baseBossData.baseSpeed;

        GetComponent<SpriteRenderer>().sprite = baseBossData.baseSprite;

        // Optional: Initialize other properties
        Debug.Log($"Boss {baseBossData.baseName} initialized with {baseBossData.baseHealth} health.");
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
        Debug.Log($"{baseBossData.baseName} has been defeated!");
        Destroy(gameObject);
    }

    public void PerformSpecialAttack()
    {
        if (baseBossData.baseSpecialAttackPrefab != null)
        {
            Instantiate(baseBossData.baseSpecialAttackPrefab, transform.position, Quaternion.identity);
            Debug.Log($"{baseBossData.baseName} used their special attack!");
        }
    }

    public void AddHealth(int amountHealing)
    {
        currentHealth += amountHealing;
        currentHealth = Mathf.Min(currentHealth, baseBossData.baseHealth);
    }

    public void PlayDamageEffect(Vector3 position)
    {
        damageParticles.transform.position = position;
        damageParticles.Play();
    }
}
