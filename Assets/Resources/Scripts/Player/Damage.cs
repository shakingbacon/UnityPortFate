using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage {

    public int Amount { get; set; }
    public int FinalAmount { get; set; }
    public bool DidCrit { get; set; }
    public bool DidHit { get; set; }

    public Damage()
    {
        Amount = 0;
        DidCrit = false;
        DidHit = false;
    }

    public Damage(int dmg)
    {
        this.Amount = dmg;
        this.DidCrit = false;
        this.DidHit = true;
    }

    public Damage(int dmg, bool crit)
    {
        this.Amount = dmg;
        this.DidCrit = crit;
        this.DidHit = true;
    }

    public Damage(bool hit)
    {
        this.DidHit = false;
    }
}
