using UnityEngine;
using System.Collections;

public class Tooltip : MonoBehaviour {
    public GUISkin skin;
    public SlotButton slotButton;
    void Start()
    {
        slotButton = slotButton.GetComponent<SlotButton>();
    }
    public void DrawTooltip()
    {
        float toolX = Event.current.mousePosition.x;
        float toolY = Event.current.mousePosition.y;
        float toolW = 290;
        float toolH = 115 + slotButton.tooltip.Length * 0.61f;
        // goes past bottom and right
        if (toolX + toolW > Screen.width && toolY + toolH > Screen.height)
        {
            GUI.Box(new Rect(Screen.width - toolW, Screen.height - toolH, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
        }
        // goes past right
        else if (toolX + toolW > Screen.width)
        {
            GUI.Box(new Rect(Screen.width - toolW, toolY, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
        }
        // goes past bottom
        else if (toolY + toolH > Screen.height)
        {
            GUI.Box(new Rect(toolX, Screen.height - toolH, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
        }
        else
        {
            GUI.Box(new Rect(toolX, toolY, toolW, toolH), slotButton.tooltip, skin.GetStyle("Tooltip"));
        }
    }

}
