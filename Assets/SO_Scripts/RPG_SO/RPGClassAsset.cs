using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RPG Class", menuName = "RPG/Player/Create Class")]
public class RPGClassAsset : ScriptableObject
{
    public string className;
    public int baseHealth;
    public int baseAttack;
    public int baseDefense;
    public float attackSpeed;
    public string specialAbility;

    public int healthPerLevel;
    public int attackPerLevel;
    public int defensePerLevel;

    public List<RPGSkillAsset> skills;

public void PerformSpecialAbility()
    {
        Debug.Log($"{className} uses {specialAbility}!");
        
    }

}
