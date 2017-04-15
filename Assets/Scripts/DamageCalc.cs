using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        user.mana -= skill.skillManaCost;

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
            bool didCrit = critChance >= Random.Range(0, 101);
            if (didCrit)
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
                if (didCrit)
                {
                    SoundDatabase.PlaySound(11);
                }
                SoundDatabase.PlaySound(skill.skillSoundID);
            }
            else
            {
                int soundID = Random.Range(1, 8);
                SoundDatabase.PlaySound(soundID);
            }
            //user.SimpleStatUpdate();
        }
        else // missed
        {
            SoundDatabase.PlaySound(0);
        }
        BattleUI.UpdateEnemySliders();
        StatusBar.UpdateSliders();
        // Crit Chance
        //bool ifHit = StatUtilities.
    }
    public static IEnumerator Battle(Stats player, Stats enemy, Skill playeruseskill) // once we know what skill the player wants to use, we can start a battle.
    {
        // speed calculation goes here
        //
        // disable all images as we need the skill page to be active
        SkillPageImagesOn(false);
        // disable all buttons (basically cant do anything
        GameManager.InvisibleWallOn(true);
        //
        SkillAttack(player, enemy, playeruseskill);
        yield return new WaitForSeconds(1.1f);
        SkillAttack(enemy, player, EnemyHolder.enemy.skills[Random.Range(0, EnemyHolder.enemy.skills.Count)]);
        SkillPageImagesOn(true);
        // return to normals
        GameManager.InvisibleWallOn(false);
        GameManager.OpenClosePage("Skill Page");
        //GameManager.OpenClosePage("Skill Page");
    }

    static void SkillPageImagesOn(bool yes)
    {
        for (int i = 0; i < SkillPage.skillPage.FindChild("Skills").transform.childCount; i += 1)
        {
            SkillPage.skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().enabled = yes;
        }
        SkillPage.skillPage.GetComponent<Image>().enabled = yes;
        SkillPage.learnedSkillsButton.gameObject.SetActive(yes);
        //SkillPage.skillPoints.gameObject.SetActive(yes);
        SkillPage.closeButton.gameObject.SetActive(yes);
        SkillPage.leftButton.gameObject.SetActive(yes);
        SkillPage.rightButton.gameObject.SetActive(yes);
        SkillPage.pageNum.gameObject.SetActive(yes);
    }
}