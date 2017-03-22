using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    static Transform inventory;
    void Start()
    {
        inventory = gameObject.transform;
        // reset inventory
        for (int i = 0; i < inventory.childCount; i += 1)
        {
            CleanSlot(i);
        }
        InsertItem(0, 1101);
        InsertItem(1, 9104);
        AddItem(1101);
        AddItem(1500);
    }

    public static void AddItem(int itemindex)
    {
        for (int i = 0; i < inventory.childCount; i += 1)
        {
            InsertItem(i, itemindex);
        }
    }

    public static void InsertItem(int slotindex, int itemindex)
    {
        inventory.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item = ItemDatabase.GetItem(itemindex);
        inventory.GetChild(slotindex).GetChild(0).GetComponent<Image>().sprite = inventory.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item.itemImg;
        inventory.GetChild(slotindex).GetChild(0).GetComponent<Image>().enabled = true;
    }

    public static void CleanSlot(int slotindex)
    {
        inventory.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item = new Item();
        inventory.GetChild(slotindex).GetChild(0).GetComponent<Image>().sprite = inventory.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item.itemImg;
        inventory.GetChild(slotindex).GetChild(0).GetComponent<Image>().enabled = false;
    }
        
    //private Page page = new Page(0, 100, 100, 325, 460, 50);
    //public float slotsX, slotsY;
    //public GUISkin skin;
    //public List<Item> inventory = new List<Item>();
    ////
    //public PlayerStats playerStats;
    //private ItemDatabase database;
    //public SlotButton slotButton;
    //public Equipment equipment;
    //public Tooltip tooltip;
    //public Shop shop;
    //public GameManager manager;
    ////
    //public bool draggingInv;
    //public bool showingInvTool;
    //// Use this for initialization
    //void Start()
    //{
    //    for (int i = 0; i < (slotsX * slotsY); i += 1)
    //    {
    //        inventory.Add(new Item());
    //    }
    //    playerStats = playerStats.GetComponent<PlayerStats>();
    //    slotButton = slotButton.GetComponent<SlotButton>();
    //    database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    //    equipment = equipment.GetComponent<Equipment>();
    //    tooltip = tooltip.GetComponent<Tooltip>();
    //    shop = shop.GetComponent<Shop>();
    //    manager = manager.GetComponent<GameManager>();
    //    //equipment.equipment[0] = database.items[2];
    //    AddItem(1000);
    //    AddItem(1001);
    //    AddItem(1100);
    //    AddItem(1200);
    //    AddItem(1300);
    //    AddItem(1400);
    //    AddItem(1500);
    //    AddItem(1600);
    //    AddItem(1700);
    //    AddItem(9100);
    //    AddItem(9101);
    //    AddItem(9102);
    //    AddItem(9103);
    //    AddItem(1201);



    //    //bool test = inventory.Exists(Item => Item == getItem(200));
    //    //print(test);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetButtonDown("Inventory"))
    //    {
    //        page.showPage = !page.showPage;
    //        slotButton.showTooltip = false;
    //    }
    //}
    //void OnGUI() {
    //    if (page.showPage)
    //    {
    //        slotButton.hoveringCurrentItem = new Item();
    //        DrawInventory();
    //        /*
    //        if (GUI.Button(new Rect(40, 400, 100, 40), "Save"))
    //        {
    //            SaveInventory();
    //        }
    //        if (GUI.Button(new Rect(150, 400, 100, 40), "Load"))
    //        {
    //            LoadInventory();
    //        }*/
    //        if (tooltip.DrawTooltip(slotButton.hoveringCurrentItem) && (manager.showingPageTooltipID == -1 || manager.showingPageTooltipID == page.id))
    //        {
    //            manager.showingPageTooltipID = page.id;
    //        }
    //        else
    //        {
    //            manager.showingPageTooltipID = -1;
    //        }
    //        if (slotButton.draggingItem)
    //        {
    //            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
    //        }
    //    }
    //}


    //void DrawInventory()
    //{
    //    Event e = Event.current;
    //    // title drag
    //    if ((manager.draggingPageID == -1 || manager.draggingPageID == page.id) &&
    //        !slotButton.draggingItem && new Rect(page.x, page.y, page.w, page.titleh).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
    //    {
    //        manager.draggingPageID = page.id;
    //        page.x = Event.current.mousePosition.x - page.w/2;
    //        page.y = Event.current.mousePosition.y - page.titleh/2;
    //    }
    //    if (e.type == EventType.mouseUp)
    //    {
    //        manager.draggingPageID = -1;
    //    }
    //    // Background
    //    GUI.Box(new Rect(page.x, page.y, page.w, page.h), "", skin.GetStyle("Panel Brown"));
    //    // Title
    //    GUI.Box(new Rect(page.x, page.y, page.w, page.titleh), "Inventory", skin.GetStyle("Button Long Brown"));
    //    // Close button
    //    if (GUI.Button(new Rect(page.x + page.w - 45, page.y + 5, 35, 35), Resources.Load<Texture2D>("GUI/Cross Brown")))
    //    {
    //        page.showPage = false;
    //    }
    //    // Inventory Slots
    //    slotButton.MatrixSlot(slotsX, slotsY, inventory, page.x+ 32, page.y+ 65, 67, 67);
    //    // Cash
    //    GUI.Box(new Rect(page.x, page.y + 385, page.w, 100), "<color=#ECF32A>Cash: $" + StatUtilities.FindStatTotal(playerStats.stats, 21) + "</color>", skin.GetStyle("Cash"));
    //}


    //Item GetItem(int id)
    //{
    //    Item returnItem = new Item();
    //    for (int j = 0; j < database.items.Count; j += 1)
    //    {
    //        if (database.items[j].itemID == id)
    //        {
    //            returnItem = database.items[j];
    //            break;
    //        }
    //    }
    //    return returnItem;
    //}

    //void AddItem(int id)
    //{
    //    for (int i = 0; i < inventory.Count; i += 1)
    //    {
    //        if (inventory[i].itemName == null)
    //        {
    //            for (int j = 0; j < database.items.Count; j += 1)
    //            {
    //                if (database.items[j].itemID == id)
    //                {
    //                    inventory[i] = database.items[j];
    //                    break;
    //                }
    //            }
    //            break;
    //        }
    //    }
    //}
    //public string BuyItem(int id)
    //{
    //    bool fullInv = true;
    //    for (int i = 0; i < inventory.Count; i += 1)
    //    {
    //        if (inventory[i].itemID == -1)
    //        {
    //            fullInv = false;
    //            break;
    //        }
    //    }
    //    if (fullInv)
    //    {
    //        return "Inventory is full!";
    //    }
    //    else if (StatUtilities.FindStatTotal(playerStats.stats, 21) - GetItem(id).itemCost < 0)
    //    {
    //        return "Not enough cash!";
    //    }
    //    else
    //    {
    //        AddItem(id);
    //        StatUtilities.BuffStat(playerStats.stats, 21, -(GetItem(id).itemCost));
    //        playerStats.StatsUpdate();
    //        return "";
    //    }
    //}
    //void RemoveItem(int id)
    //{
    //    for (int i = 0; i < inventory.Count; i += 1)
    //    {
    //        if (inventory[i].itemID == id)
    //        {
    //            inventory[i] = new Item();
    //            break;
    //        }
    //    }
    //}


    //bool InventoryContains(int id)
    //{
    //    bool result = false;
    //    for (int i = 0; i < inventory.Count; i += 1)
    //    {
    //        result = inventory[i].itemID == id;
    //        if (result)
    //        {
    //            break;
    //        }
    //    }
    //    return result;
    //}


    //void SaveInventory()
    //{
    //    for (int i = 0; i < inventory.Count; i += 1)
    //    {
    //        PlayerPrefs.SetInt("Inventory " + i, inventory[i].itemID);
    //    }
    //}

    //void LoadInventory()
    //{
    //    for (int i = 0; i < inventory.Count; i += 1)
    //    {
    //        inventory[i] = PlayerPrefs.GetInt("Inventory " + i, -1) >= 0 ? database.items[PlayerPrefs.GetInt("Inventory " + i)] : new Item();
    //    }

    //}
}
