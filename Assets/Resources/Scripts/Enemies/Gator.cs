using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Gator : Enemy
{
    protected override void Awake()
    {
        ID = 0;

        Strength = 5;
        Vitality = 3;
        Intelligence = 1;
        Wisdom = 1;
        Perception = 2;
        Luck = 5;

        MaxHealth = 325;
        MaxMana = 100;

        Physical = 10;
        Magical = 5;

        Armor = 40;
        Resist = 10;

        Hit = 95;
        Dodge = 1;
        Crit = 4;

        AttackSpeed = 4;
        Knockback = 10f;
        Experience = 5;
        Cash = 25;
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>()
        {
            new LootDrop("Longsword", 15)
        };
        base.Awake();
    }
}
