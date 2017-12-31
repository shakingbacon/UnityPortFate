using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armor : Item
{
    public enum ArmorTypes
    {
        Head,
        Neck,
        Hands,
        Weapon,
        Body,
        Shield,
        Bottom,
        Boots,
        Necklace,
        Ring,
        Glyph
    }


    

    //protected override void Awake()
    //{
    //    GiveStats();
    //    //ItemType = ItemTypes.Armor;
    //}

    //public override void GiveStats()
    //{
    //    Stats = new Attributes();
    //}


}
