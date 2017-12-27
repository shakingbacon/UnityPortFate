using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{

    public int Strength
    {
        get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Strength); }
        set { GetStat(BaseStat.BaseStatType.Strength).BaseValue = value; }
    }
    public int Intelligence
    {
        get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Intelligence); }
        set { GetStat(BaseStat.BaseStatType.Intelligence).BaseValue = value; }
    }
    public int Agility { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Agility); } set { GetStat(BaseStat.BaseStatType.Agility).BaseValue = value; } }
    public int Luck { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Luck); } set { GetStat(BaseStat.BaseStatType.Luck).BaseValue = value; } }
    public int Health { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Health); } set { GetStat(BaseStat.BaseStatType.Health).BaseValue = value; } }
    public int Mana { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Mana); } set { GetStat(BaseStat.BaseStatType.Mana).BaseValue = value; } }
    public int Physical { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Physical); } set { GetStat(BaseStat.BaseStatType.Physical).BaseValue = value; } }
    public int Magical { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Magical); } set { GetStat(BaseStat.BaseStatType.Magical).BaseValue = value; } }
    public int Armor { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Armor); } set { GetStat(BaseStat.BaseStatType.Armor).BaseValue = value; } }
    public int Resist { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Resist); } set { GetStat(BaseStat.BaseStatType.Resist).BaseValue = value; } }
    public int Hit { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Hit); } set { GetStat(BaseStat.BaseStatType.Hit).BaseValue = value; } }
    public int Dodge { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Dodge); } set { GetStat(BaseStat.BaseStatType.Dodge).BaseValue = value; } }
    public int Crit { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.Crit); } set { GetStat(BaseStat.BaseStatType.Crit).BaseValue = value; } }
    public int CritMulti { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.CritMulti); } set { GetStat(BaseStat.BaseStatType.CritMulti).BaseValue = value; } }
    public int AttackSpeed { get { return FindStatAndGetCalcValue(BaseStat.BaseStatType.AttackSpeed); } set { GetStat(BaseStat.BaseStatType.AttackSpeed).BaseValue = value; } }

    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int strength, int intel, int agi, int luck, int health, int mana,
        int physical, int magical, int armor, int resist, int hit, int dodge, int crit, int attackSpeed)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Strength, strength, "Strength"),
            new BaseStat(BaseStat.BaseStatType.Intelligence, intel, "Intelligence"),
            new BaseStat(BaseStat.BaseStatType.Agility, agi, "Agility"),
            new BaseStat(BaseStat.BaseStatType.Luck, luck, "Luck"),
            new BaseStat(BaseStat.BaseStatType.Health, health, "Health"),
            new BaseStat(BaseStat.BaseStatType.Mana, mana, "Mana"),
            new BaseStat(BaseStat.BaseStatType.Physical, physical, "Physical"),
            new BaseStat(BaseStat.BaseStatType.Magical, magical, "Magical"),
            new BaseStat(BaseStat.BaseStatType.Armor, armor, "Armor"),
            new BaseStat(BaseStat.BaseStatType.Resist, resist, "Reist"),
            new BaseStat(BaseStat.BaseStatType.Hit, hit, "Hit"),
            new BaseStat(BaseStat.BaseStatType.Dodge, dodge, "Dodge"),
            new BaseStat(BaseStat.BaseStatType.Crit, crit, "Crit"),
            new BaseStat(BaseStat.BaseStatType.CritMulti, 225, "CritMulti"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "AttackSpeed"),
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat bonus in statBonuses)
        {
            GetStat(bonus.StatType).AddStatBonus(new StatBonus(bonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat bonus in statBonuses)
        {
            GetStat(bonus.StatType).RemoveStatBonus(new StatBonus(bonus.BaseValue));
        }
    }

    int FindStatAndGetCalcValue(BaseStat.BaseStatType stat)
    {
        return GetStat(stat).GetFullValue();
    }
}
