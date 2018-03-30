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
            case 1: { SkillEvents.OnSkillUse += Meditate; SoundDatabase.PlaySound(10); break; }
            case 2: { Player.OnTakeDamage += ManaGaurd; SoundDatabase.PlaySound(19); break; }
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
        if (skill.skillType == Skill.SkillType.Magical)
        {
            skill.DamageAmount *= 2;
            //print(skill.DamageAmount);
            PlayerActivesController.Instance.EndActive(1);
        }
        return skill;
    }

    static Damage ManaGaurd(Damage damage)
    {
        //SoundDatabase.PlaySound()
        if (player.CurrentMana - damage.DamageAmount >= 0)
        {
            player.CurrentMana -= damage.DamageAmount;
            damage.DamageAmount = 0;
        }
        else
        {
            damage.DamageAmount -= player.CurrentMana;
            player.CurrentMana = 0;
        }
        return damage;
    }
}
