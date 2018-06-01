using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryItemHolder : ItemHolder
{
    protected InventoryItemDescription desc;

    override protected void Start()
    {
        desc = InventoryController.Instance.InventoryPanel.GetComponentInChildren<InventoryPanel>().itemDesc;
        base.Start();
    }

    protected override void ClickAction()
    {
        PlayerEquipController.Instance.EquipItem(item);
        Destroy(gameObject);
        desc.gameObject.SetActive(false);
    }

    protected override void EnterAction()
    {
        if (item != null)
        {
            string action = "";
            if (item is Weapon) action = "Click to wield";
            if (item is Armor) action = "Click to equip";
            else if (item is Consumable) action = "Click to consume";
            desc.SetDescription(item, action, 125);
        }
    }

    protected override void ExitAction()
    {
        desc.gameObject.SetActive(false);
    }

}
