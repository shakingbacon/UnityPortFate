using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string Name { get; set; }
    public string Description { get; set; }
    //string ActionName { get; set; }

    public int Cost { get; set; }

    public Attributes Stats { get; set; }


    //public ItemTypes ItemType { get; set; }
    //public WeaponTypes WeaponType { get; set; }
    //public ArmorTypes ArmorType { get; set; }


    //public enum ItemTypes
    //{
    //    Armor,
    //    Weapon,
    //    Consumable,
    //    Quest
    //}

    //public enum WeaponTypes
    //{
    //    None,
    //    Sword,
    //    Axe,
    //    Wand,
    //    Staff
    //}

    //public enum ArmorTypes
    //{
    //    None,
    //    Head,
    //    Neck,
    //    Hands,
    //    Weapon,
    //    Body,
    //    Shield,
    //    Bottom,
    //    Boots,
    //    Necklace,
    //    Ring,
    //    Glyph
    //}


    protected virtual void Awake()
    {
        GiveStats();
    }

    public virtual void GiveStats()
    {
        Stats = new Attributes();
    }
}
