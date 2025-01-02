using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBaseBossData", menuName = "RPG/Enemy/Boss/CreateBossData")]
public class BaseBossData : ScriptableObject
{
    public string baseName;
    public string baseTitle;
    public int baseHealth;
    public float baseSpeed;
    public int baseDamage;
    public float baseDetectionRange;
    public float baseAttackRange;
    public float baseMoveRange;
    public Sprite baseSprite;
    public GameObject baseSpecialAttackPrefab;
}

