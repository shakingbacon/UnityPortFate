using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats: MonoBehaviour
{
    public static Stats stats = new Stats();

    void Start()
    {
        stats.job = JobDatabase.GetJob(0);
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
    //        stats.Add(new Stat("Dodge Rate", 13));
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

    //    void StatusBar()
    //    {
    //        // HP BAR
    //        string hpBarText = (StatUtilities.FindStatTotal(stats, 4) * 1f).ToString() + " / " + (StatUtilities.FindStatTotal(statsstats * 1f).ToString();
    //        float healthValue = StatUtilities.FindStatTotal(stats, 4) * 1f / StatUtilities.FindStatTotal(statsstats * 1f;
    //        UpdateSliderFillWithText(healthBar, healthValue, "HP Amount", hpBarText);
    //        // MP BAR
    //        string mpBarText = (StatUtilities.FindStatTotal(stats, 6) * 1f).ToString() + " / " + (StatUtilities.FindStatTotal(statsstats * 1f).ToString();
    //        float manaValue = StatUtilities.FindStatTotal(stats, 6) * 1f / StatUtilities.FindStatTotal(statsstats * 1f;
    //        UpdateSliderFillWithText(manaBar, manaValue, "MP Amount", mpBarText);
    //        // EXP bar
    //        string expBarText = (StatUtilities.FindStatTotal(stats, 19) * 1f).ToString() + " / " + (StatUtilities.FindStatTotal(stats, 20) * 1f).ToString();
    //        float expValue = StatUtilities.FindStatTotal(stats, 19) * 1f / StatUtilities.FindStatTotal(stats, 20) * 1f;
    //        UpdateSliderFillWithText(expBar, expValue, "EXP Amount", expBarText);
    //    }

    //    void UpdateSliderFillWithText(Slider slider, float percentage, string textname, string text)
    //    {
    //        slider.value = percentage;
    //        slider.transform.FindChild(textname).GetComponent<Text>().text = text;
    //    }

    //    public void StatsUpdate()
    //    {
    //        for (int i = 0; i < stats.Count; i += 1)// need to update all stats so id doesnt matter
    //        {
    //            {
    //                stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //            }
    //        }
    //        switch (job.jobID)
    //        {
    //            case 0:// Mage Stat Updates
    //                {   // These are stats based off other stats
    //                    for (int i = 0; i < stats.Count; i += 1)
    //                    {
    //                        if (stats[i].statID == 5)// max HP
    //                        {
    //                            stats[i].statAmount = 225 + StatUtilities.FindStatTotal(stats, 0) * 11 + StatUtilities.FindStatTotal(stats, 16) * 32;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 7) // max MP
    //                        {
    //                            stats[i].statAmount = 325 + StatUtilities.FindStatTotal(stats, 1) * 26 + StatUtilities.FindStatTotal(stats, 16) * 60;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 8) // Phys Atk
    //                        {
    //                            stats[i].statAmount = 35 + StatUtilities.FindStatTotal(stats, 0) * 3 + StatUtilities.FindStatTotal(stats, 16) * 3;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 9) // Magic Atk
    //                        {
    //                            stats[i].statAmount = 60 + StatUtilities.FindStatTotal(stats, 1) * 6 + StatUtilities.FindStatTotal(stats, 16) * 8;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 10) // Armor
    //                        {
    //                            stats[i].statAmount = 10 + StatUtilities.FindStatTotal(stats, 0) * 4 + StatUtilities.FindStatTotal(stats, 16) * 6;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 11) // Resist
    //                        {
    //                            stats[i].statAmount = 15 + StatUtilities.FindStatTotal(stats, 1) * 9 + StatUtilities.FindStatTotal(stats, 16) * 10;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 12) // Hit rate
    //                        {
    //                            stats[i].statAmount = 90 + StatUtilities.FindStatTotal(stats + StatUtilities.FindStatTotal(stats;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 13) // Dodge rate
    //                        {
    //                            stats[i].statAmount = 1 + StatUtilities.FindStatTotal(stats + StatUtilities.FindStatTotal(stats;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 14) // Crit rate
    //                        {
    //                            stats[i].statAmount = 3 + StatUtilities.FindStatTotal(stats + StatUtilities.FindStatTotal(stats;
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                    }
    //                    break;
    //                }
    //        }
    //    }
    public static string makeStatsPage()
    {
        string text = "<size=20>";
        //string lv = "<color=#FFFFFF>LV: " + FindStat(16).totalAmount + "</color>\n";
        //text += lv;
        string strength = string.Format("<color=#C40D0D>Strength: {0} + {1} = {2}</color>\n", stats.strength.statAmount, stats.strength.buffedAmount, stats.strength.totalAmount);
        text += strength;
        string intel = string.Format("<color=#0000FF>Intelligence: {0} + {1} = {2}</color>\n", stats.intelligence.statAmount, stats.intelligence.buffedAmount, stats.intelligence.totalAmount);
        text += intel;
        string agi = string.Format("<color=#00FF00>Agility: {0} + {1} = {2}</color>\n", stats.agility.statAmount, stats.agility.buffedAmount, stats.agility.totalAmount);
        text += agi;
        string luk = string.Format("<color=#F3F335>Luck: {0} + {1} = {2}</color>\n", stats.luck.statAmount, stats.luck.buffedAmount, stats.luck.totalAmount);
        text += luk;
        string hp = string.Format("<color=#F00000>Max HP: {0} + {1} = {2}</color>\n", stats.maxHealth.statAmount, stats.maxHealth.buffedAmount, stats.maxHealth.totalAmount);
        text += hp;
        string mp = string.Format("<color=#2BF2F2>Max MP: {0} + {1} = {2}</color>\n", stats.maxMana.statAmount, stats.maxMana.buffedAmount, stats.maxMana.totalAmount);
        text += mp;
        string atk = string.Format("<color=#EC2E2F>Physical Atk: {0} + {1} = {2}</color>\n", stats.physAtk.statAmount, stats.physAtk.buffedAmount, stats.physAtk.totalAmount);
        text += atk;
        string matk = string.Format("<color=#2200FF>Magical Atk: {0} + {1} = {2}</color>\n", stats.magicAtk.statAmount, stats.magicAtk.buffedAmount, stats.magicAtk.totalAmount);
        text += matk;
        string armor = string.Format("<color=#FFB811>Defense: {0} + {1} = {2}</color>\n", stats.armor.statAmount, stats.armor.buffedAmount, stats.armor.totalAmount);
        text += armor;
        string res = string.Format("<color=#04007f>Resist: {0} + {1} = {2}</color>\n", stats.resist.statAmount, stats.resist.buffedAmount, stats.resist.totalAmount);
        text += res;
        string hit = string.Format("<color=#2EEC61>Hit%: {0}% + {1}% = {2}%</color>\n", stats.hitChance.statAmount, stats.hitChance.buffedAmount, stats.hitChance.totalAmount);
        text += hit;
        string dodge = string.Format("<color=#2EED8E>Dodge%: {0}% + {1}% = {2}%</color>\n", stats.dodgeChance.statAmount, stats.dodgeChance.buffedAmount, stats.dodgeChance.totalAmount);
        text += dodge;
        string crit = string.Format("<color=#2EEDED>Crit% : {0}% + {1}% = {2}%</color>\n", stats.critChance.statAmount, stats.critChance.buffedAmount, stats.critChance.totalAmount);
        text += crit;
        string multi = string.Format("<color=#DEAB71>Crit Multi: {0}% + {1}% = {2}%</color>\n", stats.critMulti.statAmount, stats.critMulti.buffedAmount, stats.critMulti.totalAmount);
        text += multi;
        string dmgOut = string.Format("<color=#2EEC61>DMG Output: {0}% + {1}% = {2}%</color>\n", stats.dmgOutput.statAmount, stats.dmgOutput.buffedAmount, stats.dmgOutput.totalAmount);
        text += dmgOut;
        string dmgTake = string.Format("<color=#2EEC61>DMG Taken: {0}% + {1}% = {2}%</color>\n", stats.dmgTaken.statAmount, stats.dmgTaken.buffedAmount, stats.dmgTaken.totalAmount);
        text += dmgTake;
        string manaComs = string.Format("<color=#2EEC61>Mana Coms.: {0}% + {1}% = {2}%</color>\n", stats.manaComs.statAmount, stats.manaComs.buffedAmount, stats.manaComs.totalAmount);
        text += manaComs;
        string exp = string.Format("<color=#F3F335>Experience: {0} / {1}</color>\n", stats.experience, stats.maxExperience);
        text += exp + "</size>";


        return text;
    }
}

