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

    public BaseStat(int baseval, string name, string desc)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseval;
        this.StatName = name;
        this.StatDescription = desc;
    }

    [JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetFullValue()
    {
        int FinalValue = 0;
        BaseAdditives.ForEach(x => FinalValue += x.BonusValue);

        FinalValue += BaseValue;
        return FinalValue;
    }

}
