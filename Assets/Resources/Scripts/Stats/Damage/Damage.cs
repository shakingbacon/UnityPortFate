using UnityEngine;

public class Damage
{
    public enum DamageType
    {
        Physical,
        Magical
    }

    public Damage()
    {
    }

    public Damage(Damage dmg)
    {
        DamageAmount = dmg.DamageAmount;
        HitChance = dmg.HitChance;
        Knockback = dmg.Knockback;
        Stun = dmg.Stun;
    }

    public Transform User { get; set; }

    // Damage Amount
    public int DamageAmount { get; set; }

    public bool DidCrit { get; set; }
    public bool DidHit => HitChance > Random.Range(0, 101);

    public int CritChance { get; set; } = 0;
    public int HitChance { get; set; }
    public float Knockback { get; set; }
    public float Stun { get; set; }

    public DamageType Type { get; set; }

    private void CalculateCrit()
    {
        var critDamage = (int) (DamageAmount * Random.Range(.5f, .75f));
        DamageAmount += critDamage;
    }

    private bool CheckCrit()
    {
        if (CritChance <= Random.Range(0, 101)) return false;
        DidCrit = true;
        CalculateCrit();
        return true;

    }

    // shohuld be used first if ever using
    public void CalculateWithDefences(Attributes stats)
    {
        if (Type == DamageType.Physical)
        {
            DamageAmount -= stats.Armor;
        }
        else
        {
            DamageAmount -= stats.Resist;
        }

        if (DamageAmount < 0)
        {
            DamageAmount = 0;
        }
        HitChance -= stats.Dodge;
        CheckCrit();
    }
}