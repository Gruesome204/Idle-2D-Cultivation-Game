using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Xml.Linq;

public class PlayerCharakter : MonoBehaviour
{
    [SerializeField] private GlobalGameDataSO globalGameDataSO;

    private void Start()
    {
        if(globalGameDataSO.characterClass != null)
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
    
        globalGameDataSO.maxHealth = globalGameDataSO.characterClass.baseHealth  + (int)globalGameDataSO.PlayerRealmLevel * globalGameDataSO.characterClass.healthPerLevel + (globalGameDataSO.equippedItem != null ? globalGameDataSO.equippedItem.bonusHealth : 0) + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusHealth : 0);
        globalGameDataSO.currentHealth = globalGameDataSO.maxHealth;
        globalGameDataSO.currentAttack = globalGameDataSO.characterClass.baseAttack + (int)globalGameDataSO.PlayerRealmLevel * globalGameDataSO.characterClass.attackPerLevel + (globalGameDataSO.equippedItem != null ? globalGameDataSO.equippedItem.bonusAttack : 0) + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusAttack : 0);
        globalGameDataSO.currentDefense = globalGameDataSO.characterClass.baseDefense + (int)globalGameDataSO.PlayerRealmLevel * globalGameDataSO.characterClass.defensePerLevel + (globalGameDataSO.equippedItem != null ? globalGameDataSO.equippedItem.bonusDefense : 0) + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusDefense : 0);
        globalGameDataSO.currentAttackSpeed = globalGameDataSO.characterClass.attackSpeed + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusAttackspeed : 0);
    }

    private void InitializeAdditionalChangeStats()
    {
        globalGameDataSO.maxHealth = globalGameDataSO.characterClass.baseHealth + (int)globalGameDataSO.PlayerRealmLevel * globalGameDataSO.characterClass.healthPerLevel + (globalGameDataSO.equippedItem != null ? globalGameDataSO.equippedItem.bonusHealth : 0) + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusHealth : 0);
        globalGameDataSO.currentAttack = globalGameDataSO.characterClass.baseAttack + (int)globalGameDataSO.PlayerRealmLevel * globalGameDataSO.characterClass.attackPerLevel + (globalGameDataSO.equippedItem != null ? globalGameDataSO.equippedItem.bonusAttack : 0) + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusAttack : 0);
        globalGameDataSO.currentDefense = globalGameDataSO.characterClass.baseDefense + (int)globalGameDataSO.PlayerRealmLevel * globalGameDataSO.characterClass.defensePerLevel + (globalGameDataSO.equippedItem != null ? globalGameDataSO.equippedItem.bonusDefense : 0) + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusDefense : 0);
        globalGameDataSO.currentAttackSpeed = globalGameDataSO.characterClass.attackSpeed + (globalGameDataSO.cultivationTechnique != null ? globalGameDataSO.cultivationTechnique.bonusAttackspeed : 0);
    }



    public void ChangeCharakterClass(RPGClassAsset characterClass)
    {
        globalGameDataSO.characterClass = characterClass;
        InitializeAdditionalChangeStats();
    }

    public void ChangeEquipedItem(RPGEquipmentAsset newItem)
    {
        globalGameDataSO.equippedItem = newItem;
        InitializeAdditionalChangeStats(); // Recalculate stats with new item
    }
    public void ChangeCultivationTechnique(RPGCultivationTechniqueAsset newTechnique)
    {
        globalGameDataSO.cultivationTechnique = newTechnique;
        InitializeAdditionalChangeStats(); // Recalculate stats with new item
    }


    public void TakeDamage(int damage)
    {
        globalGameDataSO.currentHealth -= damage;
        Debug.Log($"{this.gameObject.name} took damage: {damage}");

        if (globalGameDataSO.currentHealth <= 0)
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
        if (globalGameDataSO.currentHealth + healingAmount <= globalGameDataSO.maxHealth)
        {
            globalGameDataSO.currentHealth += healingAmount;
            Debug.Log($"{this.gameObject.name} was healed for: {globalGameDataSO.currentHealth}");
        }
        else
        {
            globalGameDataSO.currentHealth = globalGameDataSO.maxHealth;
        }
    }
    private void Update()
    {
        if(globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Play)
        {
           

            if (globalGameDataSO.characterClass != null)
            {
                InitializeAdditionalChangeStats();
            }
              

            if (Input.GetKeyDown(KeyCode.Q))
            {
                UseSkill(globalGameDataSO.characterClass.skills[0]);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                UseSkill(globalGameDataSO.characterClass.skills[1]);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (globalGameDataSO.characterClass.skills[2])
                UseSkill(globalGameDataSO.characterClass.skills[2]);
            }

            if(Input.GetKeyDown(KeyCode.X)) 
            {
                PerformSpecialAbility();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Update Status");
                if(globalGameDataSO.characterClass)
                InitializeAdditionalChangeStats();
            }
            }
        }


    public void UseSkill(RPGSkillAsset skill)
    {
        if (globalGameDataSO.characterClass.skills.Contains(skill))
        {
            skill.UseSkill(this);
        }
        else
        {
            Debug.Log($"{globalGameDataSO.characterClass.className} does not know {skill.skillName}.");
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
        globalGameDataSO.characterClass.PerformSpecialAbility();
    }
}
