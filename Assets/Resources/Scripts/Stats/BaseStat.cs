using System.Collections.Generic;

public class BaseStat
{
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
        AttackSpeed,
        HealthRegen,
        ManaRegen
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

    public int BaseValue { get; set; }
    public List<int> Bonuses { get; set; }
    public int FinalValue => GetFinalValue();
    public StatType Type { get; set; }

    public void Buff(int value)
    {
        Bonuses.Add(value);
        //UIEventHandler.StatsChanged();
    }

    public void RemoveBuff(int value)
    {
        Bonuses.Remove(value);
        //UIEventHandler.StatsChanged();
    }

    private int GetFinalValue()
    {
        var finalValue = BaseValue;
        Bonuses.ForEach(value => finalValue += value);
        return finalValue;
    }
}