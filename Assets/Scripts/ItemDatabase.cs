using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();
    // Use this for initialization
    void Start() {
        // int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost
        // Mage #1000, Rouge #2000, Warrior #3000, Consumables 9000, Accessories 9100
        // Weapons 0-49/50-99, Head 100, Body 200, Bottom 300, Hands 400, Boots 500, Shield 600
        //// Weapons
        // Swords
        items.Add(new Item("Inner", 0, "Strong base but weak tip", 3,0,0,0, 15,0, 0,0, 0,0, -12,0,0,0, 200, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Tipper", 1, "Strong tip but weak base", -2, 0, 5, 0, 0, 0, 0, 0, 0, 0, 8, 0, 5, 25, 200, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Katana", 2, "A sharp sword that can easily cut", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 450, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Scimitar", 3, "Made with a curved and very sharp blade", 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 525, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Shortsword", 4, "A cheap and easy to use sword", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 80, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Longsword", 5, "A standard sword", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Defense Sword", 6, "A big, broad sword that can block attacks", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 350, Item.ItemType.Weapon, Item.WeaponType.Sword));
        // Axes
        items.Add(new Item("Hachet", 50, "A small axe that can chop trees", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 125, Item.ItemType.Weapon, Item.WeaponType.Axe));
        items.Add(new Item("Battleaxe", 51, "A big, double-sided axe", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 400, Item.ItemType.Weapon, Item.WeaponType.Axe));
        items.Add(new Item("Big Axe", 52, "An huge, big axe", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 750, Item.ItemType.Weapon, Item.WeaponType.Axe));
        // Daggers
        items.Add(new Item("Long Dagger", 100, "A longer blade than a standard dagger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 120, Item.ItemType.Weapon, Item.WeaponType.Dagger));
        items.Add(new Item("Edged Dagger", 101, "A sharper dagger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, Item.ItemType.Weapon, Item.WeaponType.Dagger));
        items.Add(new Item("Poison Dagger", 102, "A dagger dipped in poison", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 500, Item.ItemType.Weapon, Item.WeaponType.Dagger));
        items.Add(new Item("Lighting Dagger", 103, "A dagger that can attack quickly", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 750, Item.ItemType.Weapon, Item.WeaponType.Dagger));
        items.Add(new Item("Balanced Dagger", 104, "Balanced in every way", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Weapon, Item.WeaponType.Dagger));
        // Shurikens
        items.Add(new Item("Paper Shuriken", 150, "Cheap and lightweight", 0,0,0,0, 0,0, 0,0, 0,0, 0,0,0,0, 200, Item.ItemType.Weapon, Item.WeaponType.Shuriken));
        items.Add(new Item("Bamboo Shuriken", 151, "Harder but still lightweight", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Shuriken));
        items.Add(new Item("Metal Shuriken", 152, "Stronger but heavier", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Shuriken));
        items.Add(new Item("Jade Shuriken", 153, "Crafted with Jade Dragon Stone. Posseses magical powers", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1500, Item.ItemType.Weapon, Item.WeaponType.Shuriken));
        ////// Armors
        // Body
        items.Add(new Item("Bronze Armor", 300, "Basic armor for warriors", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Armor, Item.ArmorType.Body));
        items.Add(new Item("Iron Armor", 301, "Armor stronger bronze", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Armor, Item.ArmorType.Body));
        items.Add(new Item("Steel Armor", 302, "Advance armor that is very durable", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Armor, Item.ArmorType.Body));
        items.Add(new Item("Diamond Armor", 303, "The strongest armor made from diamonds", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Armor, Item.ArmorType.Body));
        items.Add(new Item("Leather Robe", 304, "A simple robe made from cloth", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Armor, Item.ArmorType.Body));
        //// Mage
        // Wands
        items.Add(new Item("Wooden Wand", 1000, "Wand made from wood", 0, 3, 0, 0, 0, 75, 15, 40, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Wand));
        items.Add(new Item("Magic Wand", 1001, "A wand powered up by magic", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Wand));
        items.Add(new Item("Star Wand", 1002, "A wand blessed by the stars", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Wand));
        items.Add(new Item("Elemental Wand", 1003, "Imbued with all elemenets", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Wand));
        // Staffs
        items.Add(new Item("Wooden Staff", 1050, "A staff made from wood", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Staff));
        items.Add(new Item("Magic Staff", 1051, "Magic powered staff", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Staff));
        items.Add(new Item("Star Staff", 1052, "Stronger staff with powers of the stars", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Staff));
        items.Add(new Item("Elemental Staff", 1053, "Strong, magical staff with powers of all elemenets", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ItemType.Weapon, Item.WeaponType.Staff));
        // Head
        items.Add(new Item("Mage Hat", 1100, "A blue, mage hat", 0, 5, 0, 2, 0, 120, 0, 0, 10, 25, 0, 0, 0, 0, 350, Item.ItemType.Armor, Item.ArmorType.Head));
        // Body
        items.Add(new Item("Mage Robe", 1200, "A comfortable rob with mage", 0, 2, 0, 3, 0, 200, 0, 10, 15, 15, 0, 0, 0, 0, 450, Item.ItemType.Armor, Item.ArmorType.Body));
        // Bottom
        items.Add(new Item("Mage Longskirt", 1300, "Feel the power of magic arise", 0, 3, 4, 0, 0, 80, 0, 0, 16, 20, 0, 0, 0, 0, 300, Item.ItemType.Armor, Item.ArmorType.Bottom));
        // Hands
        items.Add(new Item("Mana Gloves", 1400, "Carry mana in the palm of your hands", 0, 1, 0, 1, 0, 400, 0, 0, 8, 10, 0, 0, 0, 0, 500, Item.ItemType.Armor, Item.ArmorType.Hands));
        // Boots
        items.Add(new Item("Mana Boots", 1500, "Mana while running", 0, 1, 0, 1, 0, 400, 0, 0, 8, 10, 0, 0, 0, 0, 500, Item.ItemType.Armor, Item.ArmorType.Boots));
        // Shield
        items.Add(new Item("Mana Shield", 1600, "A shield powered by mana", 0, 2, -2, -1, 0, 400, 0, 0, 25, 35, -5, -5, 0, 0, 750, Item.ItemType.Armor, Item.ArmorType.Shield));

        // Consumables
        items.Add(new Item("Health Potion", 9000, "Restore 100 HP", 25, Item.ItemType.Consumable));
        items.Add(new Item("Mana Potion", 9001, "Restore 150 MP", 25, Item.ItemType.Consumable));
        items.Add(new Item("Purple Potion", 9002, "Restore a little bit of HP and MP", 40, Item.ItemType.Consumable));
        // Accessories
        items.Add(new Item("Strength Necklace", 9100, "A necklace that increases your STR", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Intelligence Necklace", 9101, "A necklace that increases your INT", 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Agility Necklace", 9102, "A necklace that increases your AGI", 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Luck Necklace", 9103, "A necklace that increases your LUK", 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
    }
}
