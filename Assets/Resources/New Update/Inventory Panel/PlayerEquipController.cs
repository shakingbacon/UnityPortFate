using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipController : MonoBehaviour
{
    public static PlayerEquipController Instance { get; set; }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public event InventoryController.ItemEventHandler OnEquipItem;
    public void EquipItem(Item item)
    {
        OnEquipItem(item);
    }

    public event InventoryController.ItemEventHandler OnUnequipItem;
    public void UnequipItem(Item item)
    {
        OnUnequipItem(item);
    }


}
