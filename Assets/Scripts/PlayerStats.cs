using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats: MonoBehaviour
{
    public static Stats stats = new Stats();


    void Start()
    {
        stats.level = 1;
        stats.skillPoints = 1;
        stats.job = JobDatabase.GetJob(0);
        stats.strength.baseAmount = 3;
        stats.intelligence.baseAmount = 3;
        stats.agility.baseAmount = 3;
        stats.luck.baseAmount = 3;
        stats.maxExperience = 25;
        stats.critMulti.baseAmount = 225;
        stats.dmgOutput.baseAmount = 100;
        stats.dmgTaken.baseAmount = 100;
        stats.manaComs.baseAmount = 100;
        stats.cash = 100;
        stats.SimpleStatUpdate();
        StatsUpdate();
    }
    //void StatsUpdate()
    //{
    //    stats
    //}
    //    public string playerName;
    //    public Job job;
    //    private JobDatabase jobDatabase;
    //    public List<Stat> stats = new List<Stat>();
    //    public GUISkin skin;
    //    public Slider healthBar;
    //    public Slider manaBar;
    //    public Slider expBar;


    //    void Start()
    //    {

    //        // any stat id will always be the same eg. id = 0 is always str
    //        stats.Add(new Stat("Str", 0, 3));
    //        stats.Add(new Stat("Int", 1, 3));
    //        stats.Add(new Stat("Agi", 2, 3));
    //        stats.Add(new Stat("Luk", 3, 3));
    //        stats.Add(new Stat("HP", 4));
    //        stats.Add(new Stat("Max HP"stats);
    //        stats.Add(new Stat("MP", 6));
    //        stats.Add(new Stat("Max MP"stats);
    //        stats.Add(new Stat("Phys Atk", 8));
    //        stats.Add(new Stat("Magic Atk".magicAtk);
    //        stats.Add(new Stat("Armor", 10));
    //        stats.Add(new Stat("Resist", 11));
    //        stats.Add(new Stat("Hit Rate", 12));
    //        stats.Add(new Stat("Dodge Rate", 17));
    //        stats.Add(new Stat("Crit Rate", 14));
    //        stats.Add(new Stat("Crit Multiplier", 15, 225));
    //        stats.Add(new Stat("LV", 16, 1));
    //        stats.Add(new Stat("AP", 17stats);
    //        stats.Add(new Stat("SP", 18, 1));
    //        stats.Add(new Stat("EXP", 19));
    //        stats.Add(new Stat("Max EXP", 20));
    //        stats.Add(new Stat("Cash", 21, 100));
    //        jobDatabase = GameObject.FindGameObjectWithTag("Job Database").GetComponent<JobDatabase>();
    //        for (int i = 0; i < jobDatabase.jobs.Count; i += 1)
    //        {
    //            if (jobDatabase.jobs[i].jobID == 0)
    //            {
    //                job = jobDatabase.jobs[i];
    //                break;
    //            }
    //        }
    //        StatsUpdate();
    //        StatUtilities.HealHPFull(stats);
    //        StatUtilities.HealMPFull(stats);
    //        stats, 20).statAmount = 25;
    //        StatsUpdate();
    //        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Status Bar").transform.FindChild("Player Description").transform.FindChild("Name").GetComponent<Text>().text = playerName;
    //        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Status Bar").transform.FindChild("Player Description").transform.FindChild("Job").GetComponent<Text>().text = job.jobName;

    //        //BuffStat(8, 30);
    //        //StatsUpdate();
    //    }
    //    void Update()
    //    {
    //        if (Input.GetButtonDown("Test"))
    //        {

    //        }
    //        StatusBar();
    //        //StatsUpdate();
    //    }

    // Use this for initialization

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

