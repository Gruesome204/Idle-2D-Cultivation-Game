using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RPG Class", menuName = "RPG/Player/Create Class")]
public class RPGClassAsset : ScriptableObject
{
    public string baseClassName;
    public int baseHealth;
    public int baseAttack;
    public int baseDefense;
    public float baseAttackSpeed;
    public string baseSpecialAbility;

    public int healthPerLevel;
    public int attackPerLevel;
    public int defensePerLevel;

    public List<RPGSkillAsset> skills;

public void PerformSpecialAbility()
    {
        Debug.Log($"{baseClassName} uses {baseSpecialAbility}!");
        
    }

}
