using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCalc : MonoBehaviour
{
    public static DamageCalc damageCalc;

    void Start()
    {
        damageCalc = gameObject.GetComponent<DamageCalc>();
    }

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

    public static void CheckSkillStatusEff(Stats victim, Skill skill)
    {
        foreach (Status status in skill.skillStatusEff.statusEffList)
        {
            if (status.statusChance > Random.Range(0, 101))
            {
                BattleUI.AddStatus(victim, status);
            }
        }
        BattleUI.UpdateAllStatusHolder(victim);
    }

    public static void ApplyStatusEff(Stats user, Stats victim, Status status)
    {
        switch (status.statusID)
        {
            case 0:
                {
                    SoundDatabase.PlaySound(35);
                    int damage = (victim.maxHealth.totalAmount / 10 - Random.Range(0, victim.maxHealth.totalAmount / 100))
                        + Random.Range(0, 10 + victim.maxHealth.totalAmount / 80);
                    victim.health -= damage;
                    BattleUI.TextAdd(victim, 26, "red", string.Format("took {0} burn damage", damage));
                    break;
                }
        }
        BattleUI.UpdateEnemySliders();
        StatusBar.UpdateSliders();
    }

    public static void SkillAttack(Stats user, Stats victim, Skill skill)
    {
        // Mana Cost
        BattleUI.TextAdd(user, 30, "#000000ff", "used " + skill.skillName);
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
            CheckSkillStatusEff(victim, skill);
            // Crit Chance
            int critChance = CritChanceModifier(user, victim, skill);
            //// Check if Crit
            bool didCrit = critChance >= Random.Range(0, 101);
            if (didCrit)
            {
                BattleUI.TextAdd(user, 30, "cyan", "critically striked!");
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
            // bonus
            else
            {
                damage += Random.Range(0, 15 + damage/10);
            }
            ////// Damage Calculation
            // Regular Damage Calculation
            if (user == PlayerStats.stats)
            {
                BattleUI.TextAdd(user, 25, "black", string.Format("deal {0} {1} damage", damage, skill.skillType));
            }
            else
            {
                BattleUI.TextAdd(user, 25, "black", string.Format("deals {0} {1} damage", damage, skill.skillType));
            }
            victim.health -= damage;
            // End
            if (didCrit)
            {
                SoundDatabase.PlaySound(11);
            }
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
        }
        else // missed
        {
            BattleUI.TextAdd(user, 30, "blue", "missed!");
            SoundDatabase.PlaySound(0);
        }
        BattleUI.UpdateEnemySliders();
        StatusBar.UpdateSliders();
        // Crit Chance
        //bool ifHit = StatUtilities.
    }
    public static IEnumerator StartBattle(Stats player, Stats enemy, Skill playeruseskill) // once we know what skill the player wants to use, we can start a battle.
    {
        // speed calculation goes here
        //
        bool enemyDead = false;
        BattleUI.NextTurn();
        BattleUI.ResetScrollsPosition();
        // disable all images as we need the skill page to be active
        SkillPageImagesOn(false);
        // disable all buttons (basically cant do anything
        GameManager.InvisibleWallOn(true);
        // reset text
        BattleUI.TextReset();
        // battle
        SkillAttack(player, enemy, playeruseskill);
        yield return new WaitForSeconds(1.1f);
        if (enemy.health <= 0)
        {
            enemyDead = true;
        }
        //ApplyStatusEff(player, enemy);
        //
        else
        {
            foreach (Status status in enemy.statuses)
            {
                ApplyStatusEff(player, enemy, status);
                yield return new WaitForSeconds(1.1f);
                if (enemy.health <= 0)
                {
                    enemyDead = true;
                    break;
                }
            }
        }
        if (enemyDead)
        {
                BattleUI.TextAdd(enemy, 25, "black", string.Format("has been defeated!"));
                yield return new WaitForSeconds(1.1f);
                Battle.EndBattle();
        }
        else
        {
            // enemy attack
            SkillAttack(enemy, player, EnemyHolder.enemy.skills[Random.Range(0, EnemyHolder.enemy.skills.Count)]);
            if (player.statuses.Count != 0)
            {
                yield return new WaitForSeconds(1.1f);
            }
            // check if player died
            foreach (Status status in player.statuses)
            {
                ApplyStatusEff(enemy, player, status);
                yield return new WaitForSeconds(1.1f);
            }
        }
        //
        SkillPageImagesOn(true);
        // return to normals
        GameManager.InvisibleWallOn(false);
        if (SkillPage.skillPage.gameObject.activeInHierarchy)
        {
            GameManager.OpenClosePage("Skill Page");
        }
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