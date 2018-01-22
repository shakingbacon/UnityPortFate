using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAxe : Axe {

    public override void GiveStats()
    {
        base.GiveStats();
        Stats.Physical = 100;
        Stats.AttackSpeed = 85;

        Knockback = 30f;
        StunDuration = 1f;

        bladeDamage = 2f;
        handleDamage = 0.5f;

        Description = "A longer, sharper blade.";
        Name = "Big Axe";

        Cost = 555;
    }
}
