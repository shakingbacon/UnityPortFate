using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Job job;
    private JobDatabase jobDatabase;
    public List<Stat> stats = new List<Stat>();
    public GUISkin skin;

    GameObject canvas;
    public Slider healthBar;
    public Slider manaBar;
    public Slider expBar;


    void Start()
    {

        // any stat id will always be the same eg. id = 0 is always str
        stats.Add(new Stat("Str", 0, 3));
        stats.Add(new Stat("Int", 1, 3));
        stats.Add(new Stat("Agi", 2, 3));
        stats.Add(new Stat("Luk", 3, 3));
        stats.Add(new Stat("HP", 4));
        stats.Add(new Stat("Max HP", 5));
        stats.Add(new Stat("MP", 6));
        stats.Add(new Stat("Max MP", 7));
        stats.Add(new Stat("Phys Atk", 8));
        stats.Add(new Stat("Magic Atk", 9));
        stats.Add(new Stat("Armor", 10));
        stats.Add(new Stat("Resist", 11));
        stats.Add(new Stat("Hit Rate", 12));
        stats.Add(new Stat("Dodge Rate", 13));
        stats.Add(new Stat("Crit Rate", 14));
        stats.Add(new Stat("Crit Multiplier", 15, 225));
        stats.Add(new Stat("LV", 16, 1));
        stats.Add(new Stat("AP", 17, 5));
        stats.Add(new Stat("SP", 18, 1));
        stats.Add(new Stat("EXP", 19));
        stats.Add(new Stat("Max EXP", 20));
        stats.Add(new Stat("Cash", 21, 100));
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        jobDatabase = GameObject.FindGameObjectWithTag("Job Database").GetComponent<JobDatabase>();
        for (int i = 0; i < jobDatabase.jobs.Count; i += 1)
        {
            if (jobDatabase.jobs[i].jobID == 0)
            {
                job = jobDatabase.jobs[i];
                break;
            }

        }
        StatsUpdate();
        HealHPFull();
        HealMPFull();
        FindStat(20).statAmount = 25;
        StatsUpdate();
        
        //BuffStat(8, 30);
        //StatsUpdate();
    }
    void Update()
    {
        if (Input.GetButtonDown("Test"))
        {
          
        }
        StatsUpdate();
    }
    void OnGUI()
    {
        StatusBar();
    }

    void StatusBar()
    {
        // HP BAR

        string hpBarText = (FindStatTotal(4) * 1f).ToString() + " / " + (FindStatTotal(5) * 1f).ToString();
        float healthValue = FindStatTotal(4) * 1f / FindStatTotal(5) * 1f;
        UpdateSliderFillWithText(healthBar, healthValue, "HP Amount", hpBarText);
        // MP BAR
        string mpBarText = (FindStatTotal(6) * 1f).ToString() + " / " + (FindStatTotal(7) * 1f).ToString();
        float manaValue = FindStatTotal(6) * 1f / FindStatTotal(7) * 1f;
        UpdateSliderFillWithText(manaBar, manaValue, "MP Amount", mpBarText);
        // EXP bar
        string expBarText = (FindStatTotal(19) * 1f).ToString() + " / " + (FindStatTotal(20) * 1f).ToString();
        float expValue = FindStatTotal(19) * 1f / FindStatTotal(20) * 1f;
        UpdateSliderFillWithText(expBar, expValue, "EXP Amount", expBarText);
    }

    void UpdateSliderFillWithText(Slider slider, float percentage, string textname, string text)
    {
        slider.value = percentage;
        slider.transform.FindChild(textname).GetComponent<Text>().text = text;
    }

    //void SliderWithText(Slider slider, Vector3 localPos, /*Vector2 size*/ string textname, int stat1, int stat2, string text)
    //{
    //    slider.value = FindStatTotal(stat1) * 1f / FindStatTotal(stat2) * 1f;
    //    slider.GetComponentInParent<RectTransform>().localPosition = localPos;
    //    //slider.GetComponent<RectTransform>().sizeDelta = size;
    //    Vector2 size = slider.GetComponent<RectTransform>().sizeDelta;
    //    Transform bartext = slider.transform.FindChild(textname);
    //    bartext.GetComponent<RectTransform>().localPosition = new Vector3(localPos.x, localPos.y - size.y / 4);
    //    bartext.GetComponent<RectTransform>().sizeDelta = size;
    //    bartext.GetComponent<Text>().text = text;
    //    bartext.GetComponent<Text>().fontSize = (int)(size.y * 0.4f);
    //}

    public Stat FindStat(int id)
    {
        Stat stat = stats[0];
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                stat = stats[i];
            }
        }
        return stat;
    }

    public int FindStatTotal(int id)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                int total = stats[i].totalAmount;
                return total;
            }
        }
        return 0;
    }

    public void IncreaseStat(int id, int amount)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                stats[i].statAmount += amount;
            }
        }
    }
    public void DecreaseStat(int id, int amount)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                stats[i].statAmount -= amount;
            }
        }
    }

    public void BuffStat(int id, int amount)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                stats[i].buffedAmount += amount;
            }
        }
    }
    public void DebuffStat(int id, int amount)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                stats[i].buffedAmount -= amount;
            }
        }
    }
    public void ResetStat(int id, int amount)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == id)
            {
                stats[i].buffedAmount = 0;
            }
        }
    }

    public void HealHP(int amount)
    {
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 4)
            {
                for (int j = 0; j < stats.Count; j += 1)
                {
                    if (stats[j].statID == 5)
                    {
                        if (stats[i].statAmount + amount > stats[j].totalAmount)
                        {
                            stats[i].statAmount = stats[j].totalAmount;
                        }
                        else
                        {
                            stats[i].statAmount += amount;
                        }
                        break;
                    }

                }
                break;
            }
        }
        StatsUpdate();
        
    }
    public void HealHPFull()
    {
        int hp = 0;
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 5)
            {
                hp = stats[i].totalAmount;
                break;
            }
        }
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 4)
            {

                stats[i].statAmount = hp;
                break;
            }
        }
    }
    public void HealMPFull()
    {
        int mp = 0;
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 7)
            {
                mp = stats[i].totalAmount;
                break;
            }
        }
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 6)
            {

                stats[i].statAmount = mp;
                break;
            }
        }
    }

    public void StatsUpdate()
    {
        for (int i = 0; i < stats.Count; i += 1)// need to update all stats so id doesnt matter
        {
            {
                stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
            }
        }
        switch (job.jobID)
        {
            case 0:// Mage Stat Updates
                {   // These are stats based off other stats
                    for (int i = 0; i < stats.Count; i += 1)
                    {
                        if (stats[i].statID == 5)// max HP
                        {
                            stats[i].statAmount = 225 + FindStatTotal(0) * 11 + FindStatTotal(16) * 32;
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 7) // max MP
                        {
                            stats[i].statAmount = 325 + FindStatTotal(1) * 26 + FindStatTotal(16) * 60;
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 8) // Phys Atk
                        {
                            stats[i].statAmount = 10 + FindStatTotal(0) * 3 + FindStatTotal(16) * 3;
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 9) // Magic Atk
                        {
                            stats[i].statAmount = 30 + FindStatTotal(1) * 6 + FindStatTotal(16) * 8;
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 10) // Armor
                        {
                            stats[i].statAmount = 10 + FindStatTotal(0) * 4 + FindStatTotal(16) * 6;
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 11) // Resist
                        {
                            stats[i].statAmount = 15 + FindStatTotal(1) * 9 + FindStatTotal(16) * 10;
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 12) // Hit rate
                        {
                            stats[i].statAmount = 90 + FindStatTotal(2) + FindStatTotal(3);
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 13) // Dodge rate
                        {
                            stats[i].statAmount = 1 + FindStatTotal(2) + FindStatTotal(3);
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 14) // Crit rate
                        {
                            stats[i].statAmount = 3 + FindStatTotal(2) + FindStatTotal(3);
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                    }
                    break;
                }
        }
    }
    public string makeStatsPage()
    {
        string text = "";
        //string lv = "<color=#FFFFFF>LV: " + FindStat(16).totalAmount + "</color>\n";
        //text += lv;
        string strength = string.Format("<color=#C40D0D>Strength: {0} + {1} = {2}</color>\n", FindStat(0).statAmount, FindStat(0).buffedAmount, FindStat(0).totalAmount);
        text += strength;
        string intel = string.Format("<color=#0000FF>Intelligence: {0} + {1} = {2}</color>\n", FindStat(1).statAmount, FindStat(1).buffedAmount, FindStat(1).totalAmount);
        text += intel;
        string agi = string.Format("<color=#00FF00>Agility: {0} + {1} = {2}</color>\n", FindStat(2).statAmount, FindStat(2).buffedAmount, FindStat(2).totalAmount);
        text += agi;
        string luk = string.Format("<color=#F3F335>Luck: {0} + {1} = {2}</color>\n", FindStat(3).statAmount, FindStat(3).buffedAmount, FindStat(3).totalAmount);
        text += luk;
        string hp = string.Format("<color=#F00000>Max HP: {0} + {1} = {2}</color>\n", FindStat(5).statAmount, FindStat(5).buffedAmount, FindStat(5).totalAmount);
        text += hp;
        string mp = string.Format("<color=#2BF2F2>Max MP: {0} + {1} = {2}</color>\n", FindStat(7).statAmount, FindStat(7).buffedAmount, FindStat(7).totalAmount);
        text += mp;
        string atk = string.Format("<color=#EC2E2F>Physical Atk: {0} + {1} = {2}</color>\n", FindStat(8).statAmount, FindStat(8).buffedAmount, FindStat(8).totalAmount);
        text += atk;
        string matk = string.Format("<color=#2200FF>Magical Atk: {0} + {1} = {2}</color>\n", FindStat(9).statAmount, FindStat(9).buffedAmount, FindStat(9).totalAmount);
        text += matk;
        string def = string.Format("<color=#FFB811>Defense: {0} + {1} = {2}</color>\n", FindStat(10).statAmount, FindStat(10).buffedAmount, FindStat(10).totalAmount);
        text += def;
        string res = string.Format("<color=#04007F>Resist: {0} + {1} = {2}</color>\n", FindStat(11).statAmount, FindStat(11).buffedAmount, FindStat(11).totalAmount);
        text += res;
        string hit = string.Format("<color=#2EEC61>Hit%: {0}% + {1}% = {2}%</color>\n", FindStat(12).statAmount, FindStat(12).buffedAmount, FindStat(12).totalAmount);
        text += hit;
        string dodge = string.Format("<color=#2EED8E>Dodge%: {0}% + {1}% = {2}%</color>\n", FindStat(13).statAmount, FindStat(13).buffedAmount, FindStat(13).totalAmount);
        text += dodge;
        string crit = string.Format("<color=#2EEDED>Crit% : {0}% + {1}% = {2}%</color>\n", FindStat(14).statAmount, FindStat(14).buffedAmount, FindStat(14).totalAmount);
        text += crit;
        string multi = string.Format("<color=#DEAB71>Crit Multi: {0}% + {1}% = {2}%</color>\n", FindStat(15).statAmount, FindStat(15).buffedAmount, FindStat(15).totalAmount);
        text += multi;
        string exp = string.Format("<color=#F3F335>Experience: {0} / {1}</color>\n", FindStat(19).totalAmount, FindStat(20).totalAmount);
        text += exp;
        return text;
    }
}

