using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance { get; set; }
    public ConsumableController consumableController;
    public PlayerWeaponController playerWeaponController;
    public InventoryUIDetails inventoryDetailsPanel;

    public List<NewItem> playerItems = new List<NewItem>();

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        consumableController = GetComponent<ConsumableController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
        GiveItem("Test Sword");
        GiveItem("Log Potion");
        GiveItem("Longsword");
        GiveItem("Wooden Staff");
        GiveItem("Leather Hat");
        GiveItem("Leather Gloves");
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        playerWeaponController.EquipWeapon(new NewItem(new List<BaseStat>(), "staff"));
    //    }
    //}
	
    public void GiveItem(string itemName)
    {
        NewItem item = NewItemDatabase.Instance.GetItem(itemName);
        //print(item.ItemName);
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);

    }

    public void SetItemDetails(NewItem item, Button selectedButton)
    {
        inventoryDetailsPanel.SetItem(item, selectedButton);
    }

    public void EquipItem(NewItem itemToEquip)
    {
        playerWeaponController.EquipWeapon(itemToEquip);
    }

    public void ConsumeItem(NewItem itemToConsume)
    {
        consumableController.ConsumeItem(itemToConsume);
    }

}
