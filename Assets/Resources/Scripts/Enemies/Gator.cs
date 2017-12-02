using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Gator : Enemy
{
    public override void AwakeStuff()
    {
        ID = 0;
        Stats = new CharacterStats(
            5, 1, 5, 5,
            325, 100,
            5, 2,
            40, 10,
            95, 1, 4, 4);
        Knockback = 10f;
        Experience = 5;
        Cash = 25;
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>()
        {
            new LootDrop("Longsword", 15)
        };
        base.AwakeStuff();
    }
}
