using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvEq : MonoBehaviour
{
    static Transform inventoryEquipment;
    public static Item holdingItem = new Item();
    public static bool isHoldingitem = false;
    public static bool showStats = false;
    public static Transform inventory;
    public static Transform statsButton;


    void Start()
    {
        inventoryEquipment = gameObject.transform;
        inventory = gameObject.transform.FindChild("Inventory");
        statsButton = gameObject.transform.FindChild("Stats Button");
        statsButton.GetComponent<Button>().onClick.AddListener(() => ShowStats(!showStats));
    }

    void Update()
    {
        //print(Input.mousePosition.x);
        if (holdingItem.itemID != -1)
        {
            inventoryEquipment.FindChild("Holding Item").transform.localPosition = new Vector3(Input.mousePosition.x - 360, Input.mousePosition.y - 260);
        }
    }

    public static void UpdateHoldingItem(Item item, bool isholding)
    {
        holdingItem = item;
        isHoldingitem = isholding;
        inventoryEquipment.FindChild("Holding Item").GetComponent<Image>().sprite = item.itemImg;
        inventoryEquipment.FindChild("Holding Item").GetComponent<Image>().enabled = isholding;
    }

    public static void UpdateHoldingItem(Item item)
    {
        holdingItem = item;
        inventoryEquipment.FindChild("Holding Item").GetComponent<Image>().sprite = item.itemImg;
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
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").GetComponentInChildren<Text>().text 
            = PlayerStats.makeStatsPage();
        if (!showStats)
        {
            statsButton.GetComponentInChildren<Text>().text = "Stats";
        }
        else
        {
            statsButton.GetComponentInChildren<Text>().text = "Close";
        }
    }

}
