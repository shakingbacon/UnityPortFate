using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkillActiveEffects : MonoBehaviour
{
    public static Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    // USED IN PlayerActivesController
    // ALL ACTIVES GO HERE
    public static void GetSkillActiveEffect(int id)
    {
        switch (id)
        {
            case 1: { SkillEvents.OnSkillUse += Meditate; break; }
            case 2: { Player.OnTakeDamage += ManaGaurd; break; }
        }
    }

    public static void RemoveSkillActiveEffect(int id)
    {
        switch (id)
        {
            case 1: { SkillEvents.OnSkillUse -= Meditate; break; }
            case 2: { Player.OnTakeDamage -= ManaGaurd; break; }
        }
    }


    static Skill Meditate(Skill skill)
    {
        //print(skill.skillName);
        if (skill.skillType  == Skill.SkillType.Magical)
        {
            skill.DamageAmount *= 2;
            print(skill.DamageAmount);
            PlayerActivesController.Instance.EndActive(1);
        }
        return skill;
    }

    static int ManaGaurd(int damage)
    {
        if (player.CurrentMana - damage >= 0)
        {
            player.CurrentMana -= damage;
            damage = 0;
        }
        else
        {
            damage -= player.CurrentMana;
            player.CurrentMana = 0;
        }
        return damage;
    }
}
