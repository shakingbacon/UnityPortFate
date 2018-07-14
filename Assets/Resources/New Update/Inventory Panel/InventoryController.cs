using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }


    public int Cash { get; set; } = 0;
    GameObject invPanel;
    public GameObject InventoryPanel { get { return invPanel; } }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        invPanel = GameManager.Instance.FindCanvasChild("Inventory Panel");
        PlayerEquipController.Instance.OnUnequipItem += AddItem;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);
    }


    public delegate void CashEventHandler(int amount);
    public event CashEventHandler OnCashAddedToInventory;
    public void AddCash(int amount)
    {
        Cash += amount;
        OnCashAddedToInventory(amount);
    }

    public delegate void ItemEventHandler(Item item);
    public event ItemEventHandler OnItemAddedToInventory;
    public void AddItem(Item item)
    {
        OnItemAddedToInventory(item);
    }







}
