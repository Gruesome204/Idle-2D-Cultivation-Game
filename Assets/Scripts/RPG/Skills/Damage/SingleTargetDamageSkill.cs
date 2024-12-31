using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "SingleTargetDamageSkill", menuName = "RPG/Player/Create Skills/SingleTargetDamageSkill")]
public class SingleTargetDamageSkill : RPGSkillAsset
{
    public override void UseSkill(PlayerCharakter player)
    {
        base.UseSkill(player);

        // Implement logic to apply damage to a target, for example:
        // Assume user has a method to get their target
        GameObject skillTarget = player.AttackTarget();

        if (skillName == "PointAndClick")
        {
            if (skillTarget != null && skillTarget.GetComponent<IDamageable>() !=null)
            {
                skillTarget.GetComponent<IDamageable>().TakeDamage(damageAmount);
                Debug.Log($"{player.name} dealt {damageAmount} damage to {skillTarget.name}!");

                Aggro aggro = skillTarget.GetComponent<Aggro>();
                if (aggro != null)
                {
                    aggro.AddAggro(skillTarget.gameObject, damageAmount * aggroMultiplier);
                }
                //Debug.Log($"{player.playerName} dealt {damageAmount} damage to {target.name}!");
            }
        }
    }
}
