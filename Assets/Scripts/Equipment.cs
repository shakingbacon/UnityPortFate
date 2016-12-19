using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
    public Page page = new Page();
    public float boxX, boxY, boxW,boxH, equipSlotX, equipSlotY, titleH, statButtonW, statButtonH,
        statBoxW, statBoxH;
    public GUISkin skin;
    public int id = 1;
    public List<Item> equipment = new List<Item>();
    public List<Texture2D> defaultImage = new List<Texture2D>();
    //
    public PlayerStats playerStats;
    public SlotButton slotButton;
    public Tooltip tooltip;
    public Shop shop;
    public GameManager manager;
    //private ItemDatabase database;
    public Inventory inventory;
    // 
    public bool draggingEquip;
    public bool showingEquipTool;
    private bool showEquipment;
    private bool showStats;

    void Start () {
        for (int i = 0; i < (equipSlotX * equipSlotY); i += 1)
        {
            equipment.Add(new Item());
        }
        page.id = 1;
        // show the picture that shows where to equip
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Weapon"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Weapon&Shield"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Neck"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Hands"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Head"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Body"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Bottom"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Boots"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
        //
        shop = shop.GetComponent<Shop>();
        manager = manager.GetComponent<GameManager>();
        playerStats = playerStats.GetComponent<PlayerStats>();
        slotButton = slotButton.GetComponent<SlotButton>();
        tooltip = tooltip.GetComponent<Tooltip>();
        //database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        inventory = inventory.GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Equipment"))
        {
            showEquipment = !showEquipment;
            slotButton.showTooltip = false;
        }
        // PLAYER CLOTHES INGAME
        int i;
        for (i = 0; i < equipment.Count; i += 1)
        {
            SpriteRenderer spriteRenderer = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
            if (equipment[i].itemID != -1)
            {
                gameObject.transform.GetChild(i).transform.position = new Vector2(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y);
                if (i == 1 && equipment[i].itemType == Item.ItemType.Weapon)
                {
                    spriteRenderer.sprite = Resources.Load<Sprite>("Player/" + equipment[i].itemName + "2");
                    spriteRenderer.flipX = gameObject.GetComponentInParent<SpriteRenderer>().flipX;
                }
                else
                {
                    spriteRenderer.sprite = Resources.Load<Sprite>("Player/" + equipment[i].itemName);
                    spriteRenderer.flipX = gameObject.GetComponentInParent<SpriteRenderer>().flipX;
                }

            }
            else
            {
                if (i == 3)
                {
                    gameObject.transform.GetChild(i).transform.position = new Vector2(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y);
                    spriteRenderer.sprite = Resources.Load<Sprite>("Player/Mage Arm");
                    spriteRenderer.flipX = gameObject.GetComponentInParent<SpriteRenderer>().flipX;
                }
                else
                {
                    spriteRenderer.sprite = Resources.Load<Sprite>("None");
                }
            }

        }

    }

    void OnGUI()
    {
        if (showEquipment)
        {
            slotButton.hoveringCurrentItem = new Item();
            DrawEquipment();
            tooltip.DrawTooltip(slotButton.hoveringCurrentItem);
            if (slotButton.draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
            }
        }
        
    }
    void DrawEquipment()
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
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "Equipment", skin.GetStyle("Button Long Brown"));
        // Character 
        float characterX = boxX + 22;
        float characterY = boxY + 45;
        Rect charRect = new Rect(characterX, characterY, 200, 400);
        if (playerStats.job.jobID == 0)
        {
            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Body"));
            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Hair"));
        }
        for (int i = 0; i < equipment.Count; i += 1)
        {
            if (equipment[i].itemID != -1)
            {
                if (i != 3 && i != 0 && i != 1 && i != 7)
                {
                    GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[i].itemName));
                }
            }
        }
        if (equipment[1].itemID != -1)
        {
            if (equipment[1].itemType == Item.ItemType.Weapon)
            {
                GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[1].itemName + "2")); // weapon 2
            }
            else
            {
                GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[1].itemName)); // shield goes under weapon
            }
        }
        if (equipment[7].itemID != -1)
        {
            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[7].itemName)); // bottom over shield but under weapon
        }
        if (equipment[0].itemID != -1)
        {
            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[0].itemName)); // weapon under hands but over bottom
        }
        if (equipment[3].itemID != -1)
        {
            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[3].itemName)); // hands are covered if go by index
        }
        else
        {
            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Arm"));
        }

        // Slot
        slotButton.MatrixSlot(equipSlotX, equipSlotY, equipment, boxX + 235, boxY + 65, 67, 67);
        // show stats
        if (!showStats && slotButton.Button(boxX+boxW - statButtonW - 20, boxY+boxH - statButtonH - 20, statButtonW, statButtonH, "Arrow Right"))
        {
            showStats = true;
        }
        else if (showStats && slotButton.Button(boxX + boxW - statButtonW - 20, boxY + boxH - statButtonH - 20, statButtonW, statButtonH, "Arrow Left"))
        {
            {
                showStats = false;
            }
        }
        // Close button
        if (slotButton.Button(boxX + boxW - 45, boxY + 5, 35, 35, "Cross Brown"))
        {
            showEquipment = false;
        }
        if (showStats)
        {
            GUI.Box(new Rect(boxX + boxW, boxY, statBoxW, statBoxH), "", skin.GetStyle("Panel Brown"));
            GUI.Box(new Rect(boxX + boxW, boxY, statBoxW, statBoxH), playerStats.makeStatsPage(), skin.GetStyle("Stats Page"));
        }




    }

}
