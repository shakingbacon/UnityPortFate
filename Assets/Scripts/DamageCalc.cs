using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour
{

    public static int DmgModifier(Stats user, Stats victim, Skill skill)
    {
        int dmg;
        if (skill.skillType == Skill.SkillType.Physical)
        {
            dmg = skill.skillDamage - victim.armor.totalAmount;
        }
        else
        {
            dmg = skill.skillDamage - victim.resist.totalAmount;
        }
        return dmg;
    }

    public static int HitChanceModifier(Stats user, Stats victim, Skill skill)
    {
        int hit = user.hitChance.totalAmount + skill.skillHitChance - victim.dodgeChance.totalAmount;
        return hit;
    }

    public static int CritChanceModifier(Stats user, Stats victim, Skill skill)
    {
        int crit = user.critChance.totalAmount + skill.skillCritChance;
        return crit;
    }

    public static void SkillAttack(Stats user, Stats victim, Skill skill)
    {
        // Mana Cost
        //StatUtilities.FindStatTotal(user, 6) =  StaticCoroutine.DoCoroutine()StatUtilities;
        
        // Hit Chance
        int hitChance = HitChanceModifier(user, victim, skill);
        bool ifHit = hitChance >= Random.Range(0, 101);
        if (ifHit)
        {
            ////// Damage
            int damage = DmgModifier(user, victim, skill);
            //int userLuck = StatUtilities.FindStatTotal(user, 3);
            //// bonus damage
            //if (userLuck != -1)
            //{
            //    damage += Random.Range(0, 11 + userLuck * 2);
            //}
            //else
            //{   // enemy's bonus dmg, we know enemy does not have luck so we use exp instead
            //    damage += Random.Range(0, 11 + StatUtilities.FindStatTotal(user, 19));
            //}
            // On Hit Effects

            // Crit Chance
            int critChance = CritChanceModifier(user, victim, skill);
            //// Check if Crit
            if (critChance >= Random.Range(0, 101))
            {
                //// Crit Multiplier
                int bonus = (user.critMulti.totalAmount + skill.skillCritMulti);
                float calcBonus = bonus / 100f;
                float putBonus = damage * calcBonus;
                damage = (int)(putBonus);
            }
            // if damage less than 0, damage = 0 so no heal
            if (damage < 0)
            {
                damage = 0;
            }
            ////// Damage Calculation
            // Regular Damage Calculation
            victim.health -= damage;
            // End
            if (skill.skillSoundID != -1)
            {
                SoundDatabase.PlaySound(skill.skillSoundID);
            }
            else
            {
                int soundID = Random.Range(1, 8);
                SoundDatabase.PlaySound(soundID);
            }
            //user.SimpleStatUpdate();
            BattleUI.UpdateEnemySliders();
            StatusBar.UpdateSliders();
        }
        else // missed
        {
            SoundDatabase.PlaySound(0);
        }
        // Crit Chance
        //bool ifHit = StatUtilities.
    }
    public static void Battle(Stats player, Stats enemy, Skill playeruseskill) // once we know what skill the player wants to use, we can start a battle.
    {
        // speed calculation goes here
        //
        SkillAttack(player, enemy, playeruseskill);
        SkillAttack(enemy, player, EnemyHolder.enemy.skills[Random.Range(0, EnemyHolder.enemy.skills.Count)]);
    }
}