using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {

    // Damage Amount
    public int DamageAmount { get; set; }
    //public int FinalAmount { get; set; }
    public bool DidCrit { get; set; }

    public int HitChance { get; set; }
    public float Knockback { get; set; }
    public float Stun { get; set; }

    //public List<Skill.SkillElement> Element { get; set; }
         

    public Damage()
    {
        DamageAmount = 0;
        DidCrit = false;
    }

    public Damage(Damage dmg)
    {
        DamageAmount = dmg.DamageAmount;
        DidCrit = dmg.DidCrit;
        HitChance = dmg.HitChance;
        Knockback = dmg.Knockback;
        Stun = dmg.Stun;
    }
    //public Damage(int dmg)
    //{
    //    this.Amount = dmg;
    //    this.DidCrit = false;
    //    this.DidHit = true;
    //}

    //public Damage(int dmg, bool crit)
    //{
    //    this.Amount = dmg;
    //    this.DidCrit = crit;
    //    this.DidHit = true;
    //}

    //public Damage(bool hit)
    //{
    //    this.DidHit = false;
    //}

    //public Damage CalculateDamage(int baseDamage)
    //{

    //}

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
            DidCrit = true;
        }
    }

    private void CalculateCrit()
    {
        int critDamage = (int)(DamageAmount * Random.Range(.5f, .75f));
        DamageAmount += critDamage;
    }

}
