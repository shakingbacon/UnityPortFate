using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {

    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int strength, int intel, int agi, int luck, int health, int mana, 
        int physical, int magical, int armor, int resist, int hit, int dodge, int crit, int attackSpeed)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Strength, strength, "Stength"),
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
        return this.stats.Find(x => x.StatType == stat);
    }



    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat bonus in statBonuses)
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

}
