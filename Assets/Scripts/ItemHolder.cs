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
        if (!GameManager.inBattle)
        {
            Transform secondParent = gameObject.transform.parent.parent; // Inventory or equipemnt name
            Transform parent = gameObject.transform.parent; //slots
            if (!InvEq.isHoldingitem && item.itemID != -1)
            {
                SoundDatabase.PlaySound(18);
                //print("lift");
                if (secondParent.name == "Equipment")
                {
                    Equipment.RemoveItemStats(item);
                    PlayerImage.UpdateImage(parent.name, new Item(), false);
                    InvEq.UpdateHoldingItem(item, true);
                    InvEq.CleanSlot(secondParent, index);
                    gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Default Equip/" + parent.name);
                    gameObject.GetComponent<Image>().enabled = true;
                }
                else
                {
                    InvEq.UpdateHoldingItem(item, true);
                    InvEq.CleanSlot(secondParent, index);
                }
                InvEq.UpdateStatsDesc();
                MouseLeave();// no item will be in the slot so no desc
            }
            else if (InvEq.isHoldingitem && item.itemID == -1)
            {

                //print("put down"); put down weapon
                if (secondParent.name == "Equipment")
                {
                    if (Equipment.CheckEquip(parent))
                    {
                        if (GameManager.inTutorial)
                        {
                            Tutorial.equippedItem = true;
                        }
                        SoundDatabase.PlaySound(0);
                        //print("equip");
                        InvEq.InsertItem(secondParent, index, InvEq.holdingItem.itemID);
                        PlayerImage.UpdateImage(parent.name, item.itemName + CheckIsSecondHandWeapon(parent), true);
                        InvEq.UpdateHoldingItem(new Item(), false);
                        Equipment.AddItemStats(item);

                    }
                    else
                    {
                        SoundDatabase.PlaySound(33);
                    }
                }
                else
                {
                    SoundDatabase.PlaySound(0);
                    //print("regular");
                    InvEq.InsertItem(secondParent, index, InvEq.holdingItem.itemID);
                    InvEq.UpdateHoldingItem(new Item(), false);
                }
                InvEq.UpdateStatsDesc();
                MouseEnter();
            }
            else if (InvEq.isHoldingitem && item.itemID != -1)
            {
                //print("换");
                Item willBeReplaceItem = InvEq.GetItem(secondParent, index);
                if (secondParent.name == "Equipment")
                {
                    if (Equipment.CheckEquip(parent))
                    {
                        SoundDatabase.PlaySound(0);
                        InvEq.InsertItem(secondParent, index, InvEq.holdingItem.itemID);
                        PlayerImage.UpdateImage(parent.name, item.itemName + CheckIsSecondHandWeapon(parent), true);

                        Equipment.AddItemStats(item);
                        InvEq.UpdateHoldingItem(willBeReplaceItem);
                        Equipment.RemoveItemStats(willBeReplaceItem);

                    }
                    else
                    {
                        SoundDatabase.PlaySound(33);
                    }
                }
                else
                {
                    SoundDatabase.PlaySound(0);
                    InvEq.InsertItem(secondParent, index, InvEq.holdingItem.itemID);
                    InvEq.UpdateHoldingItem(willBeReplaceItem);
                }
                InvEq.UpdateStatsDesc();
                MouseEnter();
            }
        }
        // in battle, cant use inventory buttons
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }

    public static string CheckIsSecondHandWeapon(Transform parent)
    {
        string isSecondHandWeapon = "";
        if (parent.name == "Weapon&Shield" && InvEq.holdingItem.itemType == Item.ItemType.Weapon)
        {
            isSecondHandWeapon = "2";
        }
        return isSecondHandWeapon;
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
