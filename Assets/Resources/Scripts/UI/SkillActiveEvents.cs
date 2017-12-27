using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActiveEvents : MonoBehaviour {

    public delegate Damage SkillActiveDamageModifier(Damage skill);
    public static event SkillActiveDamageModifier OnDamageSkillHitEnemy;
    public static Damage DamageSkillHitEnemy(Damage skill)
    {
        if (OnDamageSkillHitEnemy != null)
        {
            Damage damage = new Damage(skill);
            damage = OnDamageSkillHitEnemy(damage);
            return damage;
        }
        return skill;

    }


}
