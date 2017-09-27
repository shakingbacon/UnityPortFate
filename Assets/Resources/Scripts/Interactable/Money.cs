using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : PickupItem {

    protected override void Pickup()
    {
        switch (ItemDrop.ItemName)
        {
            case "Money_1":
                {
                    InventoryController.Instance.GiveMoney(Random.Range(10,25));
                    break;
                }
        }
    }
}
