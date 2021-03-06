﻿using System.Collections.Generic;
using UnityEngine;

public class Gator : Enemy
{
    protected override void Awake()
    {
        base.Awake();

        EnemyMovement.xOffSet = Random.Range(0.6f, 0.8f);
        EnemyMovement.yOffSet = Random.Range(0f, 0.9f);

        ID = 0;

        Stats.Strength = 5;
        Stats.Vitality = 3;
        Stats.Intelligence = 1;
        Stats.Wisdom = 1;
        Stats.Agility = 2;
        Stats.Perception = 2;
        Stats.Luck = 5;

        Stats.MaxHealth = 325;
        Stats.MaxMana = 100;

        Stats.Physical = 25;
        Stats.Magical = 5;

        Stats.Armor = 40;
        Stats.Resist = 10;

        Stats.Hit = 95;
        Stats.Dodge = 1;
        Stats.Crit = 4;

        Stats.AttackSpeed = 400;
        Knockback = 10f;
        Experience = 10;
        Cash = 25;
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>()
        {
            new LootDrop("Longsword", 15)
        };

        Stats.CurrentHealth = Stats.MaxHealth;
        Stats.CurrentMana = Stats.MaxMana;
        
    }
}
