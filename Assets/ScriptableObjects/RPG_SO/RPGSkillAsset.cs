using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public abstract class RPGSkillAsset : ScriptableObject
{
    public string skillName;
    public string description;
    public int manaCost;
    public float cooldown;
    public int damageAmount;
    public int healingAmount;
    public virtual void UseSkill(PlayerCharakter character)
    {

    }




}
