using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour {
    public Item item;
    Transform desc;

    void Start()
    {
        desc = GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").FindChild("Item Desc");
    }

    public void MouseClick()
    {
        if (!GameManager.inBattle)
        {
            Transform secondParent = gameObject.transform.parent.parent; // Inventory or equipemnt name
            Transform parent = gameObject.transform.parent; //slots
            if (item.itemType != Item.ItemType.Consumable)
            {
                if (!InvEq.isHoldingitem && item.itemID != -1)
                {
                    SoundDatabase.PlaySound(18);
                    //print("lift");
                    if (secondParent.name == "Equipment")
                    {
                        Equipment.RemoveItemStats(item);
                        PlayerImage.UpdateImage(parent.name, new Item(), false);
                        InvEq.UpdateHoldingItem(item, true);
                        InvEq.CleanSlot(secondParent, parent.GetSiblingIndex());
                        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Default Equip/" + parent.name);
                        gameObject.GetComponent<Image>().enabled = true;
                    }
                    else
                    {
                        InvEq.UpdateHoldingItem(item, true);
                        InvEq.CleanSlot(secondParent, parent.GetSiblingIndex());
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
                            InvEq.InsertItem(secondParent, parent.GetSiblingIndex(), InvEq.holdingItem.itemID);
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
                        InvEq.InsertItem(secondParent, parent.GetSiblingIndex(), InvEq.holdingItem.itemID);
                        InvEq.UpdateHoldingItem(new Item(), false);
                    }
                    InvEq.UpdateStatsDesc();
                    MouseEnter();
                }
                else if (InvEq.isHoldingitem && item.itemID != -1)
                {
                    //print("换");
                    Item willBeReplaceItem = InvEq.GetItem(secondParent, parent.GetSiblingIndex());
                    if (secondParent.name == "Equipment")
                    {
                        if (Equipment.CheckEquip(parent))
                        {
                            SoundDatabase.PlaySound(0);
                            InvEq.InsertItem(secondParent, parent.GetSiblingIndex(), InvEq.holdingItem.itemID);
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
                        InvEq.InsertItem(secondParent, parent.GetSiblingIndex(), InvEq.holdingItem.itemID);
                        InvEq.UpdateHoldingItem(willBeReplaceItem);
                    }
                    InvEq.UpdateStatsDesc();
                    MouseEnter();
                }
                // in battle, cant use inventory buttons
                else
                {
                    SoundDatabase.PlaySound(33);
                }
            }
            else
            {
                ItemDatabase.ActivateConsumable(item.itemID, parent.GetSiblingIndex());
                StatusBar.UpdateSliders();
            }
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
                int i = 0;
                for (; i < item.itemRegularText.Count; i++)
                {
                    desc.GetChild(i).GetComponent<Text>().text = item.itemRegularText[i];
                }
                desc.GetChild(4).GetComponent<Text>().text = item.itemStatText;
                //i = 0;
                //foreach (string text in item.itemStatText)
                //{
                //    desc.GetChild(4).GetChild(i).GetComponent<Text>().text = text;
                //    i++;
                //}
                //for (; i < desc.GetChild(4).childCount; i++)
                //{
                //    desc.GetChild(4).GetChild(i).GetComponent<Text>().text = "";
                //}
                GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").FindChild("Item Desc").gameObject.SetActive(true);
            }
        }
    }

    public void MouseLeave()
    {
        if (!InvEq.showStats)
        {
            GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").gameObject.SetActive(false);
        }
    }
}
