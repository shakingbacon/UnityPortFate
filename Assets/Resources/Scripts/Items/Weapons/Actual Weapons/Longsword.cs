using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longsword : Sword
{

    protected override void Start()
    {
        Stats.Physical = 35;
        Stats.AttackSpeed = 2;

        Description = "A longer, sharper blade.";
        ItemName = name;
        
        ItemCost = 555;

        ItemType = ItemTypes.Weapon;
        WeaponType = WeaponTypes.Sword;

        base.Start();
    }

}
