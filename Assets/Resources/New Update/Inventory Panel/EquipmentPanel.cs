using UnityEngine;
using UnityEngine.UI;

public class EquipmentPanel : MonoBehaviour
{
    private Sprite _bodyImg;
    private Sprite _bootsImg;
    private Sprite _bottomImg;
    private Sprite _glyphImg;

    // default images when there is nothing equipped to that slot
    private Sprite _handsImg;
    private Sprite _headImg;
    private Sprite _neckImg;
    private Sprite _necklaceImg;
    private Sprite _ringImg;
    private Sprite _shieldImg;
    private Sprite _weaponImg;

    private EquipmentItemHolder Hands { get; set; }
    private EquipmentItemHolder Neck { get; set; }
    private EquipmentItemHolder Head { get; set; }
    private EquipmentItemHolder Weapon { get; set; }
    private EquipmentItemHolder Body { get; set; }
    private EquipmentItemHolder Shield { get; set; }
    private EquipmentItemHolder Boots { get; set; }
    private EquipmentItemHolder Bottom { get; set; }
    private EquipmentItemHolder Necklace { get; set; }
    private EquipmentItemHolder Ring { get; set; }
    private EquipmentItemHolder Glyph { get; set; }

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

        _handsImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Hands");
        _neckImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Neck");
        _headImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Head");
        _weaponImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Weapon");
        _bodyImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Body");
        _shieldImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Shield");
        _bootsImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Boots");
        _bottomImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Bottom");
        _necklaceImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Necklace");
        _ringImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Ring");
        _glyphImg = Resources.Load<Sprite>("Icons/General/Sprites/Default Equip/Glyph");

        PlayerEquipController.Instance.OnEquipItem += EquipItem;
        PlayerEquipController.Instance.OnUnequipItem += UnequipItem;
    }

    private void CheckIfHasItem(EquipmentItemHolder position, Item item)
    {
        if (position.Item != null) PlayerEquipController.Instance.UnequipItem(position.Item);
        position.Item = item;
    }


    private void EquipItem(Item item)
    {
        print("equip panel");
        if (item is Weapon)
        {
            CheckIfHasItem(Weapon, item);
            PlayerWeapon.Instance.WieldWeapon(item);
        }
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

    private void UnequipItem(Item item)
    {
        if (item is Weapon)
        {
            Weapon.Item = null;
            Weapon.GetComponent<Image>().sprite = _weaponImg;
            PlayerWeapon.Instance.UnwieldWeapon();
        }
        else
        {
            if (item.ItemType == Armor.ArmorTypes.Hands.ToString())
            {
                Hands.Item = null;
                Hands.GetComponent<Image>().sprite = _handsImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Neck.ToString())
            {
                Neck.Item = null;
                Neck.GetComponent<Image>().sprite = _neckImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Head.ToString())
            {
                Head.Item = null;
                Head.GetComponent<Image>().sprite = _headImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Body.ToString())
            {
                Body.Item = null;
                Body.GetComponent<Image>().sprite = _bodyImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Shield.ToString())
            {
                Shield.Item = null;
                Shield.GetComponent<Image>().sprite = _shieldImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Boots.ToString())
            {
                Boots.Item = null;
                Boots.GetComponent<Image>().sprite = _bootsImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Bottom.ToString())
            {
                Bottom.Item = null;
                Bottom.GetComponent<Image>().sprite = _bottomImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Necklace.ToString())
            {
                Necklace.Item = null;
                Necklace.GetComponent<Image>().sprite = _necklaceImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Ring.ToString())
            {
                Ring.Item = null;
                Ring.GetComponent<Image>().sprite = _ringImg;
            }
            else if (item.ItemType == Armor.ArmorTypes.Glyph.ToString())
            {
                Glyph.Item = null;
                Glyph.GetComponent<Image>().sprite = _glyphImg;
            }
        }
    }
}