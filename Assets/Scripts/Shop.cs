using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{
    private Page page = new Page(2, 0,0, 325,450,50);
    public float slotsX, slotsY;
    public GUISkin skin;
    public GameManager manager;
    private ItemDatabase database;
    public SlotButton slotButton;
    public Inventory inventory;
    public Equipment equipment;
    public Tooltip tooltip;
    public Item itemToBuy;

    public int pageIndex;
    private string buyResult;
    private Transform player;
    public bool showingShopTool;
    public bool draggingShop;
    public bool showShop;
    public bool buyingItem = false;
    public bool purchaseFailed = false;

    public Rect windowRect0;
    
    void Start()
    {
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        slotButton = slotButton.GetComponent<SlotButton>();
        inventory = inventory.GetComponent<Inventory>();
        equipment = equipment.GetComponent<Equipment>();
        tooltip = tooltip.GetComponent<Tooltip>();
        manager = manager.GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (showShop && Input.GetButtonDown("Cancel"))
        {
            showShop = false;
            slotButton.showTooltip = false;
        }
        if (showShop)
        {
            float displacement = 1.75f;
            if (player.transform.position.x > gameObject.transform.position.x + displacement || player.transform.position.x < gameObject.transform.position.x - displacement ||
                player.transform.position.y > gameObject.transform.position.y + displacement || player.transform.position.y < gameObject.transform.position.y - displacement)
            {
                showShop = false;
            }
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
            if (tooltip.DrawTooltip(slotButton.hoveringCurrentItem) && (manager.showingPageTooltipID == -1 || manager.showingPageTooltipID == page.id))
            {
                manager.showingPageTooltipID = page.id;
            }
            else
            {
                manager.showingPageTooltipID = -1;
            }
            if (slotButton.draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
            }
        }
        if (buyingItem)
        {
            windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "Buying:\n" + itemToBuy.itemName, skin.GetStyle("Panel Brown"));
        }
        if (purchaseFailed)
        {
            windowRect0 = GUI.Window(1, windowRect0, DoMyWindow, buyResult, skin.GetStyle("Panel Brown"));
        }

    }
    void DoMyWindow(int windowID)
    {
        if (windowID == 0)  
        {
            GUI.DrawTexture(new Rect(64 , 90 , 80,80), Resources.Load<Texture2D>("Item Icons/"+itemToBuy.itemName));
            if (GUI.Button(new Rect(65 - 25, 200, 50, 50), "Buy"))
            {
                buyResult = inventory.BuyItem(itemToBuy.itemID);
                if (buyResult == "")
                {
                    buyingItem = false;
                }
                else
                {
                    buyingItem = false;
                    purchaseFailed = true;
                }
            }
            if (GUI.Button(new Rect(140 - 25,200, 50, 50), "Close"))
            {
                buyingItem = false;
            }
            GUI.DragWindow();
        }
        else if (windowID == 1)
        {
            if (GUI.Button(new Rect(78, 200, 50, 50), "Cancel"))
            {
                purchaseFailed = false;
            }
            GUI.DragWindow();
        }

    }


    void DrawShop()
    {
        Event e = Event.current;
        // title drag

        if ((manager.draggingPageID == -1 || manager.draggingPageID == page.id) &&
            !slotButton.draggingItem && new Rect(page.x, page.y, page.w, page.titleh).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
        {
            manager.draggingPageID = page.id;
            page.x = Event.current.mousePosition.x - page.w / 2;
            page.y= Event.current.mousePosition.y - page.titleh / 2;
        }
        if (e.type == EventType.mouseUp)
        {
            manager.draggingPageID = -1;
        }
        // Background
        GUI.Box(new Rect(page.x, page.y, page.w, page.h), "", skin.GetStyle("Panel Brown"));
        // Title
        GUI.Box(new Rect(page.x, page.y, page.w, page.titleh), "Shop", skin.GetStyle("Button Long Brown"));
        // Close button
        if (GUI.Button(new Rect(page.x + page.w - 45, page.y + 5, 35, 35), Resources.Load<Texture2D>("GUI/Cross Brown")))
        {
            showShop = false;
        }
        if (pageIndex + 1 < database.shop.Count)
        { 
            if (GUI.Button(new Rect(page.x + 200, page.y + page.h-50 , 30,30), Resources.Load<Texture2D>("GUI/Arrow Right")))
            {
                pageIndex += 1;
            }
        }
        if (pageIndex != 0 && GUI.Button(new Rect(page.x + 100, page.y + page.h - 50, 30, 30), Resources.Load<Texture2D>("GUI/Arrow Left")))
        {
            pageIndex -= 1;
        }
        // Inventory Slots
        slotButton.MatrixSlot(slotsX, slotsY, database.shop[pageIndex], page.x + 32, page.y+ 65, 67, 67);
    }
}
