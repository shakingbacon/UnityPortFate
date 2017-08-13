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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!onInv)
            {
                InventoryButtonPress();
            }
            else
            {
                EquipmentButtonPress();
            }
        }
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
                   // equip.GetChild(0).GetComponent<Image>().SetNativeSize();

                }
            }
            else if (equip.name == item.ArmorType.ToString())
            {
                equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
                break;
                //equip.GetChild(0).GetComponent<Image>().SetNativeSize();
            }
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
