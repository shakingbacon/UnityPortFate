using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {
    Item item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText;

    public Text statText;

    void Awake()
    {
        itemNameText = transform.FindChild("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.FindChild("Item_Description").GetComponent<Text>();
        itemInteractButton = transform.FindChild("Action").GetComponent<Button>();
        itemInteractButtonText= itemInteractButton.transform.FindChild("Text").GetComponent<Text>();
        gameObject.SetActive(false);
    }


    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats)
            {
                statText.text += string.Format("{0}: {1}\n", stat.StatName, stat.BaseValue);
            }
        }
        this.item = item;
        itemInteractButton.onClick.RemoveAllListeners();
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description + "\nCost: $" + item.ItemCost;
        itemInteractButtonText.text = item.ActionName;
        itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void SetUnequipItem(Item item, Button selectedButton, GameObject gameobj)
    {
        gameObject.SetActive(true);
        statText.text = "";
        if (item.Stats != null)
        {
            foreach (BaseStat stat in item.Stats)
            {
                statText.text += string.Format("{0}: {1}\n", stat.StatName, stat.BaseValue);
            }
        }
        this.item = item;
        itemInteractButton.onClick.RemoveAllListeners();
        selectedItemButton = selectedButton;
        itemNameText.text = item.ItemName;
        itemDescriptionText.text = item.Description + "\nCost: $" + item.ItemCost;
        itemInteractButtonText.text = "Unequip";
        itemInteractButton.onClick.AddListener(() => OnItemUnequip(gameobj));
    }


    public void OnItemUnequip(GameObject gameobj)
    {
        if (item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.playerWeaponController.UnequipWeapon();
        }
        else if (item.ItemType == Item.ItemTypes.Armor)
        {
            InventoryController.Instance.playerArmorController.UnequipArmor(gameobj);
        }
        UIEventHandler.ItemAddedToInventory(item);
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
        else if(item.ItemType == Item.ItemTypes.Armor)
        {
            InventoryController.Instance.EquipArmor(item);
            Destroy(selectedItemButton.gameObject);
        }
        UIEventHandler.ItemRemovedFromInventory();
        item = null;
        gameObject.SetActive(false);
    }
}
