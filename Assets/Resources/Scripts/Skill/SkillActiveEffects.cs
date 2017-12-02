using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActiveEffects : MonoBehaviour
{
    // USED IN PlayerActivesController
    public static void GetSkillActiveEffect(int id)
    {
        switch (id)
        {
            case 1: { SkillActiveEvents.OnDamageSkillHitEnemy += Meditiate; break; }
        }
    }

    static Damage Meditiate(Damage damage)
    {
        if (damage.Type == Skill.SkillType.Magical)
        {
            damage.Amount *= 2;
            SkillActiveEvents.OnDamageSkillHitEnemy -= Meditiate;
            PlayerActivesController.Instance.EndActive(1);
        }
        return damage;
    }
}
