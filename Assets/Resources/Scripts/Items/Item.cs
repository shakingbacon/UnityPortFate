using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Item : MonoBehaviour {
    public Mortal Stats { get; set; }
    //public List<BaseStat> Stats { get; set; }
    //public string ObjectSlug { get; set; }
    public string Description { get; set; }
    public string ActionName { get; set; }
    public string ItemName { get; set; }
    public int ItemCost { get; set; }
    //public bool ItemModifier { get; set; } 
    //[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    public WeaponTypes WeaponType { get; set; }
    public ArmorTypes ArmorType { get; set; }

    public enum ItemTypes
    {
        Armor,
        Weapon,
        Consumable,
        Quest
    }

    public enum WeaponTypes
    {
        None,
        Sword,
        Axe,
        Wand,
        Staff
    }
    
    public enum ArmorTypes
    {
        None,
        Head,
        Neck,
        Hands,
        Weapon,
        Body,
        Shield,
        Bottom,
        Boots,
        Necklace,
        Ring,
        Glyph
    }

    public Item()
    {
        ActionName = "Equip";
    }

    //public Item(List<BaseStat> _Stats, string _ObjectSlug)
    //{
    //    this.Stats = _Stats;
    //    this.ObjectSlug = _ObjectSlug;
    //}

    //[JsonConstructor]
    //public Item(List<BaseStat> _Stats, string _ObjectSlug, string _Description, ItemTypes _ItemType, ArmorTypes _ArmorType, string _ActionName, string _ItemName, bool _ItemModifier)
    //{
    //    this.Stats = _Stats;
    //    this.ObjectSlug = _ObjectSlug;
    //    this.Description = _Description;
    //    this.ItemType = _ItemType;
    //    this.ArmorType = _ArmorType;
    //    this.ActionName = _ActionName;
    //    this.ItemName = _ItemName;
    //    this.ItemModifier = _ItemModifier;
    //}

    //public Item(List<BaseStat> _Stats, string _ObjectSlug, string _Description, ItemTypes _ItemType, WeaponTypes _WeaponType, string _ActionName, string _ItemName, bool _ItemModifier)
    //{
    //    this.Stats = _Stats;
    //    this.ObjectSlug = _ObjectSlug;
    //    this.Description = _Description;
    //    this.ItemType = _ItemType;
    //    this.WeaponType = _WeaponType;
    //    this.ActionName = _ActionName;
    //    this.ItemName = _ItemName;
    //    this.ItemModifier = _ItemModifier;
    //}

}
