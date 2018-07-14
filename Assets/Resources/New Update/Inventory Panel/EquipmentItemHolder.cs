using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentItemHolder : InventoryItemHolder
{
    protected override void ClickAction(PointerEventData data)
    {
        if (item != null && data.button == PointerEventData.InputButton.Left)
        {
            PlayerEquipController.Instance.UnequipItem(item);
            desc.gameObject.SetActive(false);
        }
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
