using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
    static Transform equipment;

    void Start()
    {
        equipment = gameObject.transform;
    }

    public static void EquipItem(int slotindex)
    {

    }

    public static void DequipItem(int slotindex)
    {

    }
    //private Page page = new Page(1, 460, 100, 400, 450, 50);
    //public float equipSlotX, equipSlotY, statButtonW, statButtonH,
    //    statBoxW, statBoxH;
    //public GUISkin skin;
    //public List<Item> equipment = new List<Item>();
    //public List<Texture2D> defaultImage = new List<Texture2D>();
    ////
    //public PlayerStats playerStats;
    //public SlotButton slotButton;
    //public Tooltip tooltip;
    //public Shop shop;
    //public GameManager manager;
    ////private ItemDatabase database;
    //public Inventory inventory;
    //// 
    //private bool showStats;

    //void Start () {
    //    for (int i = 0; i < (equipSlotX * equipSlotY); i += 1)
    //    {
    //        equipment.Add(new Item());
    //    }
    //    // show the picture that shows where to equip
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Weapon"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Weapon&Shield"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Neck"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Hands"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Head"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Body"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Bottom"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Boots"));
    //    defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
    //    //
    //    shop = shop.GetComponent<Shop>();
    //    manager = manager.GetComponent<GameManager>();
    //    playerStats = playerStats.GetComponent<PlayerStats>();
    //    slotButton = slotButton.GetComponent<SlotButton>();
    //    tooltip = tooltip.GetComponent<Tooltip>();
    //    //database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
    //    inventory = inventory.GetComponent<Inventory>();
    //}
    //void Update()
    //{
    //    if (Input.GetButtonDown("Equipment")) 
    //    {
    //        page.showPage = !page.showPage;
    //        slotButton.showTooltip = false;
    //    }
    //    // PLAYER CLOTHES INGAME
    //    int i;
    //    for (i = 0; i < equipment.Count; i += 1)
    //    {
    //        SpriteRenderer spriteRenderer = gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>();
    //        if (equipment[i].itemID != -1)
    //        {
    //            gameObject.transform.GetChild(i).transform.position = new Vector2(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y);
    //            // if weapon in shield slot
    //            if (i == 1 && equipment[i].itemType == Item.ItemType.Weapon)
    //            {
    //                spriteRenderer.sprite = Resources.Load<Sprite>("Player/" + equipment[i].itemName + "2");

    //            }
    //            else
    //            {
    //                spriteRenderer.sprite = Resources.Load<Sprite>("Player/" + equipment[i].itemName);
    //            }
    //            if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") > 0)
    //            {
    //                spriteRenderer.flipX = false;
    //            }
    //            else if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") < 0)
    //            {
    //                spriteRenderer.flipX = true;
    //            }

    //        }
    //        else
    //        {
    //            if (i == 3)
    //            {
    //                gameObject.transform.GetChild(i).transform.position = new Vector2(gameObject.transform.parent.transform.position.x, gameObject.transform.parent.transform.position.y);
    //                spriteRenderer.sprite = Resources.Load<Sprite>("Player/Mage Arm");
    //                if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") > 0)
    //                {
    //                    spriteRenderer.flipX = false;
    //                }
    //                else if (gameObject.GetComponentInParent<Animator>().GetFloat("input_x") < 0)
    //                {
    //                    spriteRenderer.flipX = true;
    //                }
    //            }
    //            else
    //            {
    //                spriteRenderer.sprite = Resources.Load<Sprite>("None");
    //            }
    //        }

    //    }

    //}

    //void OnGUI()
    //{
    //    if (page.showPage)
    //    {
    //        slotButton.hoveringCurrentItem = new Item();
    //        DrawEquipment();
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
    //void DrawEquipment()
    //{
    //    Event e = Event.current;
    //    // title drag
    //    if ((manager.draggingPageID == -1 || manager.draggingPageID == page.id) &&
    //        !slotButton.draggingItem && new Rect(page.x, page.y, page.w, page.titleh).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
    //    {
    //        manager.draggingPageID = page.id;
    //        page.x = Event.current.mousePosition.x - page.w / 2;
    //        page.y = Event.current.mousePosition.y - page.titleh / 2;
    //    }
    //    if (e.type == EventType.mouseUp)
    //    {
    //        manager.draggingPageID = -1;
    //    }
    //    // Background
    //    GUI.Box(new Rect(page.x, page.y, page.w, page.h), "", skin.GetStyle("Panel Brown"));
    //    // Title
    //    GUI.Box(new Rect(page.x, page.y, page.w, page.titleh), "Equipment", skin.GetStyle("Button Long Brown"));
    //    // Character 
    //    float characterX = page.x + 22;
    //    float characterY = page.y + 45;
    //    Rect charRect = new Rect(characterX, characterY, 200, 400);
    //    //if (playerStats.job.jobID == 0)
    //    //{
    //    //    GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Body"));
    //    //    GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Hair"));
    //    //}
    //    for (int i = 0; i < equipment.Count; i += 1)
    //    {
    //        if (equipment[i].itemID != -1)
    //        {
    //            if (i != 3 && i != 0 && i != 1 && i != 7 && i != 4 && i != 9)
    //            {
    //                GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[i].itemName));
    //            }
    //        }
    //    }
    //    if (equipment[1].itemID != -1)
    //    {
    //        if (equipment[1].itemType == Item.ItemType.Weapon)
    //        {
    //            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[1].itemName + "2")); // weapon 2
    //        }
    //        else
    //        {
    //            GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[1].itemName)); // shield goes under weapon
    //        }
    //    }
    //    if (equipment[7].itemID != -1)
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[7].itemName)); // bottom over shield but under weapon
    //    }
    //    if (equipment[0].itemID != -1)
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[0].itemName)); // weapon under hands but over bottom
    //    }
    //    if (equipment[3].itemID != -1)
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/" + equipment[3].itemName)); // hands are covered if go by index
    //    }
    //    else
    //    {
    //        GUI.DrawTexture(charRect, Resources.Load<Texture2D>("Player/Mage Arm"));
    //    }
    //    // show stats
    //    if (showStats == false)
    //    {
    //        if (GUI.Button(new Rect(page.x + page.w - statButtonW - 20, page.y + page.h - statButtonH - 20, statButtonW, statButtonH), 
    //        Resources.Load<Texture2D>("GUI/Arrow Right")))
    //        {
    //            showStats = true;
    //        }
    //    }
    //    else
    //    {
    //        if (GUI.Button(new Rect(page.x + page.w - statButtonW - 20, page.y + page.h - statButtonH - 20, statButtonW, statButtonH),
    //        Resources.Load<Texture2D>("GUI/Arrow Left")))
    //        {
    //            showStats = false;
    //        }
    //    }
    //    // Close button
    //    if (GUI.Button(new Rect(page.x + page.w - 45, page.y + 5, 35, 35), Resources.Load<Texture2D>("GUI/Cross Brown")))
    //    {
    //        page.showPage = false;
    //    }
    //    // Slot
    //    slotButton.MatrixSlot(equipSlotX, equipSlotY, equipment, page.x + 235, page.y + 65, 67, 67);
    //    if (showStats)
    //    {
    //        GUI.Box(new Rect(page.x + page.w, page.y, statBoxW, statBoxH), "", skin.GetStyle("Panel Brown"));
    //        //GUI.Box(new Rect(page.x + page.w, page.y, statBoxW, statBoxH), playerStats.makeStatsPage(), skin.GetStyle("Stats Page"));
    //    }




    //}

}
