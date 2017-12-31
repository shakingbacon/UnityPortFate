using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeatherHat : Armor
{
    public override void GiveStats()
    {
        base.GiveStats();
        Name = "Leather Hat";
        Description = "A basic hat for mages";

        Stats.Intelligence = 3;
        Stats.Armor = 14;
        Stats.Resist = 37;

        Cost = 450;
        ItemType = ArmorTypes.Head.ToString();
    }

}
