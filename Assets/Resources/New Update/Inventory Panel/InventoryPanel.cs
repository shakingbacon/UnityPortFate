using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    int MaximumItems { get; set; } = 24;

    Transform items, equipment, holders;
    Text cash;
    [HideInInspector]
    public InventoryItemDescription itemDesc;
    [SerializeField]
    InventoryItemHolder holderPrefab;

    void Start()
    {
        items = transform.Find("Items Panel").Find("Items");
        holders = transform.Find("Items Panel").Find("Holders");
        equipment = transform.Find("Equipment Panel");

        cash = transform.Find("Cash").GetComponent<Text>();
        itemDesc = GetComponentInChildren<InventoryItemDescription>();
        //UpdateMoney();
        //UIEventHandler.OnMoneyAdd += UpdateMoney;
        InventoryController.Instance.OnItemAddedToInventory += AddItem;
        InventoryController.Instance.OnCashAddedToInventory += UpdateCashText;

        InventoryController.Instance.AddCash(100);
        InventoryController.Instance.AddItem(ItemDatabase.Instance.GetItem("Longsword"));
        InventoryController.Instance.AddItem(ItemDatabase.Instance.GetItem("Big Axe"));
        InventoryController.Instance.AddItem(ItemDatabase.Instance.GetItem("Leather Hat"));
        InventoryController.Instance.AddItem(ItemDatabase.Instance.GetItem("Wooden Staff"));
        //InvButtonClick();
        itemDesc.gameObject.SetActive(false);
    }

    void UpdateCashText(int amount = 0)
    {
        cash.text = "$ " + InventoryController.Instance.Cash;
    }

    void AddItem(Item item)
    {
        InventoryItemHolder add = Instantiate(holderPrefab, items);
        add.SetItem(item);
    }
}
