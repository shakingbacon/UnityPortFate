using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour
{
    Item SelectedItem { get; set; }
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
                    statText.text += string.Format("{0}: {1}\n", stat.Type, stat.BaseValue);
            }
        }
        SelectedItem = item;
        itemInteractButton.onClick.RemoveAllListeners();
        selectedItemButton = selectedButton;
        itemNameText.text = item.Name;
        itemDescriptionText.text = item.Description + "\nCost: $" + item.Cost;
        itemInteractButtonText.text = "Use";//item.;
        itemInteractButton.onClick.AddListener(OnItemInteract);
        itemType.text = string.Format("({0})", item.ItemType);
        // type
        //if (item is Weapon)
        //{
        //    Weapon weapon = (Weapon)item;
        //    itemType.text = "(" + weapon.Type + ")";
        //}
        //else
        //{
        //    Armor armor = (Armor)item;
        //    itemType.text = "(" + armor.Type + ")";
        //}


    }

    public void SetUnequipItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats.Stats)
            {
                if (stat.BaseValue != 0)
                    statText.text += string.Format("{0}: {1}\n", stat.Type, stat.BaseValue);
            }
        }
        SelectedItem = item;
        itemInteractButton.onClick.RemoveAllListeners();
        selectedItemButton = selectedButton;
        itemNameText.text = item.Name;
        itemDescriptionText.text = item.Description + "\nCost: $" + item.Cost;
        itemInteractButtonText.text = "Unequip";
        itemInteractButton.onClick.AddListener(() => OnItemUnequip());
    }


    public void OnItemUnequip()
    {
        if (SelectedItem is Weapon)
        {
            InventoryController.Instance.playerWeaponController.UnequipWeapon(SelectedItem);
        }
        else
        {
            InventoryController.Instance.playerArmorController.UnequipArmor(SelectedItem);
        }
        SelectedItem = null;
        gameObject.SetActive(false);

    }

    public void OnItemInteract()
    {
        if (SelectedItem is Consumable)
        {
            InventoryController.Instance.ConsumeItem(SelectedItem);
            Destroy(selectedItemButton.gameObject);
        }
        else if (SelectedItem is Weapon)
        {
            InventoryController.Instance.EquipWeapon(SelectedItem);
            Destroy(selectedItemButton.gameObject);
        }
        else
        {
            InventoryController.Instance.EquipArmor(SelectedItem);
            Destroy(selectedItemButton.gameObject);
        }
        UIEventHandler.ItemRemovedFromInventory();
        SelectedItem = null;
        gameObject.SetActive(false);
    }
}
