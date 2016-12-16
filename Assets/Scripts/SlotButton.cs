using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotButton : MonoBehaviour {
    private bool mouseIsDown = false;
    public bool showTooltip;
    public bool draggingItem;
    public Item draggedItem;
    private int prevIndex;
    private List<Item> prevList;
    public string tooltip;
    public GUISkin skin;
    public PlayerStats playerStats;
    public Inventory inventory;
    public Equipment equipment;

    void Start()
    {
        inventory = inventory.GetComponent<Inventory>();
        equipment = equipment.GetComponent<Equipment>();
    }

    public void MatrixSlot(float col, float row, List<Item> slots, List<Item> items, float x, float y, float xdis, float ydis)
    {
        float xStart = 0;
        float yStart = 0;
        int index = 0;
        for (int column = 0; column < col; column += 1)
        {
            for (int ro = 0; ro < row; ro += 1)
            {
                slots[index] = items[index];
                ////////////////////////////////////////////////////////////
                //Button(slots[index], items[index], x + xStart, y + yStart, 60, 60);
                Rect slotRect = new Rect(x + xStart, y + yStart, 60, 60);
                Event e = Event.current;
                // Draw Box
                if (mouseIsDown && slotRect.Contains(Event.current.mousePosition))
                {
                    GUI.Box(slotRect, "", skin.GetStyle("Slot Pressed"));
                }
                else
                {
                    GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                }
                // Inside box
                if (slotRect.Contains(Event.current.mousePosition))
                {
                    // mouse press
                    if (e.button == 0 && e.type == EventType.MouseDown)
                    {
                        mouseIsDown = true;
                    }
                }
                // Check if mouse Up
                if (e.type == EventType.MouseUp)
                {
                    mouseIsDown = false;
                }
                if (slots[index].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[index].itemImg);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        showTooltip = true;
                        CreateTooltip(slots[index]);
                        // lift up an item and drag
                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            prevList = items;
                            prevIndex = index;
                            draggedItem = slots[index];
                            items[index] = new Item();
                        }
                        // right click in inventory
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (slots[index].itemType == Item.ItemType.Consumable)
                            {
                                UseConsumable(slots[index], index, true);
                            }
                        }
                    }
                }
                else // if slot has no item
                {
                    if (tooltip == "")
                    {
                        showTooltip = false;
                    }
                }
                // Let go of item
                bool allowedToDrop = true;
                if (slotRect.Contains(Event.current.mousePosition))
                {
                    if (e.type == EventType.mouseUp && draggingItem)
                    {
                        // EQUIPMENT CHECKERS
                        if (items == equipment.equipment)
                        {
                            allowedToDrop = false;
                            if (index == 0 && draggedItem.itemType == Item.ItemType.Weapon) // index 0 is weapon slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 1 && draggedItem.armorType == Item.ArmorType.Hands) // index 1 is Hands slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 2 && draggedItem.armorType == Item.ArmorType.Shield) // index 2 is shield slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 3 && draggedItem.itemType == Item.ItemType.Accessory) // index 3 is acc slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 4 && draggedItem.itemType == Item.ItemType.Accessory) // index 4 is acc slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 5 && draggedItem.armorType == Item.ArmorType.Head) // index 5 is Head slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 6 && draggedItem.armorType == Item.ArmorType.Body) // index 6 is Body slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 7 && draggedItem.armorType == Item.ArmorType.Bottom) // index 7 is Bottom slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 8 && draggedItem.armorType == Item.ArmorType.Boots) // index 8 is Boots slot
                            {
                                allowedToDrop = true;
                            }
                            else if (index == 9 && draggedItem.itemType == Item.ItemType.Accessory) // index 9 is Acc slot
                            {
                                allowedToDrop = true;
                            }
                        }
                        if (allowedToDrop)
                        {
                            prevList[prevIndex] = items[index];
                            items[index] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                    }
                }
                ////////////////////////////////////////////////////////////
                yStart += ydis;
                index += 1;
            }
            xStart += xdis;
            yStart = 0;
        }
        
    }

    private void UseConsumable(Item item, int slot, bool deleteItem)
    {
        switch (item.itemID)
        {
            case 1000:
                {
                    playerStats.HealHP(100);
                    break;
                }
        }
        /*
        if (deleteItem)
        {
            inventory[slot] = new Item();
        }*/
    }

    string CreateTooltip(Item item)
    {   // NAME
        tooltip = "<size=26><color=#000000>" + item.itemName + "</color></size>\n";
        // ITEM TYPE
        if (item.itemType == Item.ItemType.Accessory)
        {
            tooltip += "(<color=#FFABAB>" + item.itemType.ToString() + "</color>)\n";
        }
        else if (item.itemType == Item.ItemType.Armor)
        {
            if (item.armorType == Item.ArmorType.Head)
            {
                tooltip += "(<color=#3BCD58>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Body)
            {
                tooltip += "(<color=#F7CA34>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Bottom)
            {
                tooltip += "(<color=#F78F34>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Shield)
            {
                tooltip += "(<color=#E57E18>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Boots)
            {
                tooltip += "(<color=#FF8000>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Hands)
            {
                tooltip += "(<color=#18E418>" + item.armorType.ToString() + "</color>)\n";
            }
        }
        else if (item.itemType == Item.ItemType.Weapon)
        {
            if (item.weaponType == Item.WeaponType.Sword)
            {
                tooltip += "(<color=#FF0000>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Axe)
            {
                tooltip += "(<color=#0000CB>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Dagger)
            {
                tooltip += "(<color=#8B00A1>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Shuriken)
            {
                tooltip += "(<color=#900000>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Wand)
            {
                tooltip += "(<color=#914800>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Staff)
            {
                tooltip += "(<color=#463811>" + item.weaponType.ToString() + "</color>)\n";

            }
        }
        else if (item.itemType == Item.ItemType.Consumable)
        {
            tooltip += "(<color=#81CAE1>" + item.itemType.ToString() + "</color>)\n";
        }
        // COST
        tooltip += "<color=#ECF32A>COST: $" + item.itemCost.ToString() + "</color>\n";
        // DESCRIPTION
        tooltip += item.itemDesc + "\n";
        // BONUS STATS
        List<int> values = new List<int>
            (new int[] {item.itemBonusStr, item.itemBonusInt, item.itemBonusAgi, item.itemBonusLuk,
            item.itemBonusHP, item.itemBonusMP, item.itemBonusAtk, item.itemBonusMAtk,
            item.itemBonusDef, item.itemBonusResist,
            item.itemBonusHit, item.itemBonusDodge, item.itemBonusCrit, item.itemBonusCritMulti });
        List<string> desc = new List<string>
            (new string[] {"<color=#C40D0D>STR: " , "<color=#0000FF>INT: ", "<color=#00FF00>AGI: ",
                "<color=#F3F335>LUK: ", "<color=#F00000>HP: ", "<color=#2BF2F2>MP: ",
                "<color=#EC2E2E>ATK: ", "<color=#2200FF>MATK: ", "<color=#FFB811>DEF: ",
            "<color=#04007F>RES: ", "<color=#2EEC61>HIT: ", "<color=#2EED8E>DODGE: ",
                "<color=#2EEDED>CRIT: ", "<color=#DEAB71>CRITMULTI: "});
        for (int i = 0; i < values.Count; i+=2){
            string string1 = "";
            string string2 = "";
            if (values[i] != 0)
            {
                if (values[i] > 0)
                {
                    string1 = desc[i] + "+" + values[i].ToString() + "</color>    ";
                }
                else
                {
                    string1 = desc[i] + values[i].ToString()+ "</color>    ";
                }
            }
            if (values[i+1] != 0)
            {
                if (values[i+1] > 0)
                {
                    string2 = desc[i + 1] + "+" + values[i + 1].ToString() + "</color>";
                }
                else
                {
                    string2 = desc[i + 1] + values[i + 1].ToString() + "</color>";
                }
            }
            if (string1 != "" && string2 != "")
            {
                tooltip += string1 + string2 + "\n";
            } else if (string1 != "" && string2 == "")
            {
                tooltip += string1 + "\n";
            } else if (string1 == "" && string2 != "")
            {
                tooltip += string2 + "\n";
            }
        }
        return tooltip;
    }
}
