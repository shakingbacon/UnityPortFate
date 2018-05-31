using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Transform User { get; set; }

    // Damage Amount
    public int DamageAmount { get; set; } = 0;

    public bool DidCrit { get; set; } = false;
    public bool DidHit { get { return HitChance > Random.Range(0, 101); } }

    public int CritChance { get; set; } = 0;
    public int HitChance { get; set; } = 0;
    public float Knockback { get; set; } = 0;
    public float Stun { get; set; } = 0;

    public DamageType Type { get; set; }

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

    private void CalculateCrit()
    {
        int critDamage = (int)(DamageAmount * Random.Range(.5f, .75f));
        DamageAmount += critDamage;
    }

    bool CheckCrit()
    {
        if (CritChance > Random.Range(0, 101))
        {
            DidCrit = true;
            CalculateCrit();
            return true;
        }
        return false;
    }

    // shohuld be used first if ever using
    public void CalculateWithDefences(Attributes stats)
    {
        if (Type == DamageType.Physical) DamageAmount -= stats.Armor;
        else DamageAmount -= stats.Resist;
        if (DamageAmount < 0) DamageAmount = 0;
        HitChance -= stats.Dodge;
        CheckCrit();
    }

}
