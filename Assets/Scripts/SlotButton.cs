using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlotButton : MonoBehaviour {
    private bool mouseIsDown = false;
    public bool showTooltip;
    public bool draggingItem;
    public Item draggedItem;

    private int prevIndex;


    public string tooltip;


    public GUISkin skin;
  


    public void MatrixSlot(float col, float row, List<Item> slots, List<Item> items, float x, float y, float xdis, float ydis)
    {
        float xStart = 0;
        float yStart = 0;
        int index = 0;
        for (int column = 0; column < col; column += 1)
        {
            for (int ro = 0; ro < row; ro += 1)
            {
                slots[index] = items[index];
                ////////////////////////////////////////////////////////////
                //Button(slots[index], items[index], x + xStart, y + yStart, 60, 60);
                Rect slotRect = new Rect(x + xStart, y + yStart, 60, 60);
                Event e = Event.current;
                // Draw Box
                if (mouseIsDown && slotRect.Contains(Event.current.mousePosition))
                {
                    GUI.Box(slotRect, "", skin.GetStyle("Slot Pressed"));
                }
                else
                {
                    GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                }
                // Inside box
                if (slotRect.Contains(Event.current.mousePosition))
                {
                    // mouse press
                    if (e.button == 0 && e.type == EventType.MouseDown)
                    {
                        mouseIsDown = true;
                    }
                }
                // Check if mouse Up
                if (e.type == EventType.MouseUp)
                {
                    mouseIsDown = false;
                }
                if (slots[index].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[index].itemImg);
                    if (slotRect.Contains(Event.current.mousePosition))
                    {
                        showTooltip = true;
                        CreateTooltip(slots[index]);
                        // dragging item
                        if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
                        {
                            draggingItem = true;
                            prevIndex = index;
                            draggedItem = slots[index];
                            items[index] = new Item();
                        }
                        if (e.type == EventType.mouseUp && draggingItem)
                        {
                            items[prevIndex] = items[index];
                            items[index] = draggedItem;
                            draggingItem = false;
                            draggedItem = null;
                        }
                        // right click in inventory
                        if (e.isMouse && e.type == EventType.mouseDown && e.button == 1)
                        {
                            if (slots[index].itemType == Item.ItemType.Consumable)
                            {
                                print("use consume");
                                //UseConsumable(slots[i], i, true);
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
                            items[prevIndex] = items[index];
                            items[index] = draggedItem;
                            draggingItem = false;
                        }
                    }
                    if (tooltip == "")
                    {
                        showTooltip = false;
                    }
                }
                ////////////////////////////////////////////////////////////
                yStart += ydis;
                index += 1;
            }
            xStart += xdis;
            yStart = 0;
        }
        
    }

    string CreateTooltip(Item item)
    {
        tooltip = "<color=#00ff00>" + item.itemName + "</color>\n" + item.itemDesc;
        return tooltip;
    }
}
