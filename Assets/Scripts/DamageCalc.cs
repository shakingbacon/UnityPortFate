using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour {

    public static int DmgModifier(List<Stat> user, List<Stat> victim, Skill skill)
    {
        int dmg;
        if (skill.skillType == Skill.SkillType.Physical)
        {
            dmg = skill.skillDamage - StatUtilities.FindStatTotal(victim, 10);
        }
        else
        {
            dmg = skill.skillDamage - StatUtilities.FindStatTotal(victim, 11);
        }
        return dmg;
    }

    public static int HitChanceModifier(List<Stat> user, List<Stat> victim, Skill skill)
    {
        int hit = StatUtilities.FindStatTotal(user, 12) + skill.skillHitChance - StatUtilities.FindStatTotal(victim, 13);
        return hit;
    }
    
    public static int CritChanceModifier(List<Stat> user, List<Stat> victim, Skill skill)
    {
        int crit = StatUtilities.FindStatTotal(user, 14) + skill.skillCritChance;
        return crit;
    }

    public static void SkillAttack(List<Stat> user, List<Stat> victim, Skill skill)
    {
        // Mana Cost
        StatUtilities.IncreaseStat(user, 6, -(skill.skillManaCost));
        // Hit Chance
        int hitChance = HitChanceModifier(user, victim, skill);
        bool ifHit = hitChance >= Random.Range(0, 101);
        ///
        if (ifHit)
        {
            ////// Damage
            int damage = DmgModifier(user, victim, skill);
            int userLuck = StatUtilities.FindStatTotal(user, 3);
            // bonus damage
            if (userLuck != -1)
            {
                damage += Random.Range(0, 11 + userLuck * 2);
            }
            else
            {   // enemy's bonus dmg, we know enemy does not have luck so we use exp instead
                damage += Random.Range(0, 11 + StatUtilities.FindStatTotal(user, 19));
            }
            // On Hit Effects

            // Crit Chance
            int critChance = CritChanceModifier(user, victim, skill);
            //// Check if Crit
            if (critChance >= Random.Range(0, 101))
            {
                //// Crit Multiplier
                damage *= (StatUtilities.FindStatTotal(user, 15) + skill.skillCritMulti) / 100;
            }

            // if damage less than 0, damage = 0 so no heal
            if (damage < 0)
            {
                damage = 0;
            }
            ////// Damage Calculation

            // Regular Damage Calculation
            StatUtilities.IncreaseStat(victim, 4, -(damage));


        }

        // Crit Chance

        //bool ifHit = StatUtilities.
    }