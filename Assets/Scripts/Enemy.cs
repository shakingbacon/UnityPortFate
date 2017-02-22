using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public int enemyID;
    public Sprite enemyIMG;
    //public string enemyDesc;
    public List<Stat> stats = new List<Stat>();

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int multi, int exp, int loot)
    {
        stats.Add(new Stat("HP", 4, hp));
        stats.Add(new Stat("MP", 6, mp));
        stats.Add(new Stat("Phys Atk", 8, phys));
        stats.Add(new Stat("Magic Atk", 9, mag));
        stats.Add(new Stat("Armor", 10, armor));
        stats.Add(new Stat("Resist", 11, resist));
        stats.Add(new Stat("Hit Rate", 12, hit));
        stats.Add(new Stat("Dodge Rate", 13, dodge));
        stats.Add(new Stat("Crit Rate", 14, crit));
        stats.Add(new Stat("Crit Multiplier", 15, multi));
        //stats.Add(new Stat("LV", 16, 1));
        stats.Add(new Stat("EXP", 19, exp));
        stats.Add(new Stat("Cash", 21, loot));
        /////////////
        enemyName = name;
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        //enemyDesc = desc;
    }

    public Enemy()
    {
        enemyID = -1;
    }

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
        //StatsUpdate();

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

    }
}
