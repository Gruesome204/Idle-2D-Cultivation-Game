using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllyHealingSkill", menuName = "RPG/Player/Create Skills/AllyHealingSkill")]
public class AllyHealingSkill: RPGSkillAsset
{
    public override void UseSkill(PlayerCharakter player)
    {
        base.UseSkill(player);

        GameObject target = player.AttackTarget();
        if (target != null && target.GetComponent<IHealable>() != null)
        {
            target.GetComponent<IHealable>().AddHealth(healingAmount);
            Debug.Log($"{player.name} healed {target.name}for {healingAmount}");

        }

    }
}
