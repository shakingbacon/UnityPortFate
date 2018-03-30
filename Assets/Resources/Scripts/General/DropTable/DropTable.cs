using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable
{
    public List<LootDrop> Loot { get; set; } = new List<LootDrop>();

    public Item GetDrop()
    {
        int roll = Random.Range(0, 101);
        int weightSum = 0;
        foreach(LootDrop drop in Loot)
        {
            weightSum += drop.Weight;
            if (roll < weightSum)
            {
                return ItemDatabase.Instance.GetItem(drop.ItemName);
            }
        }
        return null;
    }

}

public class LootDrop
{
    public string ItemName { get; set; }
    public int Weight { get; set; }

    public LootDrop(string itemName, int weight)
    {
        ItemName = itemName;
        Weight = weight;
    }
}
