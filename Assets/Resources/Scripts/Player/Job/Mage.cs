
public class Mage : Attributes
{
    public Mage() : base()
    {
        JobName = "Mage";
        Strength = 3;
        Vitality = 3;
        Intelligence = 8;
        Wisdom = 8;
        Agility = 4;
        Perception = 7;
        Luck = 5;
        CritMulti = 225;
    }

    public Mage(Attributes stats) : this()
    {
        stats.AddBonusStatsToOther(this);
    }

    public override void UpdateStats(int level)
    {
        MaxHealth = 225 + Vitality * 28 + level * (32 + level);
        MaxMana = 475 + Wisdom * (35 + level) + level * (55 * level);
        Physical = 35 + Strength + level * 3;
        Magical = 70 + Intelligence * 8 + level * 9;

        Armor = 15 + Strength * 4 + Vitality * 7 + Agility * 2;
        Resist = 25 + Intelligence * 5 + Wisdom * 9;

        Hit = 90 + (int)(Agility / 6f + Perception / 4f + Luck / 5f);
        Dodge = 1 + (int)(Agility / 4f + Perception / 6f + Luck / 6f);
        Crit = 2 + (int)(Agility / 6f + Perception / 6f + Luck / 6f); ;
    }
}
