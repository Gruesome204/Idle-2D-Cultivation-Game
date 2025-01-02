using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBaseStatsData", menuName = "RPG/BaseEnemyStatsData/CreateNewBaseStatsData")]
public class BaseStatsData : ScriptableObject
{
    [Header("Core Stats")]
    public string baseName;
    public int baseHealth;
    public int baseDamage;
    public float baseSpeed;
    public float basePhysicalArmor;
    public float baseMagicalArmor;

    [Header("Combat Stats")]
    public float baseAttackSpeed;
    public float baseCritChance;
    public float baseDamageMultiplier;
    public float baseAttackRange;

    [Header("Patrol")]
    public float baseDetectionRange;
    public float detectionTime;
    public float baseMoveRange;

    [Header("Resistances")]
    public float baseStatusResistance;
    public float fireResistance;
    public float waterResistance;
    public float earthResistance;
    public float lightningResistance;
    public float windResistance;

    [Header("Loot and XP")]
    public int experiencePoints;
    public float baseLootDropRate;

    [Header("Appearance")]
    public Sprite baseSprite;

    [Header("Abilities")]
    public GameObject baseSpecialAttackPrefab;
}
