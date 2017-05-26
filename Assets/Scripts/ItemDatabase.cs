using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour
{
    public static List<Item> items = new List<Item>();
    public static List<ShopList> shopList = new List<ShopList>();
    // Use this for initialization
    void Start()
    {
        // int bstr, int bint, int bagi, int bluk, int bhp, int bmp, int batk, int bmatk, int bdef, int bresist, int bhit, int bdodge, int bcrit, int bcritmulti, int cost
        // Mage #1000, Rouge #2000, Warrior #3000, Consumables 9000, Accessories 9100
        // Weapons 0-49/50-99, Head 100, Body 200, Bottom 300, Hands 400, Boots 500, Shield 600, Neck 700
        ///////////////////////////////
        //// Mage
        items.Add(new Item());
        //// Wands
        items.Add(new Item("Wooden Wand", 1000, "Wand made from wood", Item.WeaponType.Wand));
        items.Add(new Item("Magic Wand", 1001, "A wand powered up by magic", Item.WeaponType.Wand));
        items.Add(new Item("Star Wand", 1002, "A wand blessed by the stars",  Item.WeaponType.Wand));
        items.Add(new Item("Elemental Wand", 1003, "Imbued with all elemenets",  Item.WeaponType.Wand));
        //// Staffs
        items.Add(new Item("Wooden Staff", 1050, "A staff made from wood", Item.WeaponType.Staff));
        items.Add(new Item("Magic Staff", 1051, "Magic powered staff", Item.WeaponType.Staff));
        items.Add(new Item("Star Staff", 1052, "Stronger staff with powers of the stars", Item.WeaponType.Staff));
        items.Add(new Item("Elemental Staff", 1053, "Strong, magical staff with powers of all elemenets", Item.WeaponType.Staff));
        // Head
        items.Add(new Item("Leather Hat", 1100, "A basic hat for mages", Item.ArmorType.Head));
        items.Add(new Item("Mage Hat", 1101, "A blue, magical hat", Item.ArmorType.Head));
        //// Body
        items.Add(new Item("White Blouse", 1200, "A fashionable shirt that looks good", Item.ArmorType.Body));
        items.Add(new Item("Blue Blouse", 1201, "A fashionable shirt that looks good", Item.ArmorType.Body));
        //// Bottom
        items.Add(new Item("Leather Skirt", 1300, "Comfortable but fashionable", Item.ArmorType.Bottom));
        items.Add(new Item("Mage Longskirt", 1301, "Feel the power of magic arise", Item.ArmorType.Bottom));
        //// Hands
        items.Add(new Item("Leather Gloves", 1400, "Useful for handling objects", Item.ArmorType.Hands));
        items.Add(new Item("Mana Gloves", 1401, "Carry mana in the palm of your hands", Item.ArmorType.Hands));
        //// Boots
        items.Add(new Item("Leather Boots", 1500, "Durable shoes to walk in", Item.ArmorType.Boots));
        items.Add(new Item("Mana Boots", 1501, "Mana while running", Item.ArmorType.Boots));
        //// Shield
        items.Add(new Item("Mana Shield", 1600, "A shield powered by mana", Item.ArmorType.Shield));
        //// Neck
        items.Add(new Item("Leather Cape", 1700, "A simple robe made from cloth", Item.ArmorType.Neck));
        items.Add(new Item("Mage Cape", 1701, "A comfortable rob with mage", Item.ArmorType.Neck));
        ////////////////////////////////////////
        ////// Rouge
        //// Daggers
        //items.Add(new Item("Long Dagger", 2000, "A longer blade than a standard dagger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 120, Item.WeaponType.Dagger));
        //items.Add(new Item("Edged Dagger", 2001, "A sharper dagger", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 250, Item.WeaponType.Dagger));
        //items.Add(new Item("Poison Dagger", 2002, "A dagger dipped in poison", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 500, Item.WeaponType.Dagger));
        //items.Add(new Item("Lighting Dagger", 2003, "A dagger that can attack quickly", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 750, Item.WeaponType.Dagger));
        //items.Add(new Item("Balanced Dagger", 2004, "Balanced in every way", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1000, Item.WeaponType.Dagger));
        //// Shurikens
        //items.Add(new Item("Paper Shuriken", 2050, "Cheap and lightweight", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Shuriken));
        //items.Add(new Item("Bamboo Shuriken", 2051, "Harder but still lightweight", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Shuriken));
        //items.Add(new Item("Metal Shuriken", 2052, "Stronger but heavier", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.WeaponType.Shuriken));
        //items.Add(new Item("Jade Shuriken", 2053, "Crafted with Jade Dragon Stone. Posseses magical powers", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1500, Item.WeaponType.Shuriken));
        ////////////////////////////////////////
        ////// Warrior
        //// Swords
        //items.Add(new Item("Inner", 3000, "Strong base but weak tip", 3, 0, 0, 0, 15, 0, 20, 5, 0, 0, -12, 0, 0, 0, 200, Item.WeaponType.Sword));
        //items.Add(new Item("Tipper", 3001, "Strong tip but weak base", -2, 0, 6, 0, 0, 0, 13, 12, 0, 0, 8, 0, 8, 25, 200, Item.WeaponType.Sword));
        //items.Add(new Item("Katana", 3002, "A sharp sword that can easily cut", 4, 0, 5, 0, 0, 0, 50, 30, 0, 0, 10, 0, 10, 30, 450, Item.WeaponType.Sword));
        //items.Add(new Item("Scimitar", 3003, "Made with a curved and very sharp blade", 8, 0, 0, 0, 0, 0, 75, 15, 0, 0, 0, 0, 10, -10, 525, Item.WeaponType.Sword));
        //items.Add(new Item("Shortsword", 3004, "A cheap and easy to use sword", 0, 0, 0, 0, 0, 0, 10, 5, 0, 0, 0, 0, 0, 0, 80, Item.WeaponType.Sword));
        //items.Add(new Item("Longsword", 3005, "A standard sword", 0, 0, 0, 0, 0, 0, 20, 10, 0, 0, 0, 0, 0, 0, 280, Item.WeaponType.Sword));
        //items.Add(new Item("Defense Sword", 3006, "A big, broad sword that can block attacks", 6, 0, 0, 0, 50, 0, 75, 60, 15, 15, 0, -8, -5, 0, 1750, Item.WeaponType.Sword));
        //// Axes
        //items.Add(new Item("Hachet", 3050, "A small axe that can chop trees", 7, 0, -2, 0, 0, 0, 25, 3, 0, 0, -10, 0, -5, 25, 200, Item.WeaponType.Axe));
        //items.Add(new Item("Battleaxe", 3051, "A big, double-sided axe", 10, 0, -5, 0, 0, 0, 50, 10, 0, 0, -15, 0, -10, 40, 1000, Item.WeaponType.Axe));
        //items.Add(new Item("Big Axe", 3052, "An huge, big axe", 13, 0, 0, 0, 0, 0, 100, 20, 0, 0, -25, 0, -15, 80, 2500, Item.WeaponType.Axe));
        //// Body
        //items.Add(new Item("Bronze Armor", 3200, "Basic armor for warriors", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));
        //items.Add(new Item("Iron Armor", 3201, "Armor stronger bronze", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));
        //items.Add(new Item("Steel Armor", 3202, "Advance armor that is very durable", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));
        //items.Add(new Item("Diamond Armor", 3203, "The strongest armor made from diamonds", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 200, Item.ArmorType.Body));

        /////////////////////////
        //// Consumables
        items.Add(new Item("Health Potion", 9000, "Restore 100 HP", Item.ItemType.Consumable));
        items.Add(new Item("Mana Potion", 9001, "Restore 150 MP", Item.ItemType.Consumable));
        items.Add(new Item("Purple Potion", 9002, "Restore a little bit of HP and MP", Item.ItemType.Consumable));
        //// Accessories
        items.Add(new Item("Strength Necklace", 9100, "A necklace that increases your STR",Item.ArmorType.Accessory));
        items.Add(new Item("Intelligence Necklace", 9101, "A necklace that increases your INT", Item.ArmorType.Accessory));
        items.Add(new Item("Agility Necklace", 9102, "A necklace that increases your AGI", Item.ArmorType.Accessory));
        items.Add(new Item("Luck Necklace", 9103, "A necklace that increases your LUK",  Item.ArmorType.Accessory));

        // Food

        items.Add(new Item("Pizza", 10000, "Can't go wrong", 100));

        AddBonusStatsToItems();
        for (int index = 0; index < items.Count; index += 1)
        {
            CreateTooltip(items[index]);
        }

        List<List<int>> shopItems =
            new List<List<int>>(new List<int>[]{
            new List<int>(new int []{
                1000, 1001, 1002, 1003, 1050,
                1051, 1052, 1053, 1100, 1200,
                1201,1300, 1400, 1500, 1600,
                1700, -1, -1, -1, -1,
                 -1, -1, -1, -1, -1
            }),
            new List<int>(new int[]{
                9100, 9101, 9102, 9103, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1
            }) });
        List<List<int>> hospital =
            new List<List<int>>(new List<int>[]{
            new List<int>(new int []{
                9000, 9001, 9002, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                 -1, -1, -1, -1, -1
            }),
            new List<int>(new int []{
                9100, 9101, 9102, 9103, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1
            }) });
        List<List<int>> restuarant =
            new List<List<int>>(new List<int>[]{
            new List<int>(new int []{
                10000, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                -1, -1, -1, -1, -1,
                 -1, -1, -1, -1, -1
            }) });
        shopList.Add(new ShopList(MakeShopList(shopItems), 0));
        shopList.Add(new ShopList(MakeShopList(hospital), 1, true));
        shopList.Add(new ShopList(MakeShopList(restuarant), 2));
    }
    
    public static ShopList GetShop(int id)
    {
        return shopList.Find(aList => aList.listID == id);
    }

    public static Item GetItem(int id)
    {
        return items.Find(anItem => anItem.itemID == id);
    }


    public List<List<Item>> MakeShopList(List<List<int>> listOfItems)
    {
        List<List<Item>> makeItemList = new List<List<Item>>();
        foreach(List<int> pages in listOfItems)
        {
            makeItemList.Add(new List<Item>());
        }
        for (int i = 0; i < listOfItems.Count; i++)
        {
            foreach (int itemID in listOfItems[i])
            {
                makeItemList[i].Add(GetItem(itemID));
            }
        }
        return makeItemList;
    }

    private void CreateTooltip(Item item)
    {
        item.itemRegularText.Add(item.itemName);
        string type = "";
        if (item.itemType == Item.ItemType.Armor)
        {
            if (item.armorType == Item.ArmorType.Accessory)
            {
                type += "(<color=#FFABAB>" + item.itemType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Head)
            {
                type += "(<color=#3BCD58>" + item.armorType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Neck)
            {
                type += "(<color=#C40D0D>" + item.armorType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Body)
            {
                type += "(<color=#F7CA34>" + item.armorType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Bottom)
            {
                type += "(<color=#F78F34>" + item.armorType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Shield)
            {
                type += "(<color=#E57E18>" + item.armorType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Boots)
            {
                type += "(<color=#FF8000>" + item.armorType.ToString() + "</color>)";
            }
            else if (item.armorType == Item.ArmorType.Hands)
            {
                type += "(<color=#18E418>" + item.armorType.ToString() + "</color>)";
            }
        }
        else if (item.itemType == Item.ItemType.Weapon)
        {
            if (item.weaponType == Item.WeaponType.Sword)
            {
                type += "(<color=#FF0000>" + item.weaponType.ToString() + "</color>)";
            }
            else if (item.weaponType == Item.WeaponType.Axe)
            {
                type += "(<color=#0000CB>" + item.weaponType.ToString() + "</color>)";
            }
            else if (item.weaponType == Item.WeaponType.Dagger)
            {
                type += "(<color=#8B00A1>" + item.weaponType.ToString() + "</color>)";
            }
            else if (item.weaponType == Item.WeaponType.Shuriken)
            {
                type += "(<color=#900000>" + item.weaponType.ToString() + "</color>)";
            }
            else if (item.weaponType == Item.WeaponType.Wand)
            {
                type += "(<color=#914800>" + item.weaponType.ToString() + "</color>)";
            }
            else if (item.weaponType == Item.WeaponType.Staff)
            {
                type += "(<color=#463811>" + item.weaponType.ToString() + "</color>)";

            }
        }
        else if (item.itemType == Item.ItemType.Consumable)
        {
            type += "(<color=#81CAE1>" + item.itemType.ToString() + "</color>)";
        }
        else if (item.itemType == Item.ItemType.Food)
        {
            type += "(<color=#81CAE1>" + item.itemType.ToString() + "</color>)";
        }
        item.itemRegularText.Add(type);
        item.itemRegularText.Add("<color=#ECF32A>COST: $" + item.itemCost.ToString() + "</color>");
        item.itemRegularText.Add(item.itemDesc);
        List<int> values = new List<int>
            (new int[] {item.itemBonusStr, item.itemBonusInt, item.itemBonusAgi, item.itemBonusLuk,
                item.itemBonusHP, item.itemBonusMP, item.itemBonusAtk, item.itemBonusMAtk,
                item.itemBonusArmor, item.itemBonusResist,
                item.itemBonusHit, item.itemBonusDodge, item.itemBonusCrit, item.itemBonusCritMulti, item.itemBonusManaComs, item.itemBonusDmgOutput, item.itemBonusDmgTaken});
        List<string> desc = new List<string>
            (new string[] {"<color=#C40D0D>STR: " , "<color=#0000FF>INT: ", "<color=#00FF00>AGI: ",
                    "<color=#F3F335>LUK: ", "<color=#F00000>HP: ", "<color=#2BF2F2>MP: ",
                    "<color=#EC2E2F>ATK: ", "<color=#2200FF>MATK: ", "<color=#FFB811>DEF: ",
                "<color=#04007F>RES: ", "<color=#2EEC61>HIT: ", "<color=#2EED8E>DODGE: ",
                    "<color=#2EEDED>CRIT: ", "<color=#DEAB71>CRITMULTI: ", "<color=#>DMGOUT" , "<color=#>DMGTAKE", "<color=#>MANACOMS"});
        for(int i = 0;  i < values.Count; i++)
        {
            if (values[i] != 0)
            {
                if (values[i] > 0)
                {
                    item.itemStatText.Add(desc[i] + "+" + values[i] + "</color>");
                }
                else
                {
                    item.itemStatText.Add(desc[i] + values[i] + "</color>");
                }
            }
        }
    }

    private void AddBonusStatsToItems()
    {
        for (int k = 0; k < items.Count; k += 1)
        {
            Item item = items[k];
            switch (item.itemID)
            {
                case 1200:
                    {
                        item.itemBonusMP = 50;
                        item.itemBonusArmor = 10;
                        item.itemBonusResist = 15;
                        break;
                    }
                case 1201:
                    {
                        item.itemBonusMP = 100;
                        item.itemBonusArmor = 7;
                        item.itemBonusResist = 11;
                        break;
                    }
                case 9000:
                    {
                        item.itemCost = 25;
                        break;
                    }
            }
        }
    }

    public static void ActivateConsumable(int id)
    {
        SoundDatabase.PlaySound(14);
        Item item = GetItem(id);
        switch (id)
        {
            case 9000:
                {
                    GameManager.player.HealHP(100);
                    break;
                }
        }
        Inventory.RemoveItem(id);
    }


    public static void ActivateFood(int id)
    {
        SoundDatabase.PlaySound(51);
        Item item = GetItem(id);
        switch (id)
        {
            case 10000:
                {
                    GameManager.player.HealHP(175);
                    break;
                }
        }
        StatusBar.UpdateSliders();
    }
}
