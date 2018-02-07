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
    public Text cashPanelAmount;

    [SerializeField] PlayerWeaponController playerWeaponController;
    [SerializeField] PlayerArmorController playerArmorController;
    bool onInv { get; set; }




    GameObject Hands { get; set; }
    GameObject Neck { get; set; }
    GameObject Head { get; set; }
    GameObject Weapon { get; set; }
    GameObject Body { get; set; }
    GameObject Shield { get; set; }
    GameObject Boots { get; set; }
    GameObject Bottom { get; set; }
    GameObject Necklace { get; set; }
    GameObject Ring { get; set; }
    GameObject Glyph { get; set; }



    void Start()
    {
        Hands = equipmentPanel.transform.Find("Hands").gameObject;
        Neck = equipmentPanel.transform.Find("Neck").gameObject;
        Head = equipmentPanel.transform.Find("Head").gameObject;
        Weapon = equipmentPanel.transform.Find("Weapon").gameObject;
        Body = equipmentPanel.transform.Find("Body").gameObject;
        Shield = equipmentPanel.transform.Find("Shield").gameObject;
        Boots = equipmentPanel.transform.Find("Boots").gameObject;
        Bottom = equipmentPanel.transform.Find("Bottom").gameObject;
        Necklace = equipmentPanel.transform.Find("Necklace").gameObject;
        Ring = equipmentPanel.transform.Find("Ring").gameObject;
        Glyph = equipmentPanel.transform.Find("Glyph").gameObject;

        UpdateMoney();
        onInv = false;
        InventoryButtonPress();
        UIEventHandler.OnItemEquipped += WearItem;
        UIEventHandler.OnItemUnequipped += UnwearItem;
        UIEventHandler.OnMoneyAdd += UpdateMoney;
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

    public void UpdateMoney(int amount = 0)
    {
        cashPanelAmount.text = InventoryController.Instance.Cash.ToString();
    }

    
    public void WearItem(Item item)
    {
        GameObject place = null;
        if (item is Weapon)
        {
            place = Weapon;
        }
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString()) place = Hands;
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString()) place = Neck;
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString()) place = Head;
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString()) place = Body;
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString()) place = Shield;
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString()) place = Boots;
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString()) place = Bottom;
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString()) place = Necklace;
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString()) place = Ring;
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString()) place = Glyph;

            //switch (item.ItemType)
            //{
            //    case Armor.ArmorTypes.Hands.ToString(): { place = Hands; break; }
            //    case Armor.ArmorTypes.Neck: { place = Neck; break; }
            //    case Armor.ArmorTypes.Head: { place = Head; break; }
            //    case Armor.ArmorTypes.Body: { place = Body; break; }
            //    case Armor.ArmorTypes.Shield: { place = Shield; break; }
            //    case Armor.ArmorTypes.Boots: { place = Boots; break; }
            //    case Armor.ArmorTypes.Bottom: { place = Bottom; break; }
            //    case Armor.ArmorTypes.Necklace: { place = Necklace; break; }
            //    case Armor.ArmorTypes.Ring: { place = Ring; break; }
            //    case Armor.ArmorTypes.Glyph: { place = Glyph; break; }
            //}
        }
        place.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.Name);
    }

    public void UnwearItem(Item item)
    {
        GameObject place = null;
        if (item is Weapon)
        {
            place = Weapon;
        }
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString()) place = Hands;
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString()) place = Neck;
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString()) place = Head;
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString()) place = Body;
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString()) place = Shield;
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString()) place = Boots;
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString()) place = Bottom;
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString()) place = Necklace;
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString()) place = Ring;
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString()) place = Glyph;
        }
        place.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("General/Sprites/Default Equip/" + place.name);
    }

    //public void UpdateEquipment(Item item)
    //{
    //    foreach (Transform equip in equipmentPanel.transform)
    //    {

    //        if (item.GetType() == typeof(Weapon))
    //        {
    //            if (equip.name == item.ToString())
    //            {
    //                equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.Name);
    //               // equip.GetChild(0).GetComponent<Image>().SetNativeSize();

    //            }
    //        }
    //        else if (equip.name == item.ArmorType.ToString())
    //        {
    //            equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.Name);
    //            break;
    //            //equip.GetChild(0).GetComponent<Image>().SetNativeSize();
    //        }
    //    }
    //}

    //public void UpdateItemUnequipped(Item item)
    //{
    //    foreach (Transform equip in equipmentPanel.transform)
    //    {
    //        if (item.ItemType == Item.ItemTypes.Weapon)
    //        {
    //            if (equip.name == item.ItemType.ToString())
    //            {
    //                equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("General/Sprites/Default Equip/" + item.ItemType);
    //                break;
    //            }
    //        }
    //        else if (item.ItemType == Item.ItemTypes.Armor)
    //        {
    //            if (equip.name == item.ArmorType.ToString())
    //            {
    //                equip.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("General/Sprites/Default Equip/" + item.ArmorType);
    //                break;
    //            }
    //        }
    //    }
    //}



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
