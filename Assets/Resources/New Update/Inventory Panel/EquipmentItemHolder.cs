using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItemHolder : InventoryItemHolder
{
    protected override void ClickAction()
    {
        PlayerEquipController.Instance.UnequipItem(item);
    }

    protected override void EnterAction()
    {
        if (item != null)
        {
            string action = "";
            if (item is Weapon) action = "Click to unwield";
            if (item is Armor) action = "Click to unequip";
            desc.SetDescription(item, action, -125);
        }
    }

}
