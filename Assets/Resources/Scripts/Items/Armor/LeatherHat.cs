using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherHat : Armor
{
    public override ArmorTypes Type { get { return ArmorTypes.Head; } }

    public override void GiveStats()
    {
        Name = "Leather Hat";
        Description = "A basic hat for mages";

        Stats.Intelligence = 3;
        Stats.Armor = 14;
        Stats.Resist = 37;

        Cost = 450;
    }

}
