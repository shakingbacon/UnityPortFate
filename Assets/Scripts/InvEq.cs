using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvEq : MonoBehaviour
{
    public static Transform inventoryEquipment;
    public static Item holdingItem = new Item();
    public static bool isHoldingitem = false;
    public static bool showStats = false;
    public static Transform inventory;
    public static Transform statsButton;
    public static GameObject playerImage;
    public static Text cash;


    void Start()
    {
        inventoryEquipment = gameObject.transform;
        cash = inventoryEquipment.FindChild("Cash").GetComponent<Text>();
        playerImage = inventoryEquipment.FindChild("Player Image Box").gameObject;
        inventory = gameObject.transform.FindChild("Inventory");
        statsButton = gameObject.transform.FindChild("Stats Button");
        statsButton.GetComponent<Button>().onClick.AddListener(() => ShowStats(!showStats));
        inventoryEquipment.FindChild("Close Button").GetComponent<Button>().onClick.AddListener(() => GameManager.OpenClosePage("InventoryEquipment"));
        UpdateCashText();
    }

    void OnGUI()
    {
        //print(Input.mousePosition.x);
        if (holdingItem.itemID != -1)
        {
            float width = 80 * (Screen.width / 800f);
            float height = 80 * (Screen.height / 600f);
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y - height, width, height), Resources.Load<Texture2D>("Item Icons/" + holdingItem.itemName));
        }
    }

    public static void UpdateCashText()
    {
        cash.text = "Cash: $" + PlayerStats.stats.cash;
    }

    public static void UpdateHoldingItem(Item item, bool isholding)
    {
        holdingItem = item;
        isHoldingitem = isholding;
    }

    public static void UpdateHoldingItem(Item item)
    {
        holdingItem = item;
    }
    // slots are inventory or equipment
    public static void InsertItem(Transform slots, int slotindex, int itemindex)
    {
        slots.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item = ItemDatabase.GetItem(itemindex);
        slots.GetChild(slotindex).GetChild(0).GetComponent<Image>().sprite = slots.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item.itemImg;
        slots.GetChild(slotindex).GetChild(0).GetComponent<Image>().enabled = true;
    }

    public static void CleanSlot(Transform slots, int slotindex)
    {
        slots.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item = new Item();
        slots.GetChild(slotindex).GetChild(0).GetComponent<Image>().sprite = slots.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item.itemImg;
        slots.GetChild(slotindex).GetChild(0).GetComponent<Image>().enabled = false;
    }

    public static Item GetItem(Transform slots, int slotindex)
    {
        return slots.GetChild(slotindex).GetChild(0).GetComponent<ItemHolder>().item;
    }

    public static void ShowStats(bool show)
    {
        showStats = show;
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(show);
        UpdateStatsDesc();
        if (!showStats)
        {
            statsButton.GetComponentInChildren<Text>().text = "Stats";
        }
        else
        {
            statsButton.GetComponentInChildren<Text>().text = "Close";
        }
    }
    public static void UpdateStatsDesc()
    {
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").GetComponentInChildren<Text>().text
    = PlayerStats.makeStatsPage();
    }

}
