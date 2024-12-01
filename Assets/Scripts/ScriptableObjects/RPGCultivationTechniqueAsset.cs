using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RPG CultivationTechnique", menuName = "RPG/Create CultivationTechnique")]
public class RPGCultivationTechniqueAsset : ScriptableObject
{
    public string techniqueName;

    public int bonusAttack;
    public int bonusHealth;
    public int bonusDefense;
    public float bonusAttackspeed;

    public int TechniqueIncreasePerLevel;

    public void PerformCultivationTechnique()
    {

    }
}
