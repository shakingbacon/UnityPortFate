using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
    public float boxX, boxY, boxW,boxH, equipSlotX, equipSlotY, titleH, statButtonW, statButtonH,
        statBoxW, statBoxH;
    public GUISkin skin;
    public List<Item> equipment = new List<Item>();
    public List<Texture2D> defaultImage = new List<Texture2D>();
    //
    public PlayerStats playerStats;
    public SlotButton slotButton;
    public Tooltip tooltip;
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
        // show the picture that shows where to equip
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Weapon"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Hands"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Shield"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Head"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Body"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Bottom"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Boots"));
        defaultImage.Add(Resources.Load<Texture2D>("Default Equip/Accessory"));
        //
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
    }

    void OnGUI()
    {
        GUI.skin = skin;
        slotButton.tooltip = "";
        if (showEquipment)
        {
            DrawEquipment();
        }
        if (slotButton.showTooltip && !inventory.showingInvTool)
        {
            showingEquipTool = true;
            tooltip.DrawTooltip();
        }
        else
        {
            showingEquipTool = false;
        }
    }
    void DrawEquipment()
    {
        Event e = Event.current;
        // title drag
        if (!inventory.draggingInv && !slotButton.draggingItem && new Rect(boxX, boxY, boxW, titleH).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
        {
            draggingEquip = true;
            boxX = Event.current.mousePosition.x - boxW / 2;
            boxY = Event.current.mousePosition.y - titleH / 2;
        }
        else
        {
            draggingEquip = false;
        }
        // Background
        GUI.Box(new Rect(boxX, boxY, boxW, boxH), "", skin.GetStyle("Panel Brown"));
        // Title
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "Equipment", skin.GetStyle("Button Long Brown"));
        // Character 
        GUI.Box(new Rect(boxX, boxY+60, 150, boxH), Resources.Load<Texture2D>("Default Equip/Equip Char"));
        /*
        if (equipment[7].itemID != -1)
        {
            GUI.DrawTexture(new Rect(boxX + 60, boxY + 190, 67, 67), Resources.Load<Texture2D>("Item Icons/" + equipment[7].itemName));
        }*/
        // Slot
        slotButton.MatrixSlot(equipSlotX, equipSlotY, equipment, boxX + 160, boxY + 65, 67, 67);
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
        if (showStats)
        {
            GUI.Box(new Rect(boxX + boxW, boxY, statBoxW, statBoxH), "", skin.GetStyle("Panel Brown"));
            GUI.Box(new Rect(boxX + boxW, boxY, statBoxW, statBoxH), playerStats.makeStatsPage(), skin.GetStyle("Stats Page"));

        }




    }

}
