using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentUIItem : MonoBehaviour {

    public Item item;
    public Image itemImage;

    void Awake()
    {
        itemImage.sprite = Resources.Load<Sprite>("General/Sprites/Default Equip/" + name);
    }

    public void SetItem(Item item)
    {
        this.item = item;
        SetupItemValues();
    }

    void SetupItemValues()
    {
        itemImage.sprite = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
    }

    public void OnSelectItemButton()
    {
        if (itemImage.sprite.name != name)
            InventoryController.Instance.SetUnequipItemDetails(ItemDatabase.Instance.GetItem(itemImage.sprite.name), GetComponent<Button>());
    }

}
