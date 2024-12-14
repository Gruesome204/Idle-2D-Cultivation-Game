using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "SingleTargetDamageSkill", menuName = "RPG/Create Skills/SingleTargetDamageSkill")]
public class SingleTargetDamageSkill : RPGSkillAsset
{

    [SerializeField] private GlobalGameDataSO gameDataSO;

    public override void UseSkill(PlayerCharakter player)
    {
        base.UseSkill(player);

        // Implement logic to apply damage to a target, for example:
        // Assume user has a method to get their target
        GameObject target = player.AttackTarget();

        if (skillName == "PointAndClick")
        {
            if (target != null && target.GetComponent<IDamageable>() !=null)
            {
            target.GetComponent<IDamageable>().TakeDamage(damageAmount);
            //Debug.Log($"{player.playerName} dealt {damageAmount} damage to {target.name}!");
            }
        }
    }
}
