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
        SoundDatabase.PlaySound(0);
        OnEquipItem?.Invoke(item);
    }

    public event InventoryController.ItemEventHandler OnUnequipItem;

    public void UnequipItem(Item item)
    {
        SoundDatabase.PlaySound(0);
        OnUnequipItem?.Invoke(item);
    }
}