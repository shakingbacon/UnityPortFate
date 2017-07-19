using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {

    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStats(int strength, int physical, int armor, int attackSpeed)
    {
        stats = new List<BaseStat>()
        {
            new BaseStat(BaseStat.BaseStatType.Strength, strength, "Strength"),
            new BaseStat(BaseStat.BaseStatType.Physical, physical, "Physical"),
            new BaseStat(BaseStat.BaseStatType.Armor, armor, "Armor"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "AttackSpeed")
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
