using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
    public static List<Item> items = new List<Item>();
    public static List<List<Item>> shop = new List<List<Item>>();
    // Use this for initialization
    void Start()
    {
        // int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost
        // Mage #1000, Rouge #2000, Warrior #3000, Consumables 9000, Accessories 9100
        // Weapons 0-49/50-99, Head 100, Body 200, Bottom 300, Hands 400, Boots 500, Shield 600, Neck 700
        ///////////////////////////////
        //// Mage
        items.Add(new Item());
        // Wands
        items.Add(new Item("Wooden Wand", 1000, "Wand made from wood", 0, 3, 0, 0, 0, 75, 15, 40, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Wand));
        items.Add(new Item("Magic Wand", 1001, "A wand powered up by magic", 0, 5, 0, 0, 0, 100, 25, 70, 0, 0, 0, 0, 0, 0, 800, Item.WeaponType.Wand));
        items.Add(new Item("Star Wand", 1002, "A wand blessed by the stars", 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1900, Item.WeaponType.Wand));
        items.Add(new Item("Elemental Wand", 1003, "Imbued with all elemenets", 0, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3500, Item.WeaponType.Wand));
        // Staffs
        items.Add(new Item("Wooden Staff", 1050, "A staff made from wood", 0, 5, 0, 0, 0, 100, 30, 70, 6, 6, 0, 0, 0, 0, 300, Item.WeaponType.Staff));
        items.Add(new Item("Magic Staff", 1051, "Magic powered staff", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 900, Item.WeaponType.Staff));
        items.Add(new Item("Star Staff", 1052, "Stronger staff with powers of the stars", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2000, Item.WeaponType.Staff));
        items.Add(new Item("Elemental Staff", 1053, "Strong, magical staff with powers of all elemenets", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3600, Item.WeaponType.Staff));
        // Head
        items.Add(new Item("Leather Hat", 1100, "A basic hat for mages", 0, 2, 0, 1, 0, 100, 0, 0, 10, 20, 0, 0, 0, 0, 225, Item.ArmorType.Head));
        items.Add(new Item("Mage Hat", 1101, "A blue, magical hat", 0, 5, 0, 2, 0, 120, 0, 0, 10, 25, 0, 0, 0, 0, 350, Item.ArmorType.Head));
        // Body
        items.Add(new Item("White Blouse", 1200, "A fashionable shirt that looks good", 0, 0, 0, 0, 0, 50, 0, 0, 7, 10, 0, 0, 0, 0, 150, Item.ArmorType.Body));
        items.Add(new Item("Blue Blouse", 1201, "A fashionable shirt that looks good", 0, 0, 0, 0, 0, 100, 0, 0, 5, 7, 0, 0, 0, 0, 150, Item.ArmorType.Body));
        // Bottom
        items.Add(new Item("Leather Skirt", 1300, "Comfortable but fashionable", 0, 0, 1, 0, 0, 0, 0, 0, 9, 12, 0, 0, 0, 0, 125, Item.ArmorType.Bottom));
        items.Add(new Item("Mage Longskirt", 1301, "Feel the power of magic arise", 0, 3, 4, 0, 0, 80, 0, 0, 16, 20, 0, 0, 0, 0, 300, Item.ArmorType.Bottom));
        // Hands
        items.Add(new Item("Leather Gloves", 1400, "Useful for handling objects", 0, 0, 0, 1, 0, 0, 0, 0, 6, 6, 0, 0, 0, 0, 50, Item.ArmorType.Hands));
        items.Add(new Item("Mana Gloves", 1401, "Carry mana in the palm of your hands", 0, 1, 0, 1, 0, 400, 0, 0, 8, 10, 0, 0, 0, 0, 500, Item.ArmorType.Hands));
        // Boots
        items.Add(new Item("Leather Boots", 1500, "Durable shoes to walk in", 0, 0, 1, 0, 0, 0, 0, 0, 6, 8, 0, 0, 0, 0, 75, Item.ArmorType.Boots));
        items.Add(new Item("Mana Boots", 1501, "Mana while running", 0, 1, 0, 1, 0, 400, 0, 0, 8, 10, 0, 0, 0, 0, 500, Item.ArmorType.Boots));
        // Shield
        items.Add(new Item("Mana Shield", 1600, "A shield powered by mana", 0, 2, -2, -1, 0, 400, 0, 0, 25, 35, -5, -5, 0, 0, 750, Item.ArmorType.Shield));
        // Neck
        items.Add(new Item("Leather Cape", 1700, "A simple robe made from cloth", 0, 1, 0, 1, 0, 125, 0, 6, 8, 10, 0, 0, 0, 0, 200, Item.ArmorType.Neck));
        items.Add(new Item("Mage Cape", 1701, "A comfortable rob with mage", 0, 2, 0, 3, 0, 200, 0, 10, 12, 15, 0, 0, 0, 0, 450, Item.ArmorType.Neck));
        //////////////////////////////////////
        //// Rouge
        // Daggers
        items.Add(new Item("Long Dagger", 2000, "A longer blade than a standard dagger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 120, Item.WeaponType.Dagger));
        items.Add(new Item("Edged Dagger", 2001, "A sharper dagger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, Item.WeaponType.Dagger));
        items.Add(new Item("Poison Dagger", 2002, "A dagger dipped in poison", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 500, Item.WeaponType.Dagger));
        items.Add(new Item("Lighting Dagger", 2003, "A dagger that can attack quickly", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 750, Item.WeaponType.Dagger));
        items.Add(new Item("Balanced Dagger", 2004, "Balanced in every way", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.WeaponType.Dagger));
        // Shurikens
        items.Add(new Item("Paper Shuriken", 2050, "Cheap and lightweight", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Shuriken));
        items.Add(new Item("Bamboo Shuriken", 2051, "Harder but still lightweight", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Shuriken));
        items.Add(new Item("Metal Shuriken", 2052, "Stronger but heavier", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Shuriken));
        items.Add(new Item("Jade Shuriken", 2053, "Crafted with Jade Dragon Stone. Posseses magical powers", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1500, Item.WeaponType.Shuriken));
        //////////////////////////////////////
        //// Warrior
        // Swords
        items.Add(new Item("Inner", 3000, "Strong base but weak tip", 3, 0, 0, 0, 15, 0, 20, 5, 0, 0, -12, 0, 0, 0, 200, Item.WeaponType.Sword));
        items.Add(new Item("Tipper", 3001, "Strong tip but weak base", -2, 0, 6, 0, 0, 0, 13, 12, 0, 0, 8, 0, 8, 25, 200, Item.WeaponType.Sword));
        items.Add(new Item("Katana", 3002, "A sharp sword that can easily cut", 4, 0, 5, 0, 0, 0, 50, 30, 0, 0, 10, 0, 10, 30, 450, Item.WeaponType.Sword));
        items.Add(new Item("Scimitar", 3003, "Made with a curved and very sharp blade", 8, 0, 0, 0, 0, 0, 75, 15, 0, 0, 0, 0, 10, -10, 525, Item.WeaponType.Sword));
        items.Add(new Item("Shortsword", 3004, "A cheap and easy to use sword", 0, 0, 0, 0, 0, 0, 10, 5, 0, 0, 0, 0, 0, 0, 80, Item.WeaponType.Sword));
        items.Add(new Item("Longsword", 3005, "A standard sword", 0, 0, 0, 0, 0, 0, 20, 10, 0, 0, 0, 0, 0, 0, 280, Item.WeaponType.Sword));
        items.Add(new Item("Defense Sword", 3006, "A big, broad sword that can block attacks", 6, 0, 0, 0, 50, 0, 75, 60, 15, 15, 0, -8, -5, 0, 1750, Item.WeaponType.Sword));
        // Axes
        items.Add(new Item("Hachet", 3050, "A small axe that can chop trees", 7, 0, -2, 0, 0, 0, 25, 3, 0, 0, -10, 0, -5, 25, 200, Item.WeaponType.Axe));
        items.Add(new Item("Battleaxe", 3051, "A big, double-sided axe", 10, 0, -5, 0, 0, 0, 50, 10, 0, 0, -15, 0, -10, 40, 1000, Item.WeaponType.Axe));
        items.Add(new Item("Big Axe", 3052, "An huge, big axe", 13, 0, 0, 0, 0, 0, 100, 20, 0, 0, -25, 0, -15, 80, 2500, Item.WeaponType.Axe));
        // Body
        items.Add(new Item("Bronze Armor", 3200, "Basic armor for warriors", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));
        items.Add(new Item("Iron Armor", 3201, "Armor stronger bronze", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));
        items.Add(new Item("Steel Armor", 3202, "Advance armor that is very durable", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));
        items.Add(new Item("Diamond Armor", 3203, "The strongest armor made from diamonds", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));

        ///////////////////////
        // Consumables
        items.Add(new Item("Health Potion", 9000, "Restore 100 HP", 25, Item.ItemType.Consumable));
        items.Add(new Item("Mana Potion", 9001, "Restore 150 MP", 25, Item.ItemType.Consumable));
        items.Add(new Item("Purple Potion", 9002, "Restore a little bit of HP and MP", 40, Item.ItemType.Consumable));
        // Accessories
        items.Add(new Item("Strength Necklace", 9100, "A necklace that increases your STR", 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Intelligence Necklace", 9101, "A necklace that increases your INT", 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Agility Necklace", 9102, "A necklace that increases your AGI", 0, 0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Luck Necklace", 9103, "A necklace that increases your LUK", 0, 0, 0, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.ItemType.Accessory));
        items.Add(new Item("Luck Necklace", 9104, "A necklace that increases your LUK", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 50, 100, 1000, Item.ItemType.Accessory));

        shop.Add(new List<Item>());
        shop.Add(new List<Item>());
        shop.Add(new List<Item>());

        List<List<int>> shopItems =
            new List<List<int>>(new[]{
            new List<int>(new []{1000, 1001, 1002, 1003, 1050, 1051, 1052, 1053, 1100, 1200, 1201,1300, 1400, 1500, 1600, 1700}),
            new List<int>(new []{9100,9101, 9102, 9103}),
            new List<int>(new []{1, 2, 3, 4, 5, 6, 7})});
        // ADD ITEM TOOLTIPS
        for (int index = 0; index < items.Count; index += 1)
        {
            items[index].itemTooltip = CreateTooltip(items[index]);
        }
        AddItems(shop, shopItems);
    }

    public static Item GetItem(int id)
    {
        Item returnItem = new Item();
        for (int j = 0; j < items.Count; j += 1)
        {
            if (items[j].itemID == id)
            {
                returnItem = items[j];
                break;
            }
        }
        return returnItem;
    }

    private void AddItems(List<List<Item>> listToAdd, List<List<int>> listOfItems)
    {
        for (int k = 0; k < listOfItems.Count; k += 1)
        {
            while (shop[k].Count < 20)
            {
                shop[k].Add(new Item());
            }
            for (int l = 0; l < listOfItems[k].Count; l += 1)
            {
                for (int j = 0; j < items.Count; j += 1)
                {
                    if (items[j].itemID == listOfItems[k][l])
                    {
                        listToAdd[k][l] = items[j];
                        break;
                    }
                }
            }
        }
    }

    private string CreateTooltip(Item item)
    {
        string tooltip;
        // NAME
        tooltip = "<size=45><color=#000000>" + item.itemName + "</color></size>\n";
        // ITEM TYPE
        tooltip += "<size=35>";
        if (item.itemType == Item.ItemType.Accessory)
        {
            tooltip += "(<color=#FFABAB>" + item.itemType.ToString() + "</color>)\n";
        }
        else if (item.itemType == Item.ItemType.Armor)
        {
            if (item.armorType == Item.ArmorType.Head)
            {
                tooltip += "(<color=#3BCD58>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Neck)
            {
                tooltip += "(<color=#C40D0D>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Body)
            {
                tooltip += "(<color=#F7CA34>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Bottom)
            {
                tooltip += "(<color=#F78F34>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Shield)
            {
                tooltip += "(<color=#E57E18>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Boots)
            {
                tooltip += "(<color=#FF8000>" + item.armorType.ToString() + "</color>)\n";
            }
            else if (item.armorType == Item.ArmorType.Hands)
            {
                tooltip += "(<color=#18E418>" + item.armorType.ToString() + "</color>)\n";
            }
        }
        else if (item.itemType == Item.ItemType.Weapon)
        {
            if (item.weaponType == Item.WeaponType.Sword)
            {
                tooltip += "(<color=#FF0000>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Axe)
            {
                tooltip += "(<color=#0000CB>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Dagger)
            {
                tooltip += "(<color=#8B00A1>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Shuriken)
            {
                tooltip += "(<color=#900000>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Wand)
            {
                tooltip += "(<color=#914800>" + item.weaponType.ToString() + "</color>)\n";
            }
            else if (item.weaponType == Item.WeaponType.Staff)
            {
                tooltip += "(<color=#463811>" + item.weaponType.ToString() + "</color>)\n";

            }
        }
        else if (item.itemType == Item.ItemType.Consumable)
        {
            tooltip += "(<color=#81CAE1>" + item.itemType.ToString() + "</color>)\n";
        }
        tooltip += "</size>";
        // COST
        tooltip += "<size=22><color=#ECF32A>COST: $" + item.itemCost.ToString() + "</color></size>\n";
        // DESCRIPTION
        tooltip += "<size=17>" + item.itemDesc + "</size>\n";
        // BONUS STATS
        List<int> values = new List<int>
            (new int[] {item.itemBonusStr, item.itemBonusInt, item.itemBonusAgi, item.itemBonusLuk,
            item.itemBonusHP, item.itemBonusMP, item.itemBonusAtk, item.itemBonusMAtk,
            item.itemBonusDef, item.itemBonusResist,
            item.itemBonusHit, item.itemBonusDodge, item.itemBonusCrit, item.itemBonusCritMulti });
        List<string> desc = new List<string>
            (new string[] {"<color=#C40D0D>STR: " , "<color=#0000FF>INT: ", "<color=#00FF00>AGI: ",
                "<color=#F3F335>LUK: ", "<color=#F00000>HP: ", "<color=#2BF2F2>MP: ",
                "<color=#EC2E2F>ATK: ", "<color=#2200FF>MATK: ", "<color=#FFB811>DEF: ",
            "<color=#04007F>RES: ", "<color=#2EEC61>HIT: ", "<color=#2EED8E>DODGE: ",
                "<color=#2EEDED>CRIT: ", "<color=#DEAB71>CRITMULTI: "});
        for (int i = 0; i < values.Count; i += 2)
        {
            string string1 = "";
            string string2 = "";
            if (values[i] != 0)
            {
                if (values[i] > 0)
                {
                    string1 = "<size=25>" + desc[i] + "+" + values[i].ToString() + "</color></size>     ";
                }
                else
                {
                    string1 = "<size=25>" + desc[i] + values[i].ToString() + "</color></size>     ";
                }
            }
            if (values[i + 1] != 0)
            {
                if (values[i + 1] > 0)
                {
                    string2 = "<size=25>" + desc[i + 1] + "+" + values[i + 1].ToString() + "</color></size>";
                }
                else
                {
                    string2 = "<size=25>" + desc[i + 1] + values[i + 1].ToString() + "</color></size>";
                }
            }
            if (string1 != "" && string2 != "")
            {
                tooltip += string1 + string2 + "\n";
            }
            else if (string1 != "" && string2 == "")
            {
                tooltip += string1 + "\n";
            }
            else if (string1 == "" && string2 != "")
            {
                tooltip += string2 + "\n";
            }
        }
        return tooltip;
    }
}
