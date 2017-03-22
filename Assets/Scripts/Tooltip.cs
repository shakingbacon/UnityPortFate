using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour {
    //public GUISkin skin;
    ////public SlotButton slotButton;
    //void Start()
    //{
    //    slotButton = slotButton.GetComponent<SlotButton>();
    //}
    //public bool DrawTooltip(Item item)
    //{
    //    float toolX = Event.current.mousePosition.x;
    //    float toolY = Event.current.mousePosition.y;
    //    float toolW = 290;
    //    float toolH = 115 + item.itemTooltip.Length * 0.61f;
    //    // goes past bottom and right
    //    if (item.itemID != -1)
    //    {
    //        if (toolX + toolW > Screen.width && toolY + toolH > Screen.height)
    //        {
    //            GUI.Box(new Rect(Screen.width - toolW, Screen.height - toolH, toolW, toolH), item.itemTooltip, skin.GetStyle("Tooltip"));
    //        }
    //        // goes past right
    //        else if (toolX + toolW > Screen.width)
    //        {
    //            GUI.Box(new Rect(Screen.width - toolW, toolY, toolW, toolH), item.itemTooltip, skin.GetStyle("Tooltip"));
    //        }
    //        // goes past bottom
    //        else if (toolY + toolH > Screen.height)
    //        {
    //            GUI.Box(new Rect(toolX, Screen.height - toolH, toolW, toolH), item.itemTooltip, skin.GetStyle("Tooltip"));
    //        }
    //        else
    //        {
    //            GUI.Box(new Rect(toolX, toolY, toolW, toolH), item.itemTooltip, skin.GetStyle("Tooltip"));
    //        }
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }

    //}

}
