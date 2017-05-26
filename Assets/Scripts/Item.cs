using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {
    public string itemName;
    public int itemID;
    public Sprite itemImg;
    public string itemDesc;
    public int itemBonusStr;
    public int itemBonusInt;
    public int itemBonusAgi;
    public int itemBonusLuk;
    public int itemBonusHP;
    public int itemBonusMP;
    public int itemBonusAtk;
    public int itemBonusMAtk;
    public int itemBonusManaComs;
    public int itemBonusDmgOutput;
    public int itemBonusDmgTaken;
    public int itemBonusArmor;
    public int itemBonusResist;
    public int itemBonusHit;
    public int itemBonusDodge;
    public int itemBonusCrit;
    public int itemBonusCritMulti;
    public int itemCost;
    public ItemType itemType;
    public WeaponType weaponType;
    public ArmorType armorType;
    public List<string> itemRegularText = new List<string>();
    public List<string> itemStatText = new List<string>();


    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        Food,
        None
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
        Neck,
        Shield,
        Hands,
        Bottom,
        Boots,
        Accessory,
        None
    }
    // Weapon
    public Item(string name, int id, string desc, WeaponType type)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Sprite>("Item Icons/" + name);
        itemDesc = desc;
        itemType = ItemType.Weapon;
        weaponType = type;
        armorType = ArmorType.None;
    }
    // Armor
    public Item(string name, int id, string desc, ArmorType type)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Sprite>("Item Icons/" + name);
        itemDesc = desc;
        itemType = ItemType.Armor;
        weaponType = WeaponType.None;
        armorType = type;
    }

    // Consumable Item
    public Item(string name, int id, string desc, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Sprite>("Item Icons/" + name);
        itemDesc = desc;
        itemType = type;
        weaponType = WeaponType.None;
        armorType = ArmorType.None;
    }

    public Item(string name, int id, string desc, int cost)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Sprite>("Food Icons/" + name);
        itemDesc = desc;
        itemCost = cost;
        itemType = ItemType.Food;
        weaponType = WeaponType.None;
        armorType = ArmorType.None;
    }

    // Empty Item
    public Item()
    {
        itemID = -1;
        itemType = ItemType.None;
        weaponType = WeaponType.None;
        armorType = ArmorType.None;
    }
    // Weapon Item
    //public Item(string name, int id, string desc,
    //    int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost, 
    //    WeaponType weapon)
    //{
    //    itemName = name;
    //    itemID = id;
    //    itemImg = Resources.Load<Sprite>("Item Icons/" + name);
    //    itemDesc = desc;
    //    itemBonusStr = bstr;
    //    itemBonusInt = bint;
    //    itemBonusAgi = bagi;
    //    itemBonusLuk = bluk;
    //    itemBonusHP = bhp;
    //    itemBonusMP = bmp;
    //    itemBonusAtk = batk;
    //    itemBonusMAtk = bmatk;
    //    itemBonusArmor = bdef;
    //    itemBonusResist = bresist;
    //    itemBonusHit = bhit;
    //    itemBonusDodge = bdodge;
    //    itemBonusCrit = bcrit;
    //    itemBonusCritMulti = bcritmulti;
    //    itemCost = cost;
    //    itemType = ItemType.Weapon;
    //    weaponType = weapon;
    //    armorType = ArmorType.None;


    //}
    //// Armor Item
    //public Item(string name, int id, string desc,
    //    int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost, ArmorType armor)
    //{
    //    itemName = name;
    //    itemID = id;
    //    itemImg = Resources.Load<Sprite>("Item Icons/" + name);
    //    itemDesc = desc;
    //    itemBonusStr = bstr;
    //    itemBonusInt = bint;
    //    itemBonusAgi = bagi;
    //    itemBonusLuk = bluk;
    //    itemBonusHP = bhp;
    //    itemBonusMP = bmp;
    //    itemBonusAtk = batk;
    //    itemBonusMAtk = bmatk;
    //    itemBonusArmor = bdef;
    //    itemBonusResist = bresist;
    //    itemBonusHit = bhit;
    //    itemBonusDodge = bdodge;
    //    itemBonusCrit = bcrit;
    //    itemBonusCritMulti = bcritmulti;
    //    itemCost = cost;
    //    itemType = ItemType.Armor;
    //    weaponType = WeaponType.None;
    //    armorType = armor;
    //}

    //// Accessories
    //public Item(string name, int id, string desc, 
    //            int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, 
    //            int cost, ItemType type)
    //{
    //    itemName = name;
    //    itemID = id;
    //    itemImg = Resources.Load<Sprite>("Item Icons/" + name);
    //    itemDesc = desc;
    //    itemBonusStr = bstr;
    //    itemBonusInt = bint;
    //    itemBonusAgi = bagi;
    //    itemBonusLuk = bluk;
    //    itemBonusHP = bhp;
    //    itemBonusMP = bmp;
    //    itemBonusAtk = batk;
    //    itemBonusMAtk = bmatk;
    //    itemBonusArmor = bdef;
    //    itemBonusResist = bresist;
    //    itemBonusHit = bhit;
    //    itemBonusDodge = bdodge;
    //    itemBonusCrit = bcrit;
    //    itemBonusCritMulti = bcritmulti;
    //    itemCost = cost;
    //    itemType = type;
    //    weaponType = WeaponType.None;
    //    armorType = ArmorType.None;
    //}

}
