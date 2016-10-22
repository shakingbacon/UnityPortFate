using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
    public List<Item> items = new List<Item>();
    // Use this for initialization
    void Start() {
        items.Add(new Item("Inner", 0, "Strong base but weak tip", 50, 10, 100, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Tipper", 1, "Strong tip but weak base", 30, 30, 100, Item.ItemType.Weapon, Item.WeaponType.Sword));
        items.Add(new Item("Health Potion", 2, "Restore some HP", 25, Item.ItemType.Consumable));
    }
}
