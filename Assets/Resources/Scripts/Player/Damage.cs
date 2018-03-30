using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {

    // Damage Amount
    public int DamageAmount { get; set; } = 0;

    public bool DidCrit { get; set; } = false;
    public bool DidHit { get {  return HitChance < Random.Range(0, 101); } }

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


    public Damage(int baseDmg, float knockback=0, float stun =0)
    {
        //if (Random.Range(0f, 1f) < 0.5f)
        //    dmg.DidHit = false;
        //else
        DamageAmount = (baseDmg * 2 + Random.Range(2, 8));
        Knockback = knockback;
        Stun = stun;
        // Calculate Crit
        if (Random.value <= .1f)
        {
            CalculateCrit();
        }
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
        HitChance -= stats.Dodge;
        CheckCrit();
    }

}
