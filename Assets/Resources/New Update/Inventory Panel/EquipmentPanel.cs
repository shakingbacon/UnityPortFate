using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{
    EquipmentItemHolder Hands { get; set; }
    EquipmentItemHolder Neck { get; set; }
    EquipmentItemHolder Head { get; set; }
    EquipmentItemHolder Weapon { get; set; }
    EquipmentItemHolder Body { get; set; }
    EquipmentItemHolder Shield { get; set; }
    EquipmentItemHolder Boots { get; set; }
    EquipmentItemHolder Bottom { get; set; }
    EquipmentItemHolder Necklace { get; set; }
    EquipmentItemHolder Ring { get; set; }
    EquipmentItemHolder Glyph { get; set; }

    Sprite handsIMG, neckIMG, headIMG, weaponIMG, bodyIMG,
        shieldIMG, bootsIMG, bottomIMG, necklaceIMG, ringIMG, glyphIMG;

    private void Start()
    {
        Hands = transform.Find("Hands").GetComponentInChildren<EquipmentItemHolder>();
        Neck = transform.Find("Neck").GetComponentInChildren<EquipmentItemHolder>();
        Head = transform.Find("Head").GetComponentInChildren<EquipmentItemHolder>();
        Weapon = transform.Find("Weapon").GetComponentInChildren<EquipmentItemHolder>();
        Body = transform.Find("Body").GetComponentInChildren<EquipmentItemHolder>();
        Shield = transform.Find("Shield").GetComponentInChildren<EquipmentItemHolder>();
        Boots = transform.Find("Boots").GetComponentInChildren<EquipmentItemHolder>();
        Bottom = transform.Find("Bottom").GetComponentInChildren<EquipmentItemHolder>();
        Necklace = transform.Find("Necklace").GetComponentInChildren<EquipmentItemHolder>();
        Ring = transform.Find("Ring").GetComponentInChildren<EquipmentItemHolder>();
        Glyph = transform.Find("Glyph").GetComponentInChildren<EquipmentItemHolder>();

        handsIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Hands");
        neckIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Neck");
        headIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Head");
        weaponIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Weapon");
        bodyIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Body");
        shieldIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Shield");
        bootsIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Boots");
        bottomIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Bottom");
        necklaceIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Necklace");
        ringIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Ring");
        glyphIMG = Resources.Load<Sprite>("General/Sprites/Default Equip/Glyph");

        PlayerEquipController.Instance.OnEquipItem += EquipItem;
        PlayerEquipController.Instance.OnUnequipItem += UnequipItem;
    }

    void EquipItem(Item item)
    {
        if (item is Weapon) Weapon.SetItem(item);
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString()) Hands.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString()) Neck.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString()) Head.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString()) Body.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString()) Shield.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString()) Boots.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString()) Bottom.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString()) Necklace.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString()) Ring.SetItem(item);
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString()) Glyph.SetItem(item);
        }
    }

    void UnequipItem(Item item)
    {
        if (item is Weapon) Weapon.SetItem(item);
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString()) { Hands.SetItem(null); Hands.GetComponent<Image>().sprite = handsIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString()) { Neck.SetItem(null); Neck.GetComponent<Image>().sprite = neckIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString()) { Head.SetItem(null); Head.GetComponent<Image>().sprite = headIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString()) { Body.SetItem(null); Body.GetComponent<Image>().sprite = bodyIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString()) { Shield.SetItem(null); Shield.GetComponent<Image>().sprite = shieldIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString()) { Boots.SetItem(null); Boots.GetComponent<Image>().sprite = bootsIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString()) { Bottom.SetItem(null); Bottom.GetComponent<Image>().sprite = bottomIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString()) { Necklace.SetItem(null); Necklace.GetComponent<Image>().sprite = necklaceIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString()) { Ring.SetItem(null); Ring.GetComponent<Image>().sprite = ringIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString()) { Glyph.SetItem(null); Glyph.GetComponent<Image>().sprite = glyphIMG; }
        }
    }
}
