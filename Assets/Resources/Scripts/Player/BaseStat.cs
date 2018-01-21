using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat
{
    public int BaseValue { get; set; }
    public List<int> Bonuses { get; set; }

    public int FinalValue { get { return GetFinalValue(); } }

    public StatType Type { get; set; }

    public enum StatType
    {
        Strength,
        Vitality,
        Intelligence,
        Wisdom,
        Agility,
        Perception,
        Luck,
        MaxHealth,
        MaxMana,
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


    public BaseStat(StatType type)
    {
        BaseValue = 0;
        Type = type;
        Bonuses = new List<int>();
    }

    public BaseStat(StatType type, int value)
    {
        BaseValue = value;
        Type = type;
        Bonuses = new List<int>();
    }
    public void Buff(int value)
    {
        Bonuses.Add(value);
        UIEventHandler.StatsChanged();
    }
    
    public void RemoveBuff(int value)
    {
        Bonuses.Remove(value);
        UIEventHandler.StatsChanged();
    }

    int GetFinalValue()
    {
        int finalValue = BaseValue;
        Bonuses.ForEach(value => finalValue += value);
        return finalValue;
    }


}
