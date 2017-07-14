using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
    public List<StatBonus> BaseAdditives { get; set; }

    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat (int baseval, string name, string desc)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseval;
        this.StatName = name;
        this.StatDescription = desc;
    }

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(statBonus);
    }

    public int GetCalcStatValue()
    {
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        FinalValue += BaseValue;
        return FinalValue;
    }

}
