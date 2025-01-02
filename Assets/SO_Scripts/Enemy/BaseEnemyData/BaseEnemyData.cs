using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBaseEnemyData", menuName = "RPG/Enemy/CreateEnemyData")]
public class BaseEnemyData : ScriptableObject
{
    public string baseName;
    public int baseHealth;
    public float baseSpeed;
    public int baseDamage;
    public Sprite baseEnemySprite;
    public GameObject baseSpecialAttackPrefab;
}
