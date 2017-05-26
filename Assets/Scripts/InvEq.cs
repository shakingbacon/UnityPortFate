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
        inventoryEquipment.FindChild("Garbage Button").GetComponent<Button>().onClick.AddListener(GarbageButton);
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
        cash.text = "Cash: $" + GameManager.player.cash;
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

    public static void GarbageButton()
    {
        if (isHoldingitem)
        {
            SoundDatabase.PlaySound(0);
            holdingItem = new Item();
            isHoldingitem = false;
            GameManager.player.AddCash(holdingItem.itemCost / 3);
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }

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
        SoundDatabase.PlaySound(21);
        showStats = show;
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").gameObject.SetActive(show);
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").FindChild("Stats").gameObject.SetActive(show);
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").FindChild("Item Desc").gameObject.SetActive(false);
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
        Mortal stats = GameManager.player;
        List<string> stringList = new List<string>(new string[]
        {
            string.Format("<color=#C40D0D>Strength: {0} + {1} = {2}</color>", stats.strength.baseAmount, stats.strength.buffedAmount, stats.strength.totalAmount),
            string.Format("<color=#0000FF>Intelligence: {0} + {1} = {2}</color>", stats.intelligence.baseAmount, stats.intelligence.buffedAmount, stats.intelligence.totalAmount),
            string.Format("<color=#00FF00>Agility: {0} + {1} = {2}</color>", stats.agility.baseAmount, stats.agility.buffedAmount, stats.agility.totalAmount),
            string.Format("<color=#F3F335>  Luck: {0} + {1} = {2}</color>", stats.luck.baseAmount, stats.luck.buffedAmount, stats.luck.totalAmount),
            string.Format("<color=#F00000>Max HP: {0} + {1} = {2}</color>", stats.maxHealth.baseAmount, stats.maxHealth.buffedAmount, stats.maxHealth.totalAmount),
            string.Format("<color=#2BF2F2>  Max MP: {0} + {1} = {2}</color>", stats.maxMana.baseAmount, stats.maxMana.buffedAmount, stats.maxMana.totalAmount),
            string.Format("<color=#EC2E2F>Phys Atk: {0} + {1} = {2}</color>", stats.physAtk.baseAmount, stats.physAtk.buffedAmount, stats.physAtk.totalAmount),
            string.Format("<color=#2200FF>  Magic Atk: {0} + {1} = {2}</color>", stats.magicAtk.baseAmount, stats.magicAtk.buffedAmount, stats.magicAtk.totalAmount),
            string.Format("<color=#000000>Defense: {0} + {1} = {2}</color>", stats.armor.baseAmount, stats.armor.buffedAmount, stats.armor.totalAmount),
            string.Format("<color=#04007f>  Resist: {0} + {1} = {2}</color>", stats.resist.baseAmount, stats.resist.buffedAmount, stats.resist.totalAmount),
            string.Format("<color=#2EEC61>Hit%: {0}% + {1}% = {2}%</color>", stats.hitChance.baseAmount, stats.hitChance.buffedAmount, stats.hitChance.totalAmount),
            string.Format("<color=#2EED8E>Dodge%: {0}% + {1}% = {2}%</color>", stats.dodgeChance.baseAmount, stats.dodgeChance.buffedAmount, stats.dodgeChance.totalAmount),
            string.Format("<color=#2EEDED>Crit% : {0}% + {1}% = {2}%</color>", stats.critChance.baseAmount, stats.critChance.buffedAmount, stats.critChance.totalAmount),
            string.Format("<color=#DEAB71>Crit Multi: {0}% + {1}% = {2}%</color>", stats.critMulti.baseAmount, stats.critMulti.buffedAmount, stats.critMulti.totalAmount),
            string.Format("<color=#2EEC61>DMG Output: {0}% + {1}% = {2}%</color>", stats.dmgOutput.baseAmount, stats.dmgOutput.buffedAmount, stats.dmgOutput.totalAmount),
            string.Format("<color=#2EEC61>DMG Taken: {0}% + {1}% = {2}%</color>", stats.dmgTaken.baseAmount, stats.dmgTaken.buffedAmount, stats.dmgTaken.totalAmount),
            string.Format("<color=#2EEC61>Mana Coms: {0}% + {1}% = {2}%</color>", stats.manaComs.baseAmount, stats.manaComs.buffedAmount, stats.manaComs.totalAmount)
    });
        int i = 0;
        foreach (Transform text in GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").FindChild("Stats"))
        {
            text.GetComponent<Text>().text = stringList[i];
            i += 1;
        }
    }

}
