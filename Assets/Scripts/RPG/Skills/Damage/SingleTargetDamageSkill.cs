using System.Collections;

using UnityEngine;


[CreateAssetMenu(fileName = "SingleTargetDamageSkill", menuName = "RPG/Player/Create Skills/SingleTargetDamageSkill")]
public class SingleTargetDamageSkill : RPGSkillAsset
{


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
            Debug.Log($"{player.name} dealt {damageAmount} damage to {target.name}!");

                //Debug.Log($"{player.playerName} dealt {damageAmount} damage to {target.name}!");
            }
        }
    }
}
