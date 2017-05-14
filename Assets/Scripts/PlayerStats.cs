using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats: MonoBehaviour
{
    public static Stats stats = new Stats();
    public static List<int> specialPassives = new List<int>();

    public static void LevelUp()
    {
        stats.level += 1;
        stats.abilityPoints = 6;
        if (stats.level % 5 == 0)
        {
            stats.skillPoints += 2;

        }
        else
        {
            stats.skillPoints += 1;
        }
        stats.experience = 0;
        SetMaxExp();
        StatsUpdate();
        stats.HealFullHP();
        stats.HealFullMP();
        StatusBar.UpdateStatusBar();
    }

    public static void SetMaxExp()
    {
        stats.maxExperience = (9 + stats.level) * stats.level + 11 * stats.level;
    }

    public static void AddSpecialPassive(int id)
    {
        if (!specialPassives.Exists(anID => anID == id))
        {
            specialPassives.Add(id);
        }
    }

    public static void SpecialPassivesEffects()
    {
        foreach (int i in specialPassives)
        {
            switch (i)
            {
                case 12:
                    {
                        stats.maxHealth.totalAmount = 1;
                        stats.HealFullHP();
                        stats.strength.totalAmount = 1;
                        break;
                    }
                case 14:
                    {
                        List<int> skills = new List<int>(new int[] { 1, 2, 3, 4 });
                         foreach (int id in skills)
                        {
                            Skill skill = PlayerSkills.FindSkill(id);
                            skill.skillDamage = (int)(skill.skillDamage * (1f + (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                            skill.skillManaCost = (int)(skill.skillManaCost * (1f - (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                            switch (id)
                            {
                                case 1:
                                    {
                                        print(skill.skillStatusEff.GetStatusChance(0));
                                        skill.skillStatusEff.AddPercentStatusChance(0, PlayerSkills.FindSkill(14).skillDamage);
                                        skill.skillEffDesc = "Chance to inflict Burn: " + skill.skillStatusEff.GetStatusChance(0) + "%";
                                        print(skill.skillStatusEff.GetStatusChance(0));
                                        break;
                                    }
                                case 2:
                                    {
                                        skill.skillHitChance = (int)(skill.skillHitChance * (1f + (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                                        skill.skillEffDesc = "Hit Chance: +" + skill.skillHitChance + "%";
                                        break;
                                    }
                                case 3:
                                    {
                                        skill.skillCritChance = (int)(skill.skillCritChance*(1f + (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                                        skill.skillHitChance = (int)(skill.skillHitChance * (1f - (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                                        skill.skillCritMulti = (int)(skill.skillCritMulti * (1f + (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                                        skill.skillEffDesc = "Crit Chance: +" + skill.skillCritChance + "%, " +
                                        "Crit Multi: +" + skill.skillCritMulti + "%\n" + "Hit Chance: " + skill.skillHitChance + "%";
                                        break;
                                    }
                                case 4:
                                    {
                                        skill.skillStatusEff.AddPercentStatusChance(1, (PlayerSkills.FindSkill(14).skillDamage));
                                        skill.skillCritChance = (int)(skill.skillCritChance*(1f + (PlayerSkills.FindSkill(14).skillDamage / 100f)));
                                        skill.skillEffDesc = "Chance to Paralyze: " + skill.skillStatusEff.GetStatusChance(1) + "%\nCrit Chance: +" + skill.skillCritChance + "%";
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case 23:
                    {
                        PlayerSkills.FindSkill(1).skillStatusEff.AddNewStatusAndSet(1, 10);

                        break;
                    }
            }
        }
    }

    public static void StatsUpdate()
    {
        stats.SimpleStatUpdate();
        switch (stats.job.jobID)
        {
            case 0:// Mage Stat Updates
                {   // These are stats based off other stats
                    //
                    stats.maxHealth.baseAmount = 225 + stats.strength.totalAmount * 11 + stats.level * 32;
                    stats.maxHealth.totalAmount = stats.maxHealth.baseAmount + stats.maxHealth.buffedAmount;
                    //
                    stats.maxMana.baseAmount = 325 + stats.intelligence.totalAmount * 26 + stats.level * 60;
                    stats.maxMana.totalAmount = stats.maxMana.baseAmount + stats.maxMana.buffedAmount;
                    //
                    stats.physAtk.baseAmount = 35 + stats.strength.totalAmount * 3 + stats.level * 3;
                    stats.physAtk.totalAmount = stats.physAtk.baseAmount + stats.physAtk.buffedAmount;
                    //
                    stats.magicAtk.baseAmount = 60 + stats.intelligence.totalAmount * 6 + stats.level * 8;
                    stats.magicAtk.totalAmount = stats.magicAtk.baseAmount + stats.magicAtk.buffedAmount;
                    //
                    stats.armor.baseAmount = 10 + stats.strength.totalAmount * 4 + stats.level * 6;
                    stats.armor.totalAmount = stats.armor.baseAmount + stats.armor.buffedAmount;
                    //
                    stats.resist.baseAmount = 15 + stats.intelligence.totalAmount * 9 + stats.level * 10;
                    stats.resist.totalAmount = stats.resist.baseAmount + stats.resist.buffedAmount;
                    //
                    stats.hitChance.baseAmount = 90 + stats.agility.totalAmount/6 + stats.luck.totalAmount/5;
                    stats.hitChance.totalAmount = stats.hitChance.baseAmount + stats.hitChance.buffedAmount;
                    //
                    stats.dodgeChance.baseAmount = 1 + stats.agility.totalAmount/5 + stats.luck.totalAmount/4;
                    stats.dodgeChance.totalAmount = stats.dodgeChance.baseAmount + stats.dodgeChance.buffedAmount;
                    //
                    stats.critChance.baseAmount = 3 + stats.agility.totalAmount/5 + stats.luck.totalAmount/4;
                    stats.critChance.totalAmount = stats.critChance.baseAmount + stats.critChance.buffedAmount;
                    break;
                }
        }
    }

    public static void FullUpdate()
    {
        StatsUpdate();
        PlayerSkills.SkillUpdate();
        SpecialPassivesEffects();
        StatusBar.UpdateStatusBar();
    }
    public static string makeStatsPage()
    {
        string text = "";
        //string lv = "<color=#FFFFFF>LV: " + FindStat(16).totalAmount + "</color></size>\n";
        //text += lv;
        string strength = string.Format("<size=15><color=#C40D0D>Strength: {0} + {1} = {2}</color></size>", stats.strength.baseAmount, stats.strength.buffedAmount, stats.strength.totalAmount);
        //text += strength;
        string intel = string.Format("<size=15><color=#0000FF>  Intelligence: {0} + {1} = {2}</color></size>\n", stats.intelligence.baseAmount, stats.intelligence.buffedAmount, stats.intelligence.totalAmount);
        text += strength + intel;
        string agi = string.Format("<size=17><color=#00FF00>Agility: {0} + {1} = {2}</color></size>", stats.agility.baseAmount, stats.agility.buffedAmount, stats.agility.totalAmount);
        text += agi;
        string luk = string.Format("<size=17><color=#F3F335>  Luck: {0} + {1} = {2}</color></size>\n", stats.luck.baseAmount, stats.luck.buffedAmount, stats.luck.totalAmount);
        text += luk;
        string hp = string.Format("<size=14><color=#F00000>Max HP: {0} + {1} = {2}</color></size>", stats.maxHealth.baseAmount, stats.maxHealth.buffedAmount, stats.maxHealth.totalAmount);
        text += hp;
        string mp = string.Format("<size=14><color=#2BF2F2>  Max MP: {0} + {1} = {2}</color></size>\n", stats.maxMana.baseAmount, stats.maxMana.buffedAmount, stats.maxMana.totalAmount);
        text += mp;
        string atk = string.Format("<size=14><color=#EC2E2F>Phys Atk: {0} + {1} = {2}</color></size>", stats.physAtk.baseAmount, stats.physAtk.buffedAmount, stats.physAtk.totalAmount);
        text += atk;
        string matk = string.Format("<size=14><color=#2200FF>  Magic Atk: {0} + {1} = {2}</color></size>\n", stats.magicAtk.baseAmount, stats.magicAtk.buffedAmount, stats.magicAtk.totalAmount);
        text += matk;
        string armor = string.Format("<size=16><color=#000000>Defense: {0} + {1} = {2}</color></size>", stats.armor.baseAmount, stats.armor.buffedAmount, stats.armor.totalAmount);
        text += armor;
        string res = string.Format("<size=16><color=#04007f>  Resist: {0} + {1} = {2}</color></size>\n", stats.resist.baseAmount, stats.resist.buffedAmount, stats.resist.totalAmount);
        text += res;
        string hit = string.Format("<size=17><color=#2EEC61>Hit%: {0}% + {1}% = {2}%</color></size>\n", stats.hitChance.baseAmount, stats.hitChance.buffedAmount, stats.hitChance.totalAmount);
        text += hit;
        string dodge = string.Format("<size=17><color=#2EED8E>Dodge%: {0}% + {1}% = {2}%</color></size>\n", stats.dodgeChance.baseAmount, stats.dodgeChance.buffedAmount, stats.dodgeChance.totalAmount);
        text += dodge;
        string crit = string.Format("<size=17><color=#2EEDED>Crit% : {0}% + {1}% = {2}%</color></size>\n", stats.critChance.baseAmount, stats.critChance.buffedAmount, stats.critChance.totalAmount);
        text += crit;
        string multi = string.Format("<size=17><color=#DEAB71>Crit Multi: {0}% + {1}% = {2}%</color></size>\n", stats.critMulti.baseAmount, stats.critMulti.buffedAmount, stats.critMulti.totalAmount);
        text += multi;
        string dmgOut = string.Format("<size=17><color=#2EEC61>DMG Output: {0}% + {1}% = {2}%</color></size>\n", stats.dmgOutput.baseAmount, stats.dmgOutput.buffedAmount, stats.dmgOutput.totalAmount);
        text += dmgOut;
        string dmgTake = string.Format("<size=17><color=#2EEC61>DMG Taken: {0}% + {1}% = {2}%</color></size>\n", stats.dmgTaken.baseAmount, stats.dmgTaken.buffedAmount, stats.dmgTaken.totalAmount);
        text += dmgTake;
        string manaComs = string.Format("<size=17><color=#2EEC61>Mana Coms: {0}% + {1}% = {2}%</color></size>\n", stats.manaComs.baseAmount, stats.manaComs.buffedAmount, stats.manaComs.totalAmount);
        text += manaComs;
        return text;
    }
}

