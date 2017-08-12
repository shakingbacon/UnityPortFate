using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {

    public Button invetoryButton;
    public Button equipmentButton;
    public GameObject inventoryPanel;
    public GameObject equipmentPanel;
    public GameObject inventoryDetails;

    [SerializeField] PlayerWeaponController playerWeaponController;
    [SerializeField] PlayerArmorController playerArmorController;
    bool onInv { get; set; }

    void Start()
    {
        onInv = false;
        InventoryButtonPress();
        UIEventHandler.OnItemEquipped += UpdateEquipment;
    }

    public void InventoryButtonPress()
    {
        if (!onInv)
        {
            onInv = !onInv;
            inventoryPanel.SetActive(onInv);
            equipmentPanel.SetActive(!onInv);
            inventoryDetails.SetActive(false);
        }
    }

    public void UpdateEquipment(Item item)
    {
        foreach (Transform equip in equipmentPanel.transform)
        {
            if (item.ItemType == Item.ItemTypes.Weapon)
            {
                if (equip.name == item.ItemType.ToString())
                {
                    equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);

                }
            }
            else if (equip.name == item.ArmorType.ToString())
            {
                equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
            }
        }
    }


    public void UnequipEquipmentButtonPress(GameObject equipment)
    {
        if (equipment.name != "Accessory")
        {
            if (equipment.name == "Weapon")
            {
                playerWeaponController.UnequipWeapon();
            }
            else if (playerArmorController.FindArmor(equipment.name).transform.childCount != 0)
            {
                playerArmorController.UnequipArmor(equipment.name);
            }
            equipment.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("General/Sprites/Default Equip/" + equipment.name);
        }
    }


    public void EquipmentButtonPress()
    {
        if (onInv)
        {
            onInv = !onInv;
            equipmentPanel.SetActive(!onInv);
            inventoryPanel.SetActive(onInv);
            inventoryDetails.SetActive(false);
        }
    }
	
}
