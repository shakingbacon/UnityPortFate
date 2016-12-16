using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public float slotsX, slotsY, boxX, boxY, boxW, boxH, titleH;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    //
    public PlayerStats playerStats;
    private ItemDatabase database;
    public SlotButton slotButton;
    public Equipment equipment;
    //
    private bool showInventory;
    private bool mouseIsDown = false;
    public bool draggingInv;
    public bool showingInvTool;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < (slotsX * slotsY); i += 1)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

        playerStats = playerStats.GetComponent<PlayerStats>();
        slotButton = slotButton.GetComponent<SlotButton>();
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        equipment = equipment.GetComponent<Equipment>();
        //equipment.equipment[0] = database.items[2];
        AddItem(1000);
        AddItem(1100);
        AddItem(1200);
        AddItem(1300);
        AddItem(1400);
        AddItem(1500);
        AddItem(1600);
        AddItem(9100);
        AddItem(9101);
        AddItem(9102);
        AddItem(9103);


        //bool test = inventory.Exists(Item => Item == getItem(200));
        //print(test);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
            slotButton.showTooltip = false;
        }
    }
    void OnGUI() {
        GUI.skin = skin;
        slotButton.tooltip = "";
        if (showInventory)
        {
            DrawInventory();
            if (GUI.Button(new Rect(40, 400, 100, 40), "Save"))
            {
                SaveInventory();
            }
            if (GUI.Button(new Rect(150, 400, 100, 40), "Load"))
            {
                LoadInventory();
            }
        }
        if (slotButton.showTooltip && !equipment.showingEquipTool)
        {
            showingInvTool = true;
            float toolX = Event.current.mousePosition.x;
            float toolY = Event.current.mousePosition.y;
            float toolW = 290;
            float toolH = 115 + slotButton.tooltip.Length * 0.61f;
            // goes past bottom and right
            if (toolX + toolW > Screen.width && toolY + toolH > Screen.height)
            {   
                GUI.Box(new Rect(Screen.width - toolW, Screen.height - toolH, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            // goes past right
            else if(toolX + toolW  > Screen.width)
            {   
                GUI.Box(new Rect(Screen.width - toolW, toolY, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            // goes past bottom
            else if (toolY + toolH > Screen.height)
            {
                GUI.Box(new Rect(toolX, Screen.height - toolH, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            else
            {
                GUI.Box(new Rect(toolX, toolY, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
        }
        else
        {
            showingInvTool = false;
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
        if (!equipment.draggingEquip && e.button == 0 && new Rect(boxX, boxY, boxW, titleH).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
        {
            draggingInv = true;
            boxX = Event.current.mousePosition.x - boxW/2;
            boxY = Event.current.mousePosition.y - titleH/2;
        }
        else
        {
            draggingInv = false;
        }
        // Background
        GUI.Box(new Rect(boxX, boxY, boxW, boxH), "", skin.GetStyle("Panel Brown"));
        // Title
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "", skin.GetStyle("Button Long Brown"));
        // Inventory Slots
        slotButton.MatrixSlot(slotsX, slotsY, slots, inventory, boxX + 32, boxY + 65, 67, 67);
    }


    Item getItem(int id)
    {
        Item returnItem = new Item();
        for (int j = 0; j < database.items.Count; j += 1)
        {
            if (database.items[j].itemID == id)
            {
                returnItem = database.items[j];
                break;
            }
        }
        return returnItem;
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
