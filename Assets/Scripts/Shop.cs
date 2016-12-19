using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
    public Page page = new Page();
    public float slotsX, slotsY, boxX, boxY, boxW, boxH, titleH;
    public GUISkin skin;
    public GameManager manager;
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
        page.id = 2;
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        slotButton = slotButton.GetComponent<SlotButton>();
        inventory = inventory.GetComponent<Inventory>();
        equipment = equipment.GetComponent<Equipment>();
        tooltip = tooltip.GetComponent<Tooltip>();
        manager = manager.GetComponent<GameManager>();
    }

    void Update()
    {
        if (showShop && Input.GetButtonDown("Cancel"))
        {
            showShop = false;
            slotButton.showTooltip = false;
        }
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
        if (showShop)
        {
            slotButton.hoveringCurrentItem = new Item();
            DrawShop();
            tooltip.DrawTooltip(slotButton.hoveringCurrentItem);
            if (slotButton.draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
            }
        }

    }


    void DrawShop()
    {
        Event e = Event.current;
        // title drag

        if ((manager.draggingPageID == -1 || manager.draggingPageID == page.id) &&
            !slotButton.draggingItem && new Rect(boxX, boxY, boxW, titleH).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
        {
            manager.draggingPageID = page.id;
            boxX = Event.current.mousePosition.x - boxW / 2;
            boxY = Event.current.mousePosition.y - titleH / 2;
        }
        if (e.type == EventType.mouseUp)
        {
            manager.draggingPageID = -1;
        }

        // Background
        GUI.Box(new Rect(boxX, boxY, boxW, boxH), "", skin.GetStyle("Panel Brown"));
        // Title
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "Shop", skin.GetStyle("Button Long Brown"));
        // Close button
        if (slotButton.Button(boxX+boxW-45, boxY+5, 35, 35, "Cross Brown"))
        {
            showShop = false;
        }
        // Inventory Slots
        slotButton.MatrixSlot(slotsX, slotsY, database.shop1, boxX + 32, boxY + 65, 67, 67);
    }
}
