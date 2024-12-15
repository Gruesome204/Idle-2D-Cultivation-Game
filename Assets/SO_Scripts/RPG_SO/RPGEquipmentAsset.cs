using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "RPG/Player/Create Equipment")]
public class RPGEquipmentAsset : ScriptableObject
{
    public string itemName;
    public int bonusHealth;
    public int bonusAttack;
    public int bonusDefense;
}
