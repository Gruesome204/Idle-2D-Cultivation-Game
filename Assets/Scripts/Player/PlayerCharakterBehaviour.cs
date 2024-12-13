using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerCharakter : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerDataSO;

    private void Start()
    {
        if(playerDataSO.characterClass != null)
        {
            InitializeInitialStats();
        }
        else
        {
            Debug.Log("Player has no Class");
        }
    }


    private void InitializeInitialStats()
    {
    
        playerDataSO.maxHealth = playerDataSO.characterClass.baseHealth  + (int)playerDataSO.PlayerRealmLevel * playerDataSO.characterClass.healthPerLevel + (playerDataSO.equippedItem != null ? playerDataSO.equippedItem.bonusHealth : 0) + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusHealth : 0);
        playerDataSO.currentHealth = playerDataSO.maxHealth;
        playerDataSO.currentAttack = playerDataSO.characterClass.baseAttack + (int)playerDataSO.PlayerRealmLevel * playerDataSO.characterClass.attackPerLevel + (playerDataSO.equippedItem != null ? playerDataSO.equippedItem.bonusAttack : 0) + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusAttack : 0);
        playerDataSO.currentDefense = playerDataSO.characterClass.baseDefense + (int)playerDataSO.PlayerRealmLevel * playerDataSO.characterClass.defensePerLevel + (playerDataSO.equippedItem != null ? playerDataSO.equippedItem.bonusDefense : 0) + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusDefense : 0);
        playerDataSO.currentAttackSpeed = playerDataSO.characterClass.attackSpeed + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusAttackspeed : 0);
    }

    private void InitializeAdditionalChangeStats()
    {
        playerDataSO.maxHealth = playerDataSO.characterClass.baseHealth + (int)playerDataSO.PlayerRealmLevel * playerDataSO.characterClass.healthPerLevel + (playerDataSO.equippedItem != null ? playerDataSO.equippedItem.bonusHealth : 0) + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusHealth : 0);
        playerDataSO.currentAttack = playerDataSO.characterClass.baseAttack + (int)playerDataSO.PlayerRealmLevel * playerDataSO.characterClass.attackPerLevel + (playerDataSO.equippedItem != null ? playerDataSO.equippedItem.bonusAttack : 0) + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusAttack : 0);
        playerDataSO.currentDefense = playerDataSO.characterClass.baseDefense + (int)playerDataSO.PlayerRealmLevel * playerDataSO.characterClass.defensePerLevel + (playerDataSO.equippedItem != null ? playerDataSO.equippedItem.bonusDefense : 0) + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusDefense : 0);
        playerDataSO.currentAttackSpeed = playerDataSO.characterClass.attackSpeed + (playerDataSO.cultivationTechnique != null ? playerDataSO.cultivationTechnique.bonusAttackspeed : 0);
    }



    public void ChangeCharakterClass(RPGClassAsset characterClass)
    {
        playerDataSO.characterClass = characterClass;
        InitializeAdditionalChangeStats();
    }

    public void ChangeEquipedItem(RPGEquipmentAsset newItem)
    {
        playerDataSO.equippedItem = newItem;
        InitializeAdditionalChangeStats(); // Recalculate stats with new item
    }
    public void ChangeCultivationTechnique(RPGCultivationTechniqueAsset newTechnique)
    {
        playerDataSO.cultivationTechnique = newTechnique;
        InitializeAdditionalChangeStats(); // Recalculate stats with new item
    }


    public void TakeDamage(int damage)
    {
        playerDataSO.currentHealth -= damage;
        Debug.Log($"{this.gameObject.name} took damage: {damage}");

        if (playerDataSO.currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        // Destroy the player, death animation etc.
        Debug.Log("You died!");
        Destroy(gameObject);
    }

    public void AddHealth(int healingAmount)
    {
        if (playerDataSO.currentHealth + healingAmount <= playerDataSO.maxHealth)
        {
            playerDataSO.currentHealth += healingAmount;
            Debug.Log($"{this.gameObject.name} was healed for: {playerDataSO.currentHealth}");
        }
        else
        {
            playerDataSO.currentHealth = playerDataSO.maxHealth;
        }
    }
    public void AddExperience()
    {
        playerDataSO.currentSpiritualEnergy += playerDataSO.energyPerSecond * Time.deltaTime;
        if(playerDataSO.currentSpiritualEnergy >= playerDataSO.spiritualEnergyToNextLevel)
        {
            LevelUp();
        }
    }

    private void UpdateExperienceToNextLevel()
    {
        playerDataSO.spiritualEnergyToNextLevel += playerDataSO.PlayerRealmLevel * 100;
    }

    private void LevelUp()
    {
        playerDataSO.currentSpiritualEnergy -= playerDataSO.spiritualEnergyToNextLevel;
        playerDataSO.PlayerRealmLevel +=1;
        InitializeAdditionalChangeStats();
        UpdateExperienceToNextLevel();
        Debug.Log($"{playerDataSO.characterClass.className} leveled up to level {playerDataSO.currentSpiritualEnergy}!");
    }

    private void Update()
    {
        if(playerDataSO.currentGameState == PlayerDataSO.GameState.Play)
        {

            if(playerDataSO.characterClass != null)
            {
                InitializeAdditionalChangeStats();
            }
            
            AddExperience();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                UseSkill(playerDataSO.characterClass.skills[0]);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                UseSkill(playerDataSO.characterClass.skills[1]);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (playerDataSO.characterClass.skills[2])
                UseSkill(playerDataSO.characterClass.skills[2]);
            }

            if(Input.GetKeyDown(KeyCode.X)) 
            {
                PerformSpecialAbility();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Update Status");
                if(playerDataSO.characterClass)
                InitializeAdditionalChangeStats();
            }
            }
        }


    public void UseSkill(RPGSkillAsset skill)
    {
        if (playerDataSO.characterClass.skills.Contains(skill))
        {
            skill.UseSkill(this);
        }
        else
        {
            Debug.Log($"{playerDataSO.characterClass.className} does not know {skill.skillName}.");
        }
    }

    public GameObject AttackTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            // Debug.Log("Test" + hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }
        return null;
    }


    public void PerformSpecialAbility()
    {
        playerDataSO.characterClass.PerformSpecialAbility();
    }
}
