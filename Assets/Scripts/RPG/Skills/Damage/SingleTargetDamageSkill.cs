using System.Collections;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "SingleTargetDamageSkill", menuName = "RPG/Player/Create Skills/SingleTargetDamageSkill")]
public class SingleTargetDamageSkill : RPGSkillAsset
{
    public override void UseSkill(PlayerCharakter player)
    {
        base.UseSkill(player);

        // Implement logic to apply damage to a target
        GameObject skillTarget = player.AttackTarget();

        if(skillTarget != null)
        {
            CheckIfDamagable(skillTarget,player);
            SetAggro(skillTarget,player);

                //Debug.Log($"{player.playerName} dealt {damageAmount} damage to {target.name}!");
        }
    }

    public void CheckIfDamagable(GameObject skillTarget, PlayerCharakter player)
    {
        if (skillTarget.GetComponent<IDamageable>() != null)
        {
            skillTarget.GetComponent<IDamageable>().TakeDamage(damageAmount);
            Debug.Log($"{player.name} dealt {damageAmount} damage to {skillTarget.name}!");
        }
    }

    public void SetAggro(GameObject skillTarget, PlayerCharakter player)
    {
        if (skillTarget.GetComponent<Aggro>() != null)
        {
            Aggro aggro = skillTarget.GetComponent<Aggro>();
            if (aggro != null)
            {
                aggro.AddAggro(player.gameObject, damageAmount * aggroMultiplier);
            }
        }
    }
}
