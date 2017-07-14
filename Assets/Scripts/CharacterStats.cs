using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

    public List<BaseStat> stats = new List<BaseStat>();

    void Start()
    {
        stats.Add(new BaseStat(4, "Strength", "Your strength"));
        stats.Add(new BaseStat(4, "Health", "Your strength"));

    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat bonus in statBonuses)
        {
            stats.Find(x => x.StatName == bonus.StatName).AddStatBonus(new StatBonus(bonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat bonus in statBonuses)
        {
            stats.Find(x => x.StatName == bonus.StatName).RemoveStatBonus(new StatBonus(bonus.BaseValue));
        }
    }

}
