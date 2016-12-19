using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotButton : MonoBehaviour {
    private bool mouseIsDown = false;
    public bool showTooltip;
    public bool draggingItem;
    public Item hoveringCurrentItem;
    public Item draggedItem;
    private int prevIndex;
    private List<Item> prevList;
    public GUISkin skin;
    public PlayerStats playerStats;
    public Inventory inventory;
    public Equipment equipment;

    void Start()
    {
        inventory = inventory.GetComponent<Inventory>();
        equipment = equipment.GetComponent<Equipment>();
    }

    public void MatrixSlot(float col, float row, List<Item> items, float x, float y, float xdis, float ydis)
    {
        float xStart = 0;
        float yStart = 0;
        int index = 0;
        for (int column = 0; column < col; column += 1)
        {
            for (int ro = 0; ro < row; ro += 1)
            {
                //slots[index] = items[index];
                ////////////////////////////////////////////////////////////
                //Button(slots[index], items[index], x + xStart, y + yStart, 60, 60);
                Rect slotRect = new Rect(x + xStart, y + yStart, 60, 60);
                Event e = Event.current;
                // Draw Box
                if (mouseIsDown && slotRect.Contains(Event.current.mousePosition))
                {
                    // show picture where to put for equipment
                    if (items == equipment.equipment && equipment.equipment[index].itemID == -1)
                    {
                        GUI.Box(slotRect, equipment.defaultImage[index], skin.GetStyle("Slot Pressed"));
                    }
                    else
                    {
                        GUI.Box(slotRect, "", skin.GetStyle("Slot Pressed"));
                    }
                }
                else
                {
                    // show picture where to put for equipment
                    if (items == equipment.equipment && equipment.equipment[index].itemID == -1)
                    {
                        GUI.Box(slotRect, equipment.defaultImage[index], skin.GetStyle("Slot"));
                    }
                    else
                    {
                        GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                    }
                }
                // Inside box
                if (slotRect.Contains(Event.current.mousePosition))
                {
                    // mouse press
                    if (e.button == 0 && e.type == EventType.MouseDown)
                    {
                        mouseIsDown = true;
                    }
                    // Check if mouse Up
                    if (e.type == EventType.MouseUp)
                    {
                        mouseIsDown = false;
                    }
                }
                if (items[index].itemID != -1)
                {
                    GUI.DrawTexture(slotRect, items[index].itemImg);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        hoveringCurrentItem = items[index];
                        showTooltip = true;
                        // lift up an item and drag
                        if (mouseIsDown && e.type == EventType.mouseDrag && !draggingItem)
                        {
                            if (items == equipment.equipment)
                            {
                                DequipItem(items[index]);
                            }
                            draggingItem = true;
                            prevList = items;
                            prevIndex = index;
                            draggedItem = items[index];
                            items[index] = new Item();
                        }
                        // right click in inventory
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (items[index].itemType == Item.ItemType.Consumable)
                            {
                                UseConsumable(items[index], index, true);
                            }
                        }
                    }
                }
                else // if slot has no item
                {
                    if (hoveringCurrentItem.itemID == -1)
                    {
                        showTooltip = false;
                    }
                }
                //}
                // Let go of item
                bool allowedToDrop = true;
                bool equipItem = false;
                bool inventoryToEquipDrop = false;
                bool equipmentToInventoryDrop = false;
                if (slotRect.Contains(Event.current.mousePosition))
                {
                    if (e.type == EventType.mouseUp && draggingItem)
                    {
                        // EQUIPMENT EQUIP CHECK
                        if (items == equipment.equipment)
                        {
                            allowedToDrop = false;
                            if (equipment.equipment[index].itemID != -1 && prevList == inventory.inventory)//if it has an item
                            {
                                inventoryToEquipDrop = true;
                            }
                            if (prevList == equipment.equipment && prevIndex == 0 && prevList[1].armorType == Item.ArmorType.Shield && index == 1)
                            {
                                allowedToDrop = false;
                            }
                            else if (index == 0 && draggedItem.itemType == Item.ItemType.Weapon) // index 0 is weapon slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 1 && (draggedItem.armorType == Item.ArmorType.Shield 
                                || draggedItem.itemType == Item.ItemType.Weapon)) // index 1 is shield/second weapon slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 2 && draggedItem.armorType == Item.ArmorType.Neck) // index 2 is Neck slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 3 && draggedItem.armorType == Item.ArmorType.Hands) // index 3 is Hands slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 4 && draggedItem.itemType == Item.ItemType.Accessory) // index 4 is acc slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 5 && draggedItem.armorType == Item.ArmorType.Head) // index 5 is Head slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 6 && draggedItem.armorType == Item.ArmorType.Body) // index 6 is Body slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 7 && draggedItem.armorType == Item.ArmorType.Bottom) // index 7 is Bottom slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 8 && draggedItem.armorType == Item.ArmorType.Boots) // index 8 is Boots slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                            else if (index == 9 && draggedItem.itemType == Item.ItemType.Accessory) // index 9 is Acc slot
                            {
                                allowedToDrop = true;
                                equipItem = true;
                            }
                        }
                        // check if able to switch when drop (FROM EQUIPMENT TO INVENTORY)
                        else if (items == inventory.inventory && prevList == equipment.equipment)
                        {
                            allowedToDrop = false;
                            if (prevIndex == 0 && (items[index].itemType == Item.ItemType.Weapon || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 1 && ((items[index].armorType == Item.ArmorType.Shield||
                                items[index].itemType == Item.ItemType.Weapon) || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 2 && (items[index].armorType == Item.ArmorType.Neck || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 3 && (items[index].armorType == Item.ArmorType.Hands || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 4 && (items[index].itemType == Item.ItemType.Accessory || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 5 && (items[index].armorType == Item.ArmorType.Head || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 6 && (items[index].armorType == Item.ArmorType.Body || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 7 && (items[index].armorType == Item.ArmorType.Bottom || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 8 && (items[index].armorType == Item.ArmorType.Boots || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                            else if (prevIndex == 9 && (items[index].itemType == Item.ItemType.Accessory || items[index].itemID == -1))
                            {
                                allowedToDrop = true;
                                equipmentToInventoryDrop = true;
                            }
                        }
                        if (equipItem)
                        {
                            EquipItem(draggedItem);
                        }
                        if (allowedToDrop)
                        {
                            if (equipmentToInventoryDrop)
                            {
                                EquipItem(items[index]);
                            }
                            if (inventoryToEquipDrop)
                            {
                                DequipItem(items[index]);
                            }
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
       

    
    public bool Button(float x, float y, float w, float h, string skinPressed, string skinNotPressed)
    {
        Event e = Event.current;
        Rect slotRect = new Rect(x, y , w, h);
        bool pressed;
        // Inside box
        if (slotRect.Contains(Event.current.mousePosition))
        {
            // mouse press
            if (e.button == 0 && e.type == EventType.MouseDown)
            {
                mouseIsDown = true;
            }
            // Check if mouse Up
            if (e.type == EventType.MouseUp)
            {
                mouseIsDown = false;
            }
        }
        // Inside box
        if (mouseIsDown && slotRect.Contains(Event.current.mousePosition))
        {
            GUI.Box(slotRect, "", skin.GetStyle(skinPressed));
            pressed = true;
        }
        else
        {
            GUI.Box(slotRect, "", skin.GetStyle(skinNotPressed));
            pressed = false;
        }
        return pressed;
    }
    public bool Button(float x, float y, float w, float h, string picture)
    {
        Event e = Event.current;
        Rect slotRect = new Rect(x, y, w, h);
        bool pressed;
        // Inside box
        GUI.Box(slotRect, "", skin.GetStyle(picture));
        if (slotRect.Contains(Event.current.mousePosition) && e.type == EventType.MouseDown)
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
        return pressed;
    }

    private void EquipItem(Item item)
    {
        playerStats.BuffStat(0, item.itemBonusStr);
        playerStats.BuffStat(1, item.itemBonusInt);
        playerStats.BuffStat(2, item.itemBonusAgi);
        playerStats.BuffStat(3, item.itemBonusLuk);
        playerStats.BuffStat(5, item.itemBonusHP);
        playerStats.BuffStat(7, item.itemBonusMP);
        playerStats.BuffStat(8, item.itemBonusAtk);
        playerStats.BuffStat(9, item.itemBonusMAtk);
        playerStats.BuffStat(10, item.itemBonusDef);
        playerStats.BuffStat(11, item.itemBonusResist);
        playerStats.BuffStat(12, item.itemBonusHit);
        playerStats.BuffStat(13, item.itemBonusDodge);
        playerStats.BuffStat(14, item.itemBonusCrit);
        playerStats.BuffStat(15, item.itemBonusCritMulti);
        playerStats.StatsUpdate();
    }
    private void DequipItem(Item item)
    {
        playerStats.DebuffStat(0, item.itemBonusStr);
        playerStats.DebuffStat(1, item.itemBonusInt);
        playerStats.DebuffStat(2, item.itemBonusAgi);
        playerStats.DebuffStat(3, item.itemBonusLuk);
        playerStats.DebuffStat(5, item.itemBonusHP);
        playerStats.DebuffStat(7, item.itemBonusMP);
        playerStats.DebuffStat(8, item.itemBonusAtk);
        playerStats.DebuffStat(9, item.itemBonusMAtk);
        playerStats.DebuffStat(10, item.itemBonusDef);
        playerStats.DebuffStat(11, item.itemBonusResist);
        playerStats.DebuffStat(12, item.itemBonusHit);
        playerStats.DebuffStat(13, item.itemBonusDodge);
        playerStats.DebuffStat(14, item.itemBonusCrit);
        playerStats.DebuffStat(15, item.itemBonusCritMulti);
        playerStats.StatsUpdate();

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

    
}
