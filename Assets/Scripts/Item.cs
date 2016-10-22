using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
    public string itemName;
    public int itemID;
    public Texture2D itemImg;
    public string itemDesc;
    public int itemAtk;
    public int itemMAtk;
    public int itemDef;
    public int itemResist;
    public int itemCost;
    public ItemType itemType;
    public WeaponType weaponType;
    public ArmorType armorType;
   

    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable
    }
    public enum WeaponType
    {
        Sword,
        Axe,
        Dagger,
        Shuriken,
        Wand,
        Staff
    }
    public enum ArmorType
    {
        Head,
        Body,
        Left,
        Bottom
    }
    
    // Weapon Item
    public Item(string name, int id, string desc, int atk, int matk, int cost, ItemType type, WeaponType weapon)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemAtk = atk;
        itemMAtk = matk;
        itemCost = cost;
        itemType = type;
        weaponType = weapon;


    }
    // Armor Item
    public Item(string name, int id, string desc, int def, int resist, int cost, ItemType type, ArmorType armor)
    {
        itemName = name;
        itemID = id;
        itemImg = Resources.Load<Texture2D>("Item Icons/" + name);
        itemDesc = desc;
        itemDef = def;
        itemResist = resist;
        itemCost = cost;
        itemType = type;
        armorType = armor;
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
    }
    // Empty Item
    public Item()
    {
        itemID = -1;
    }
}
