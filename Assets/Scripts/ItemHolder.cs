using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour {
    public int index;
    public Item item;
    Text desc;

    void Start()
    {
        desc = GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").GetComponentInChildren<Text>();
    }

    public void MouseClick()
    {
        Transform parent = gameObject.transform.parent.parent;
        // inventory/Equipment click
        if (!InvEq.showStats)
        {
            if (parent.name == "Inventory" || parent.name == "Equipment")
            {
                if (!InvEq.isHoldingitem && item.itemID != -1)
                {
                    print("lift");
                    InvEq.UpdateHoldingItem(item, true);
                    InvEq.CleanSlot(parent, index);
                    if (parent.name == "Equipment")
                    {
                        Equipment.RemoveItemStats(item);
                        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Default Equip/" + gameObject.transform.parent.name);
                        gameObject.GetComponent<Image>().enabled = true;
                    }
                }
                else if (InvEq.isHoldingitem && item.itemID == -1)
                {
                    print("put down");
                    InvEq.InsertItem(parent, index, InvEq.holdingItem.itemID);
                    InvEq.UpdateHoldingItem(new Item(), false);
                    if (parent.name == "Equipment")
                    {
                        Equipment.AddItemStats(item);
                    }
                }
                else if (InvEq.isHoldingitem && item.itemID != -1)
                {
                    print("换");
                    Item replaceItem = InvEq.GetItem(parent, index);
                    InvEq.InsertItem(parent, index, InvEq.holdingItem.itemID);
                    InvEq.UpdateHoldingItem(replaceItem);
                }
            }
        }

    }

    public void MouseEnter()
    {
        if (!InvEq.showStats)
        {
            if (item.itemID != -1)
            {
                desc.text = item.itemTooltip;
                GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(true);
            }
        }
    }

    public void MouseLeave()
    {
        if (!InvEq.showStats)
        {
            GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(false);
        }
    }
}
