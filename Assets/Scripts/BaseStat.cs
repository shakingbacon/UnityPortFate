using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat
{
    public enum BaseStatType
    {
        Strength,
        Intelligence,
        Agility,
        Luck,
        Health,
        Mana,
        Physical,
        Magical,
        Armor,
        Resist,
        Hit,
        Dodge,
        Crit,
        CritMulti,
        AttackSpeed
    }

    public List<StatBonus> BaseAdditives { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
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
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalcStatValue()
    {
        FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
    
        FinalValue += BaseValue;
        return FinalValue;
    }

}
