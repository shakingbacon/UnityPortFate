using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {

    public int Amount { get; set; }
    //public int FinalAmount { get; set; }
    public bool DidCrit { get; set; }
    public bool DidHit { get; set; }

    public float Knockback { get; set; }
    public float Stun { get; set; }

    public Damage()
    {
        Amount = 0;
        DidCrit = false;
        DidHit = false;
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
        DidHit = true;
        Amount = (baseDmg * 2 + Random.Range(2, 8));
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
        int critDamage = (int)(Amount * Random.Range(.5f, .75f));
        Amount += critDamage;
    }

}
