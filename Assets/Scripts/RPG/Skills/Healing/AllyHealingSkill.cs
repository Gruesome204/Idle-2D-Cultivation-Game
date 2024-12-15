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
        Debug.Log(target.name);
        if (target != null && target.GetComponent<IHealable>() != null)
            target.GetComponent<IHealable>().AddHealth(healingAmount);
        //Debug.Log($"{player.playerName} dealt {damageAmount} damage to {target.name}!");
    
    }
}
