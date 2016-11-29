using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
    public string itemName;
    public int itemID;
    public Texture2D itemImg;
    public string itemDesc;
    public int itemBonusStr;
    public int itemBonusInt;
    public int itemBonusAgi;
    public int itemBonusLuk;
    public int itemBonusHP;
    public int itemBonusMP;
    public int itemBonusAtk;
    public int itemBonusMAtk;
    public int itemBonusDef;
    public int itemBonusResist;
    public int itemBonusHit;
    public int itemBonusDodge;
    public int itemBonusCrit;
    public int itemBonusCritMulti;
    public int itemCost;
    public ItemType itemType;
    public WeaponType weaponType;
    public ArmorType armorType;


    public enum ItemType
    {
        Weapon,
        Armor,
        Accessory,
        Consumable
    }
    public enum WeaponType
    {
        Sword,
        Axe,
        Dagger,
        Shuriken,
        Wand,
        Staff,
        None
    }
    public enum ArmorType
    {
        Head,
        Body,
        Left,
        Bottom,
        None
    }

    // Weapon Item
    public Item(string name, int id, string desc,
        int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost,
        ItemType type, WeaponType weapon)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemBonusStr = bstr;
        itemBonusInt = bint;
        itemBonusAgi = bagi;
        itemBonusLuk = bluk;
        itemBonusHP = bhp;
        itemBonusMP = bmp;
        itemBonusAtk = batk;
        itemBonusMAtk = bmatk;
        itemBonusDef = bdef;
        itemBonusResist = bresist;
        itemBonusHit = bhit;
        itemBonusDodge = bdodge;
        itemBonusCrit = bcrit;
        itemBonusCritMulti = bcritmulti;
        itemCost = cost;
        itemType = type;
        weaponType = weapon;
        armorType = ArmorType.None;


    }
    // Armor Item
    public Item(string name, int id, string desc,
        int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost,
        ItemType type, ArmorType armor)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemBonusStr = bstr;
        itemBonusInt = bint;
        itemBonusAgi = bagi;
        itemBonusLuk = bluk;
        itemBonusHP = bhp;
        itemBonusMP = bmp;
        itemBonusAtk = batk;
        itemBonusMAtk = bmatk;
        itemBonusDef = bdef;
        itemBonusResist = bresist;
        itemBonusHit = bhit;
        itemBonusDodge = bdodge;
        itemBonusCrit = bcrit;
        itemBonusCritMulti = bcritmulti;
        itemCost = cost;
        itemType = type;
        weaponType = WeaponType.None;
        armorType = armor;
    }

    // Accessories
    public Item(string name, int id, string desc, 
                int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemBonusStr = bstr;
        itemBonusInt = bint;
        itemBonusAgi = bagi;
        itemBonusLuk = bluk;
        itemBonusHP = bhp;
        itemBonusMP = bmp;
        itemBonusAtk = batk;
        itemBonusMAtk = bmatk;
        itemBonusDef = bdef;
        itemBonusResist = bresist;
        itemBonusHit = bhit;
        itemBonusDodge = bdodge;
        itemBonusCrit = bcrit;
        itemBonusCritMulti = bcritmulti;
        itemCost = cost;
        itemType = type;
        weaponType = WeaponType.None;
        armorType = ArmorType.None;
    }
    // Consumable Item
    public Item(string name, int id, string desc, int cost, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc; 
        itemCost = cost;
        itemType = type;
        weaponType = WeaponType.None;
        armorType = ArmorType.None;
    }
    // Empty Item
    public Item()
    {
        itemID = -1;
    }
}
