using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance { get; set; }
    public ConsumableController consumableController;
    public PlayerWeaponController playerWeaponController;
    public PlayerArmorController playerArmorController;
    public InventoryUIDetails inventoryDetailsPanel;

    public List<Item> playerItems = new List<Item>();

    public int Cash { get; set; }

    void Start()
    {
        UIEventHandler.OnMoneyAdd += GiveMoney;
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        consumableController = GetComponent<ConsumableController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
        playerArmorController = GetComponent<PlayerArmorController>();
        //GiveItem("Test Sword");
        //GiveItem("Log Potion");
        GiveItem("Longsword");
        //GiveItem("Wooden Staff");
        //GiveItem("Leather Hat");
        //GiveItem("Big Axe");
        //GiveItem("Leather Gloves");
        //GiveItem("Strength Necklace");
        //GiveItem("Big Axe");

    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        playerWeaponController.EquipWeapon(new Item(new List<BaseStat>(), "staff"));
    //    }
    //}

    void GiveMoney(int amount)
    {
        Cash += amount;
        print(Cash);
    }

    public void GiveItem(string itemName)
    {
        Item item = ItemDatabase.Instance.GetItem(itemName);
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void GiveItem(Item item)
    {
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void SetUnequipItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetUnequipItem(item, selectedButton);
    }

    public void SetItemDetails(Item item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipWeapon(Item itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(Item itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }

    public void EquipArmor(Item itemToEquip)
    {
        playerArmorController.EquipArmor(itemToEquip);
    }
}
