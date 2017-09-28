using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Gator : Enemy
{
    public override void AwakeStuff()
    {
        Stats = new CharacterStats(
            5, 1, 5, 5,
            100, 100,
            5, 2,
            40, 10,
            95, 5, 4, 4);
        Knockback = 100f;
        Experience = 20;
        Cash = 25;
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>()
        {
            new LootDrop("Longsword", 15)
        };
        base.AwakeStuff();
    }
}
