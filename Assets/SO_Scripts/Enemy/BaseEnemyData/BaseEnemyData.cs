using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBaseEnemyData", menuName = "RPG/Enemy/CreateEnemyData")]
public class BaseEnemyData : ScriptableObject
{
    public string enemyName;
    public int health;
    public float speed;
    public int damage;
    public Sprite enemySprite;
    public GameObject specialAttackPrefab;
}
