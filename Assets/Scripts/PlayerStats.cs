using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static Stats playerStats;

    void Awake()
    {
        playerStats.job = JobDatabase.GetJob(0);
    }

    //void StatsUpdate()
    //{
    //    playerStats.
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
    //        stats.Add(new Stat("Max HP", 5));
    //        stats.Add(new Stat("MP", 6));
    //        stats.Add(new Stat("Max MP", 7));
    //        stats.Add(new Stat("Phys Atk", 8));
    //        stats.Add(new Stat("Magic Atk", 9));
    //        stats.Add(new Stat("Armor", 10));
    //        stats.Add(new Stat("Resist", 11));
    //        stats.Add(new Stat("Hit Rate", 12));
    //        stats.Add(new Stat("Dodge Rate", 13));
    //        stats.Add(new Stat("Crit Rate", 14));
    //        stats.Add(new Stat("Crit Multiplier", 15, 225));
    //        stats.Add(new Stat("LV", 16, 1));
    //        stats.Add(new Stat("AP", 17, 5));
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
    //        StatUtilities.FindStat(stats, 20).statAmount = 25;
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
    //        string hpBarText = (StatUtilities.FindStatTotal(stats, 4) * 1f).ToString() + " / " + (StatUtilities.FindStatTotal(stats, 5) * 1f).ToString();
    //        float healthValue = StatUtilities.FindStatTotal(stats, 4) * 1f / StatUtilities.FindStatTotal(stats, 5) * 1f;
    //        UpdateSliderFillWithText(healthBar, healthValue, "HP Amount", hpBarText);
    //        // MP BAR
    //        string mpBarText = (StatUtilities.FindStatTotal(stats, 6) * 1f).ToString() + " / " + (StatUtilities.FindStatTotal(stats, 7) * 1f).ToString();
    //        float manaValue = StatUtilities.FindStatTotal(stats, 6) * 1f / StatUtilities.FindStatTotal(stats, 7) * 1f;
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
    //                            stats[i].statAmount = 90 + StatUtilities.FindStatTotal(stats, 2) + StatUtilities.FindStatTotal(stats, 3);
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 13) // Dodge rate
    //                        {
    //                            stats[i].statAmount = 1 + StatUtilities.FindStatTotal(stats, 2) + StatUtilities.FindStatTotal(stats, 3);
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                        if (stats[i].statID == 14) // Crit rate
    //                        {
    //                            stats[i].statAmount = 3 + StatUtilities.FindStatTotal(stats, 2) + StatUtilities.FindStatTotal(stats, 3);
    //                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
    //                        }
    //                    }
    //                    break;
    //                }
    //        }
    //    }
    //    public string makeStatsPage()
    //    {
    //        string text = "";
    //        //string lv = "<color=#FFFFFF>LV: " + FindStat(16).totalAmount + "</color>\n";
    //        //text += lv;
    //        string strength = string.Format("<color=#C40D0D>Strength: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 0).statAmount, StatUtilities.FindStat(stats, 0).buffedAmount, StatUtilities.FindStat(stats, 0).totalAmount);
    //        text += strength;
    //        string intel = string.Format("<color=#0000FF>Intelligence: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 1).statAmount, StatUtilities.FindStat(stats, 1).buffedAmount, StatUtilities.FindStat(stats, 1).totalAmount);
    //        text += intel;
    //        string agi = string.Format("<color=#00FF00>Agility: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 2).statAmount, StatUtilities.FindStat(stats, 2).buffedAmount, StatUtilities.FindStat(stats, 2).totalAmount);
    //        text += agi;
    //        string luk = string.Format("<color=#F3F335>Luck: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 3).statAmount, StatUtilities.FindStat(stats, 3).buffedAmount, StatUtilities.FindStat(stats, 3).totalAmount);
    //        text += luk;
    //        string hp = string.Format("<color=#F00000>Max HP: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 5).statAmount, StatUtilities.FindStat(stats, 5).buffedAmount, StatUtilities.FindStat(stats, 5).totalAmount);
    //        text += hp;
    //        string mp = string.Format("<color=#2BF2F2>Max MP: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 7).statAmount, StatUtilities.FindStat(stats, 7).buffedAmount, StatUtilities.FindStat(stats, 7).totalAmount);
    //        text += mp;
    //        string atk = string.Format("<color=#EC2E2F>Physical Atk: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 8).statAmount, StatUtilities.FindStat(stats, 8).buffedAmount, StatUtilities.FindStat(stats, 8).totalAmount);
    //        text += atk;
    //        string matk = string.Format("<color=#2200FF>Magical Atk: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 9).statAmount, StatUtilities.FindStat(stats, 9).buffedAmount, StatUtilities.FindStat(stats, 9).totalAmount);
    //        text += matk;
    //        string def = string.Format("<color=#FFB811>Defense: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 10).statAmount, StatUtilities.FindStat(stats, 10).buffedAmount, StatUtilities.FindStat(stats, 10).totalAmount);
    //        text += def;
    //        string res = string.Format("<color=#04007F>Resist: {0} + {1} = {2}</color>\n", StatUtilities.FindStat(stats, 11).statAmount, StatUtilities.FindStat(stats, 11).buffedAmount, StatUtilities.FindStat(stats, 11).totalAmount);
    //        text += res;
    //        string hit = string.Format("<color=#2EEC61>Hit%: {0}% + {1}% = {2}%</color>\n", StatUtilities.FindStat(stats, 12).statAmount, StatUtilities.FindStat(stats, 12).buffedAmount, StatUtilities.FindStat(stats, 12).totalAmount);
    //        text += hit;
    //        string dodge = string.Format("<color=#2EED8E>Dodge%: {0}% + {1}% = {2}%</color>\n", StatUtilities.FindStat(stats, 13).statAmount, StatUtilities.FindStat(stats, 13).buffedAmount, StatUtilities.FindStat(stats, 13).totalAmount);
    //        text += dodge;
    //        string crit = string.Format("<color=#2EEDED>Crit% : {0}% + {1}% = {2}%</color>\n", StatUtilities.FindStat(stats, 14).statAmount, StatUtilities.FindStat(stats, 14).buffedAmount, StatUtilities.FindStat(stats, 14).totalAmount);
    //        text += crit;
    //        string multi = string.Format("<color=#DEAB71>Crit Multi: {0}% + {1}% = {2}%</color>\n", StatUtilities.FindStat(stats, 15).statAmount, StatUtilities.FindStat(stats, 15).buffedAmount, StatUtilities.FindStat(stats, 15).totalAmount);
    //        text += multi;
    //        string exp = string.Format("<color=#F3F335>Experience: {0} / {1}</color>\n", StatUtilities.FindStat(stats, 19).totalAmount, StatUtilities.FindStat(stats, 20).totalAmount);
    //        text += exp;
    //        return text;
    //    }
}

