using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI    ;

public class PlayerArmorController : MonoBehaviour {

    public GameObject Head { get; set; }
    public GameObject Neck { get; set; }
    public GameObject Hands { get; set; }
    public GameObject Body { get; set; }
    public GameObject Shield { get; set; }
    public GameObject Bottom { get; set; }
    public GameObject Boots { get; set; }
    public GameObject armor;
    Player player;
    CharacterStats characterStats;
    InventoryController inventoryController;


    void Awake ()
    {
        Head = transform.FindChild("Armor").FindChild("Head").gameObject;
        Neck = transform.FindChild("Armor").FindChild("Neck").gameObject;
        Hands = transform.FindChild("Armor").FindChild("Hands").gameObject;
        Body = transform.FindChild("Armor").FindChild("Body").gameObject;
        Shield = transform.FindChild("Armor").FindChild("Shield").gameObject;
        Bottom = transform.FindChild("Armor").FindChild("Bottom").gameObject;
        Boots = transform.FindChild("Armor").FindChild("Boots").gameObject;
        player = GetComponent<Player>();
        characterStats = GetComponent<Player>().characterStats;
        inventoryController = GetComponent<InventoryController>();
    }

    public void EquipArmor(Item itemToEquip)
    {
        SoundDatabase.PlaySound(0);
        GameObject place = FindArmor(itemToEquip.ArmorType.ToString());
        if (place != null)
        {
            if (place.transform.childCount != 0)
            {
                UnequipArmor(place);
            }
            GameObject armor = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/Items/Armor/Leather Hat")); //+ itemToEquip.ItemName));
            armor.name = itemToEquip.ItemName;
            armor.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Icons/PlayerEquips/" + itemToEquip.ItemName);
            armor.transform.SetParent(place.transform);
            armor.transform.localPosition = new Vector3(0, 0, 0);
            armor.transform.localScale = new Vector3(1, 1, 1);
        }

        characterStats.AddStatBonus(itemToEquip.Stats);
        //equippedWeapon = EquippedWeapon.GetComponent<IArmor>();
        itemToEquip.Stats = itemToEquip.Stats;
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public GameObject FindArmor(string type)
    {
        switch (type)
        {
            case "Head": { return Head; }
            case "Neck": { return Neck; }
            case "Hands": { return Hands; }
            case "Body": { return Body; }
            case "Shield": { return Shield; }
            case "Bottom": { return Bottom; }
            case "Boots": { return Boots; }
        }
        return null;
    }

    public void UnequipArmor(GameObject equipment)
    {
        print(equipment.transform.GetChild(0).GetComponent<Image>().sprite.name);
        Item item = ItemDatabase.Instance.GetItem(equipment.transform.GetChild(0).GetComponent<Image>().sprite.name);
        string type = equipment.name;
        GameObject place;
        string real = "";
        if (type != "Necklace" && type != "Ring" && type != "Glyph")
        {
            place = FindArmor(type).transform.GetChild(0).gameObject;
            real = place.name;//.Substring(0, place.name.Length - 7);
            Destroy(place);
        }
        equipment.transform.GetChild(0).GetComponent<Image>().sprite
    = Resources.Load<Sprite>("General/Sprites/Default Equip/" + equipment.name);
        characterStats.RemoveStatBonus(item.Stats);
        //inventoryController.GiveItem(item);
        UIEventHandler.StatsChanged();
        SoundDatabase.PlaySound(0);
    }


}
