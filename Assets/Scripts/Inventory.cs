using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private ItemDatabase database;
    private bool showInventory;
    private bool showTooltip;
    private string tooltip;


    private bool draggingItem;
    private Item draggedItem;

    private int prevIndex;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < (slotsX * slotsY); i += 1)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        AddItem(0);
        AddItem(1);
        AddItem(2);

        print(InventoryContains(5)); 
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
            showTooltip = false;
            if (draggingItem)
            {
                inventory[prevIndex] = draggedItem;
                draggingItem = false;
                draggedItem = null;
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
        tooltip = "";
        GUI.skin = skin;
        if (showInventory)
        {
            DrawInventory();
        }
        if (showTooltip)
        {
            GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y-250, 250,250), tooltip, skin.GetStyle("Tooltip"));
        }
        if (draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100,100), draggedItem.itemImg);
        }

    }

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;
        for (int y = 0; y < slotsY; y += 1)
        {
            for (int x = 0; x < slotsX; x += 1)
            {
                Rect slotRect = new Rect(60 + x * 115, 540 + y * 115, 100, 100);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemImg);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        tooltip = CreateTooltip(slots[i]);
                        showTooltip = true;
                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            prevIndex = i;
                            draggedItem = slots[i];
                            inventory[i] = new Item();
                        }
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                        // right click in inventory
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (slots[i].itemType == Item.ItemType.Consumable)
                            {
                                UseConsumable(slots[i], i, true);
                            }
                        }
                    }

                }
                else
                {
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            inventory[prevIndex] = inventory[i];
                            inventory[i] = draggedItem;
                            draggingItem = false;
                        }
                    }
                }
                if (tooltip == "")
                {
                    showTooltip = false;
                }
                i += 1;
            }
        }
    }

    string CreateTooltip(Item item)
    {
        tooltip = "<color=#00ff00>" + item.itemName + "</color>\n" + item.itemDesc;
        return tooltip;
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
        switch(item.itemID)
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
            PlayerPrefs.SetInt("Inventory " +  i, inventory[i].itemID);
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
