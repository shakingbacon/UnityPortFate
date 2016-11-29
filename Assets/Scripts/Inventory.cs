using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    GameObject inventoryPanel;
    public float slotsX, slotsY, boxX, boxY, boxW, boxH, titleH, equipSlotX, equipSlotY;
    public GUISkin skin;
    public List<Item> equipment = new List<Item>();
    public List<Item> equipmentSlots = new List<Item>();
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase database;
    private bool showInventory;
    private bool mouseIsDown = false;
    public SlotButton slotButton;

    private bool draggingTitle;
    private bool draggingItem;

    private int prevIndex;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < (slotsX * slotsY); i += 1)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        for (int i = 0; i < (equipSlotX * equipSlotY); i += 1)
        {
            equipmentSlots.Add(new Item());
            equipment.Add(new Item());
        }
        slotButton = slotButton.GetComponent<SlotButton>();
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        equipment[0] = database.items[0];
        equipment[1] = database.items[2];
        equipment[2] = database.items[1];
        equipment[3] = database.items[3];
        equipment[4] = database.items[4];
        equipment[5] = database.items[5];
        equipment[6] = database.items[6];
        equipment[7] = database.items[5];
        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(200);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
            slotButton.showTooltip = false;
            if (draggingItem)
            {
                inventory[prevIndex] = slotButton.draggedItem;
                draggingItem = false;
                slotButton.draggedItem = null;
            }
        }
    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(40, 400, 100, 40), "Save"))
        {
            SaveInventory();
        }
        if (GUI.Button(new Rect(150, 400, 100, 40), "Load"))
        {
            LoadInventory();
        }
        GUI.skin = skin;
        slotButton.tooltip = "";
        if (showInventory)
        {
            DrawInventory();

        }
        if (slotButton.showTooltip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 250, 250), slotButton.tooltip, skin.GetStyle("Tooltip"));
        }
        if (slotButton.draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
        }

    }



    void DrawInventory()
    {
        Event e = Event.current;
        // title drag
        if (e.button == 0 && new Rect(boxX, boxY, boxW, titleH).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
        {
            draggingTitle = true;
            boxX = Event.current.mousePosition.x - boxW/2;
            boxY = Event.current.mousePosition.y - titleH/2;
        }
        else
        {
            draggingTitle = false;
        }
        // Background
        GUI.Box(new Rect(boxX, boxY, boxW, boxH), "", skin.GetStyle("Panel Brown"));
        // Title
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "", skin.GetStyle("Button Long Brown"));
        // Equip Slots
        slotButton.MatrixSlot(equipSlotX, equipSlotY, equipmentSlots, equipment, boxX+29, boxY+50, 60, 60);
        // Inventory Slots
        slotButton.MatrixSlot(slotsX, slotsY, slots, inventory, boxX + 29, boxY + 215, 60, 60);

    }


void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i += 1)
        {
            if (inventory[i].itemName == null)
            {
                for (int j = 0; j < database.items.Count; j += 1)
                {
                    if (database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }
    void RemoveItem(int id)
    {
        for (int i = 0; i < inventory.Count; i += 1)
        {
            if (inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;

            }
        }
    }


    bool InventoryContains(int id)
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; i += 1)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }

    private void UseConsumable(Item item, int slot, bool deleteItem)
    {
        switch (item.itemID)
        {
            case 2:
                {
                    //PlayerStats.IncreaseStat(stat id, buff amount, turns);
                    break;
                }
        }
        if (deleteItem)
        {
            inventory[slot] = new Item();
        }
    }

    void SaveInventory()
    {
        for (int i = 0; i < inventory.Count; i += 1)
        {
            PlayerPrefs.SetInt("Inventory " + i, inventory[i].itemID);
        }
    }

    void LoadInventory()
    {
        for (int i = 0; i < inventory.Count; i += 1)
        {
            inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
        }

    }
}
