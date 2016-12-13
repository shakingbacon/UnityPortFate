using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Equipment : MonoBehaviour {
    public float boxX, boxY, boxW,boxH, equipSlotX, equipSlotY, titleH;
    public GUISkin skin;
    public List<Item> equipment = new List<Item>();
    public List<Item> equipmentSlots = new List<Item>();
    //
    public PlayerStats playerStats;
    public SlotButton slotButton;
    private ItemDatabase database;
    public Inventory inventory;
    // 
    public bool draggingEquip;
    public bool showingEquipTool;
    private bool showEquipment;
    void Start () {
        for (int i = 0; i < (equipSlotX * equipSlotY); i += 1)
        {
            equipmentSlots.Add(new Item());
            equipment.Add(new Item());
        }
        playerStats = playerStats.GetComponent<PlayerStats>();
        slotButton = slotButton.GetComponent<SlotButton>();
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
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
            if (Event.current.mousePosition.x + 290 > Screen.width && Event.current.mousePosition.y + 110 + slotButton.tooltip.Length * 0.46f > Screen.height)
            {
                GUI.Box(new Rect(Screen.width - 290, Screen.height - 110 - slotButton.tooltip.Length * 0.46f,
                    290, 110 + slotButton.tooltip.Length * 0.46f), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            else if (Event.current.mousePosition.x + 290 > Screen.width)
            {
                GUI.Box(new Rect(Screen.width - 290, Event.current.mousePosition.y,
                290, 110 + slotButton.tooltip.Length * 0.46f), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            else if (Event.current.mousePosition.y + 110 + slotButton.tooltip.Length * 0.46f > Screen.height)
            {
                GUI.Box(new Rect(Event.current.mousePosition.x, Screen.height - 110 - slotButton.tooltip.Length * 0.46f,
                290, 110 + slotButton.tooltip.Length * 0.46f), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            else
            {
                GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y,
                    290, 110 + slotButton.tooltip.Length * 0.46f), slotButton.tooltip, skin.GetStyle("Tooltip"));
            }
            if (slotButton.draggingItem)
            {
                GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - 100, 100, 100), slotButton.draggedItem.itemImg);
            }
        }else
        {
            showingEquipTool = false;
        }
    }
    void DrawEquipment()
    {
        Event e = Event.current;
        // title drag
        if (!inventory.draggingInv && e.button == 0 && new Rect(boxX, boxY, boxW, titleH).Contains(Event.current.mousePosition) && e.type == EventType.mouseDrag) // title drag
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
        GUI.Box(new Rect(boxX, boxY, boxW, titleH), "", skin.GetStyle("Button Long Brown"));
        // Character 
        GUI.Box(new Rect(boxX, boxY+60, 150, boxH), Resources.Load<Texture2D>("Equip Char"));
        if (equipment[7].itemID != -1)
        {
            GUI.DrawTexture(new Rect(boxX + 60, boxY + 190, 67, 67), Resources.Load<Texture2D>("Item Icons/" + equipment[7].itemName));
        }
        // Slot
        slotButton.MatrixSlot(equipSlotX, equipSlotY, equipmentSlots, equipment, boxX + 160, boxY + 65, 67, 67);
        
    }

}
