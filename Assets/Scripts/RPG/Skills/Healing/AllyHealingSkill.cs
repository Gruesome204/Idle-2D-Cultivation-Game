using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllyHealingSkill", menuName = "RPG/Player/Create Skills/AllyHealingSkill")]
public class AllyHealingSkill: RPGSkillAsset
{
    public override void UseSkill(PlayerCharakter player)
    {
        base.UseSkill(player);

        // Heal the user or a selected ally
        //player.AddHealth(10);
        //Debug.Log($"{player.characterClass.className} healed for {effectStrength} health.");
    }
}
