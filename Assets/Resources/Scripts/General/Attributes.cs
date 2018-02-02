using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
    public string JobName { get; set; }
    public List<BaseStat> Stats = new List<BaseStat>();
    // Stat
    public int Strength { get { return FindStat(BaseStat.StatType.Strength).FinalValue; } set { FindStat(BaseStat.StatType.Strength).BaseValue = value; } }
    public int Vitality { get { return FindStat(BaseStat.StatType.Vitality).FinalValue; } set { FindStat(BaseStat.StatType.Vitality).BaseValue = value; } }
    public int Intelligence { get { return FindStat(BaseStat.StatType.Intelligence).FinalValue; } set { FindStat(BaseStat.StatType.Intelligence).BaseValue = value; } }
    public int Wisdom { get { return FindStat(BaseStat.StatType.Wisdom).FinalValue; } set { FindStat(BaseStat.StatType.Wisdom).BaseValue = value; } }
    public int Agility { get { return FindStat(BaseStat.StatType.Agility).FinalValue; } set { FindStat(BaseStat.StatType.Agility).BaseValue = value; } }
    public int Perception { get { return FindStat(BaseStat.StatType.Perception).FinalValue; } set { FindStat(BaseStat.StatType.Perception).BaseValue = value; } }
    public int Luck { get { return FindStat(BaseStat.StatType.Luck).FinalValue; } set { FindStat(BaseStat.StatType.Luck).BaseValue = value; } }
    public int MaxHealth { get { return FindStat(BaseStat.StatType.MaxHealth).FinalValue; } set { FindStat(BaseStat.StatType.MaxHealth).BaseValue = value; } }
    public int MaxMana { get { return FindStat(BaseStat.StatType.MaxMana).FinalValue; } set { FindStat(BaseStat.StatType.MaxMana).BaseValue = value; } }
    public int Physical { get { return FindStat(BaseStat.StatType.Physical).FinalValue; } set { FindStat(BaseStat.StatType.Physical).BaseValue = value; } }
    public int Magical { get { return FindStat(BaseStat.StatType.Magical).FinalValue; } set { FindStat(BaseStat.StatType.Magical).BaseValue = value; } }
    public int Armor { get { return FindStat(BaseStat.StatType.Armor).FinalValue; } set { FindStat(BaseStat.StatType.Armor).BaseValue = value; } }
    public int Resist { get { return FindStat(BaseStat.StatType.Resist).FinalValue; } set { FindStat(BaseStat.StatType.Resist).BaseValue = value; } }
    public int Hit { get { return FindStat(BaseStat.StatType.Hit).FinalValue; } set { FindStat(BaseStat.StatType.Hit).BaseValue = value; } }
    public int Dodge { get { return FindStat(BaseStat.StatType.Dodge).FinalValue; } set { FindStat(BaseStat.StatType.Dodge).BaseValue = value; } }
    public int Crit { get { return FindStat(BaseStat.StatType.Crit).FinalValue; } set { FindStat(BaseStat.StatType.Crit).BaseValue = value; } }
    public float CritMulti { get { return FindStat(BaseStat.StatType.CritMulti).FinalValue / 100f; } set { FindStat(BaseStat.StatType.CritMulti).BaseValue = (int)value; } }
    public float AttackSpeed { get { return FindStat(BaseStat.StatType.AttackSpeed).FinalValue / 100f; } set { FindStat(BaseStat.StatType.AttackSpeed).BaseValue = (int)value; } }
    public float HealthRegen { get { return FindStat(BaseStat.StatType.HealthRegen).FinalValue / 100f; } set { FindStat(BaseStat.StatType.HealthRegen).BaseValue = (int)value; } }
    public float ManaRegen { get { return FindStat(BaseStat.StatType.ManaRegen).FinalValue / 100f; } set { FindStat(BaseStat.StatType.ManaRegen).BaseValue = (int)value; } }


    public int CurrentHealth { get; set; }
    public int CurrentMana { get; set; }

    public Attributes()
    {
        Stats = new List<BaseStat>();
        int i = 0;
        for (i = 0; i < 20; i++)
        {
            Stats.Add(new BaseStat((BaseStat.StatType)i));
        }
        //Stats.Add(new BaseStat((BaseStat.StatType)0));
        //Stats.Add(new BaseStat((BaseStat.StatType)1));
        //Stats.Add(new BaseStat((BaseStat.StatType)2));
        //Stats.Add(new BaseStat((BaseStat.StatType)3));
        //Stats.Add(new BaseStat((BaseStat.StatType)4));
        //Stats.Add(new BaseStat((BaseStat.StatType)5));
        //Stats.Add(new BaseStat((BaseStat.StatType)6));
        //Stats.Add(new BaseStat((BaseStat.StatType)7));
        //Stats.Add(new BaseStat((BaseStat.StatType)8));
        //Stats.Add(new BaseStat((BaseStat.StatType)9));
        //Stats.Add(new BaseStat((BaseStat.StatType)10));
        //Stats.Add(new BaseStat((BaseStat.StatType)11));
        //Stats.Add(new BaseStat((BaseStat.StatType)12));
        //Stats.Add(new BaseStat((BaseStat.StatType)13));
        //Stats.Add(new BaseStat((BaseStat.StatType)14));
        //Stats.Add(new BaseStat((BaseStat.StatType)15));
        //Stats.Add(new BaseStat((BaseStat.StatType)16));
        //Stats.Add(new BaseStat((BaseStat.StatType)17));
    }

    public BaseStat FindStat(BaseStat.StatType type)
    {
        return (Stats.Find(stat => stat.Type == type));
    }

    public void BuffStat(BaseStat.StatType type, int value)
    {
        FindStat(type).Buff(value);
    }

    //public void BuffStat(BaseStat stat)
    //{
    //    FindStat(stat.Type).Buff(stat.FinalValue);
    //}

    public void RemoveBuffStat(BaseStat.StatType type, int value)
    {
        FindStat(type).RemoveBuff(value);
    }

    public void AddStatsToOther(Attributes mortal)
    {
        foreach (BaseStat stat in Stats)
        {
            if (stat.FinalValue != 0)
            {
                //Debug.Log(string.Format("Type: {0}, Value: {1}", stat.Type, stat.FinalValue));
                mortal.BuffStat(stat.Type, stat.FinalValue);
            }
        }

    }

    public void RemoveStatsFromOther(Attributes mortal)
    {
        foreach (BaseStat stat in Stats)
        {
            if (stat.FinalValue != 0)
            {
                //Debug.Log(string.Format("Type: {0}, Value: {1}", stat.Type, stat.FinalValue));
                mortal.RemoveBuffStat(stat.Type, stat.FinalValue);
            }
        }
    }

    public void AddBonusStatsToOther(Attributes other)
    {
        foreach (BaseStat stat in Stats)
        {
            if (stat.Bonuses.Count > 0)
            {
                stat.Bonuses.ForEach(aStat => other.BuffStat(stat.Type, aStat));
            }
        }
    }


    public virtual void UpdateStats(int level)
    {

    }
}
