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

    // default images when there is nothing equipped to that slot
    Sprite handsIMG, neckIMG, headIMG, weaponIMG, bodyIMG,
        shieldIMG, bootsIMG, bottomIMG, necklaceIMG, ringIMG, glyphIMG;

    private void Awake()
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

        handsIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Hands");
        neckIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Neck");
        headIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Head");
        weaponIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Weapon");
        bodyIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Body");
        shieldIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Shield");
        bootsIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Boots");
        bottomIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Bottom");
        necklaceIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Necklace");
        ringIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Ring");
        glyphIMG = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Glyph");

        PlayerEquipController.Instance.OnEquipItem += EquipItem;
        PlayerEquipController.Instance.OnUnequipItem += UnequipItem;
    }

    void CheckIfHasItem(EquipmentItemHolder position, Item item)
    {
        if (position.Item != null) PlayerEquipController.Instance.UnequipItem(position.Item);
        position.Item = item;
    }


    void EquipItem(Item item)
    {
        print("equip panel");
        if (item is Weapon) { CheckIfHasItem(Weapon, item); PlayerWeapon.Instance.WieldWeapon(item); }
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString()) CheckIfHasItem(Weapon, item);
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString()) CheckIfHasItem(Neck, item);
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString()) CheckIfHasItem(Head, item);
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString()) CheckIfHasItem(Body, item);
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString()) CheckIfHasItem(Shield, item);
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString()) CheckIfHasItem(Boots, item);
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString()) CheckIfHasItem(Bottom, item);
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString()) CheckIfHasItem(Necklace, item);
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString()) CheckIfHasItem(Ring, item);
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString()) CheckIfHasItem(Glyph, item);
        }
    }

    void UnequipItem(Item item)
    {
        if (item is Weapon) { Weapon.Item = null; Weapon.GetComponent<Image>().sprite = weaponIMG; PlayerWeapon.Instance.UnwieldWeapon(); }
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString()) { Hands.Item = (null); Hands.GetComponent<Image>().sprite = handsIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString()) { Neck.Item = (null); Neck.GetComponent<Image>().sprite = neckIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString()) { Head.Item = (null); Head.GetComponent<Image>().sprite = headIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString()) { Body.Item = (null); Body.GetComponent<Image>().sprite = bodyIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString()) { Shield.Item = (null); Shield.GetComponent<Image>().sprite = shieldIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString()) { Boots.Item = (null); Boots.GetComponent<Image>().sprite = bootsIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString()) { Bottom.Item = (null); Bottom.GetComponent<Image>().sprite = bottomIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString()) { Necklace.Item = (null); Necklace.GetComponent<Image>().sprite = necklaceIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString()) { Ring.Item = (null); Ring.GetComponent<Image>().sprite = ringIMG; }
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString()) { Glyph.Item = (null); Glyph.GetComponent<Image>().sprite = glyphIMG; }
        }
    }
}
