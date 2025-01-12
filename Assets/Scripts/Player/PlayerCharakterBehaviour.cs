using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Xml.Linq;
using Unity.VisualScripting;

public class PlayerCharakter : MonoBehaviour, IDamageable
{
    [SerializeField] private GlobalPlayerDataSO globalPlayerDataSO;
    [SerializeField] private GlobalGameDataSO globalGameDataSO;


    private void Start()
    {
        if (globalPlayerDataSO.characterClass != null)
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
    
        globalPlayerDataSO.maxHealth = globalPlayerDataSO.characterClass.baseHealth  + (int)globalPlayerDataSO.playerRealmLevel * globalPlayerDataSO.characterClass.healthPerLevel + (globalPlayerDataSO.equippedWeapon != null ? globalPlayerDataSO.equippedWeapon.bonusHealth : 0) + (globalPlayerDataSO.cultivationTechnique != null ? globalPlayerDataSO.cultivationTechnique.bonusHealth : 0);
        globalPlayerDataSO.currentHealth = globalPlayerDataSO.maxHealth;
        globalPlayerDataSO.currentAttack = globalPlayerDataSO.characterClass.baseAttack + (int)globalPlayerDataSO.playerRealmLevel * globalPlayerDataSO.characterClass.attackPerLevel + (globalPlayerDataSO.equippedWeapon != null ? globalPlayerDataSO.equippedWeapon.bonusAttack : 0) + (globalPlayerDataSO.cultivationTechnique != null ? globalPlayerDataSO.cultivationTechnique.bonusAttack : 0);
        globalPlayerDataSO.currentAttackSpeed = globalPlayerDataSO.characterClass.baseAttackSpeed + (globalPlayerDataSO.cultivationTechnique != null ? globalPlayerDataSO.cultivationTechnique.bonusAttackspeed : 0);
    }

    private void InitializeAdditionalChangeStats()
    {
        globalPlayerDataSO.maxHealth = globalPlayerDataSO.characterClass.baseHealth + (int)globalPlayerDataSO.playerRealmLevel * globalPlayerDataSO.characterClass.healthPerLevel + (globalPlayerDataSO.equippedWeapon != null ? globalPlayerDataSO.equippedWeapon.bonusHealth : 0) + (globalPlayerDataSO.cultivationTechnique != null ? globalPlayerDataSO.cultivationTechnique.bonusHealth : 0);
        globalPlayerDataSO.currentAttack = globalPlayerDataSO.characterClass.baseAttack + (int)globalPlayerDataSO.playerRealmLevel * globalPlayerDataSO.characterClass.attackPerLevel + (globalPlayerDataSO.equippedWeapon != null ? globalPlayerDataSO.equippedWeapon.bonusAttack : 0) + (globalPlayerDataSO.cultivationTechnique != null ? globalPlayerDataSO.cultivationTechnique.bonusAttack : 0);
        globalPlayerDataSO.currentAttackSpeed = globalPlayerDataSO.characterClass.baseAttackSpeed + (globalPlayerDataSO.cultivationTechnique != null ? globalPlayerDataSO.cultivationTechnique.bonusAttackspeed : 0);
    }



    public void ChangeCharakterClass(RPGClassAsset characterClass)
    {
        globalPlayerDataSO.characterClass = characterClass;
        InitializeAdditionalChangeStats();
    }

    public void ChangeEquipedItem(RPGEquipmentAsset newItem)
    {
        globalPlayerDataSO.equippedWeapon = newItem;
        InitializeAdditionalChangeStats(); // Recalculate stats with new item
    }
    public void ChangeCultivationTechnique(RPGCultivationTechniqueAsset newTechnique)
    {
        globalPlayerDataSO.cultivationTechnique = newTechnique;
        InitializeAdditionalChangeStats(); // Recalculate stats with new item
    }


    public void TakeDamage(int damage)
    {
        globalPlayerDataSO.currentHealth = Mathf.Max(globalPlayerDataSO.currentHealth - damage, 0);
        if (globalPlayerDataSO.currentHealth <= 0)
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
        if (globalPlayerDataSO.currentHealth + healingAmount <= globalPlayerDataSO.maxHealth)
        {
            globalPlayerDataSO.currentHealth += healingAmount;
            Debug.Log($"{this.gameObject.name} was healed for: {globalPlayerDataSO.currentHealth}");
        }
        else
        {
            globalPlayerDataSO.currentHealth = globalPlayerDataSO.maxHealth;
        }
    }


    private void Update()
    {
        if(globalGameDataSO.currentGameState == GlobalGameDataSO.GameState.Play)
        {
            if (globalPlayerDataSO.characterClass != null)
            {
                InitializeAdditionalChangeStats();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                UseSkill(globalPlayerDataSO.characterClass.skills[0]);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                UseSkill(globalPlayerDataSO.characterClass.skills[1]);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseSkill(globalPlayerDataSO.characterClass.skills[2]);
            }

            if(Input.GetKeyDown(KeyCode.X)) 
            {
                PerformSpecialAbility();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log("Update Status");
                InitializeAdditionalChangeStats();
            }
            }
        }


    public void UseSkill(RPGSkillAsset skill)
    {
        if (globalPlayerDataSO.characterClass.skills.Contains(skill))
        {
            skill.UseSkill(this);
        }
        else
        {
            Debug.Log($"{globalPlayerDataSO.characterClass.baseClassName} does not know {skill.skillName}.");
        }
    }

    public GameObject AttackTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit && hit.transform.gameObject.GetComponent<IDamageable>() != null)
        {
            // Debug.Log("Test" + hit.transform.gameObject.name);
            return hit.transform.gameObject;
        }
        return null;
    }

    


    public void PerformSpecialAbility()
    {
        globalPlayerDataSO.characterClass.PerformSpecialAbility();
    }
}
