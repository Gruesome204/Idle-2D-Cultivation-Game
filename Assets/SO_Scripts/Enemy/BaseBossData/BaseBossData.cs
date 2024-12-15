using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBaseBossData", menuName = "RPG/Enemy/Boss/CreateBossData")]
public class BaseBossData : ScriptableObject
{
    public string bossName;
    public int health;
    public float speed;
    public int damage;
    public Sprite bossSprite;
    public GameObject specialAttackPrefab;

}

