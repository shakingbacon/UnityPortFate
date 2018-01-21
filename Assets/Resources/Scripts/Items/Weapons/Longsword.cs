using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longsword : Sword
{
    public override void GiveStats()
    {
        base.GiveStats();
        Stats.Physical = 35;
        Stats.AttackSpeed = 125;

        Knockback = 15f;
        StunDuration = 0.3f;

        TipDamage = 1.1f;
        BaseDamage = 1.4f;
        HiltDamage = 0.75f;

        Description = "A longer, sharper blade.";
        Name = "Longsword";

        Cost = 555;
    }
}
