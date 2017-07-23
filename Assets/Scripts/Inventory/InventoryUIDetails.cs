using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIDetails : MonoBehaviour {
    NewItem item;
    Button selectedItemButton, itemInteractButton;
    Text itemNameText, itemDescriptionText, itemInteractButtonText;

    public Text statText;

    void Start()
    {
        itemNameText = transform.FindChild("Item_Name").GetComponent<Text>();
        itemDescriptionText = transform.FindChild("Item_Description").GetComponent<Text>();
        itemInteractButton = transform.FindChild("Button").GetComponent<Button>();
        itemInteractButtonText= itemInteractButton.transform.FindChild("Text").GetComponent<Text>();
        gameObject.SetActive(false);
    }


    public void SetItem(NewItem item, Button selectedButton)
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

    public void OnItemInteract()
    {
        if (item.ItemType == NewItem.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        else if (item.ItemType == NewItem.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(item);
            Destroy(selectedItemButton.gameObject);
        }
        item = null;
        gameObject.SetActive(false);
    }
}
