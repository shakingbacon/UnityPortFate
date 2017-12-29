using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    Item item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText, itemType;

    public Text statText;

    void Awake()
    {
        itemNameText = transform.FindChild("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.FindChild("Item_Description").GetComponent<Text>();
        itemInteractButton = transform.FindChild("Action").GetComponent<Button>();
        itemInteractButtonText = itemInteractButton.transform.FindChild("Text").GetComponent<Text>();
        itemType = transform.FindChild("Item_Type").GetComponent<Text>();
        gameObject.SetActive(false);
    }


    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats.Stats)
            {
                if (stat.FinalValue != 0)
                    statText.   text += string.Format("{0}: {1}\n", stat.Type, stat.BaseValue);
            }
        }
        this.item = item;
        itemInteractButton.onClick.RemoveAllListeners();
        selectedItemButton = selectedButton;
        itemNameText.text = item.Name;
        itemDescriptionText.text = item.Description + "\nCost: $" + item.Cost;
        itemInteractButtonText.text = "Use";//item.;
        itemInteractButton.onClick.AddListener(OnItemInteract);

        // type
        if (item.ItemType == Item.ItemTypes.Weapon)
        {
            itemType.text = "(" + item.WeaponType.ToString() + ")";
        }
        else
        {
            itemType.text = "(" + item.ArmorType.ToString() + ")";
        }


    }

    public void SetUnequipItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats.Stats)
            {
                statText.text += string.Format("{0}: {1}\n", stat.Type, stat.BaseValue);
            }
        }
        this.item = item;
        itemInteractButton.onClick.RemoveAllListeners();
        selectedItemButton = selectedButton;
        itemNameText.text = item.Name;
        itemDescriptionText.text = item.Description + "\nCost: $" + item.Cost;
        itemInteractButtonText.text = "Unequip";
        itemInteractButton.onClick.AddListener(() => OnItemUnequip());
    }


    public void OnItemUnequip()
    {
        if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.playerWeaponController.UnequipWeapon(item);
        }
        else if (item.ItemType == Item.ItemTypes.Armor)
        {
            InventoryController.Instance.playerArmorController.UnequipArmor(item);
        }
        item = null;
        gameObject.SetActive(false);

    }

    public void OnItemInteract()
    {
        if (item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipWeapon(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == Item.ItemTypes.Armor)
        {
            InventoryController.Instance.EquipArmor(item);
            Destroy(selectedItemButton.gameObject);
        }
        UIEventHandler.ItemRemovedFromInventory();
        item = null;
        gameObject.SetActive(false);
    }
}
