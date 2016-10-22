using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStats : MonoBehaviour
{
    public Job job;
    private JobDatabase jobDatabase;
    public List<Stat> stats = new List<Stat>();



    void Start()
    {
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

            

        jobDatabase = GameObject.FindGameObjectWithTag("Job Database").GetComponent<JobDatabase>();
        for (int i = 0; i < jobDatabase.jobs.Count; i += 1)
        {
            if (jobDatabase.jobs[i].jobID == 3)
            {
                job = jobDatabase.jobs[i];
                break;
            }

        }
        StatsUpdate();
        HealHPFull();
        HealMPFull();
        StatsUpdate();
        //BuffStat(8, 30);
        //StatsUpdate();
    }
    void Update()
    {
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

    public void HealHPFull()
    {
        int hp = 0;
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 5)
            {
                hp = stats[i].totalAmount;
            }
        }
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 4)
            {

                stats[i].statAmount = hp;
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
            }
        }
        for (int i = 0; i < stats.Count; i += 1)
        {
            if (stats[i].statID == 6)
            {

                stats[i].statAmount = mp;
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
            case 3:// Freelancer Stat Updates
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
                        if (stats[i].statID == 11) // Hit rate
                        {
                            stats[i].statAmount = 90 + FindStatTotal(2) + FindStatTotal(3);
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 11) // Dodge rate
                        {
                            stats[i].statAmount = 1 + FindStatTotal(2) + FindStatTotal(3);
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                        if (stats[i].statID == 11) // Crit rate
                        {
                            stats[i].statAmount = 3 + FindStatTotal(2) + FindStatTotal(3);
                            stats[i].totalAmount = stats[i].statAmount + stats[i].buffedAmount;
                        }
                    }
                    break;
                }
        }
    }
}