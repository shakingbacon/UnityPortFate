using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
    public float slotsX, slotsY, boxX, boxY, boxW, boxH, titleH;
    public GUISkin skin;
    private ItemDatabase database;
    public SlotButton slotButton;
    public Inventory inventory;
    public Equipment equipment;
    public Tooltip tooltip;

    public bool showingShopTool;
    public bool draggingShop;
    public bool showShop;
    
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        slotButton = slotButton.GetComponent<SlotButton>();
        inventory = inventory.GetComponent<Inventory>();
        equipment = equipment.GetComponent<Equipment>();
        tooltip = tooltip.GetComponent<Tooltip>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!showShop)
        {
            showShop = true;
        }
    }
    void OnGUI()
    {
        GUI.skin = skin;
        slotButton.tooltip = "";
        if (showShop)
        {
            DrawShop();
        }
        if (slotButton.showTooltip)
        {
            showingShopTool = true;
            tooltip.DrawTooltip();
        }
        else
        {
            showingShopTool = false;
        }
        if (slotButton.draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
        }
    }


    void DrawShop()
    {
        Event e = Event.current;
        // title drag
        if (!equipment.draggingEquip &&
            !inventory.draggingInv &&
            !slotButton.draggingItem && new Rect(boxX, boxY, boxW, titleH).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
        {
            draggingShop = true;
            boxX = Event.current.mousePosition.x - boxW / 2;
            boxY = Event.current.mousePosition.y - titleH / 2;
        }
        else
        {
            draggingShop = false;
        }
        // Background
        GUI.Box(new Rect(boxX, boxY, boxW, boxH), "", skin.GetStyle("Panel Brown"));
        // Title
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "Shop", skin.GetStyle("Button Long Brown"));
        // Close button
               
        // Inventory Slots
        slotButton.MatrixSlot(slotsX, slotsY, database.shop1, boxX + 32, boxY + 65, 67, 67);
    }
}
