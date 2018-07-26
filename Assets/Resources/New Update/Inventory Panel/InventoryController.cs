using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public delegate void CashEventHandler(int amount);
    public delegate void ItemEventHandler(Item item);

    public static InventoryController Instance { get; set; }

    public int Cash { get; set; }
    public GameObject InventoryPanel { get; private set; }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        InventoryPanel = GameManager.Instance.FindCanvasChild("Inventory Panel");
        PlayerEquipController.Instance.OnUnequipItem += AddItem;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) InventoryPanel.SetActive(!InventoryPanel.activeInHierarchy);
    }

    public event CashEventHandler OnCashAddedToInventory;

    public void AddCash(int amount)
    {
        Cash += amount;
        OnCashAddedToInventory?.Invoke(amount);
    }

    public event ItemEventHandler OnItemAddedToInventory;

    public void AddItem(Item item)
    {
        OnItemAddedToInventory?.Invoke(item);
    }
}