using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel2 : MonoBehaviour
{
    int MaximumItems { get; set; } = 24;

    Transform items;
    Text cash;
    public InventoryItemDescription itemDesc;

    [SerializeField]
    InventoryItemHolder holderPrefab;

    private void Start()
    {
        items = transform.Find("Items");
        cash = transform.Find("Cash").GetComponent<Text>();
        itemDesc = GetComponentInChildren<InventoryItemDescription>();
        //UpdateMoney();
        //UIEventHandler.OnMoneyAdd += UpdateMoney;
        AddItem(ItemDatabase.Instance.GetItem("Longsword"));
        AddItem(ItemDatabase.Instance.GetItem("Big Axe"));
        AddItem(ItemDatabase.Instance.GetItem("Leather Hat"));

    }

    void Update()
    {

    }

    void UpdateMoney(int amount = 0)
    {
        cash.text = InventoryController.Instance.Cash.ToString();
    }



    public void AddItem(Item item)
    {
        InventoryItemHolder add = Instantiate(holderPrefab, items);
        add.SetItem(item);

    }
}
