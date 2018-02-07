using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI    ;

public class PlayerArmorController : MonoBehaviour {

    public GameObject playerArmor;
    Player player;
    InventoryController inventoryController;


    void Awake ()
    {
        player = GetComponent<Player>();
        inventoryController = GetComponent<InventoryController>();
    }

    public void EquipArmor(Item itemToEquip)
    {
        SoundDatabase.PlaySound(0);
        foreach (Transform item in playerArmor.transform)
        {
            Item checkItem = item.GetComponent<ItemHolder>().item;
            if (checkItem.ItemType == itemToEquip.ItemType)
            {
                UnequipArmor(checkItem);
                Destroy(item.gameObject);
            }
        }
        Armor armor = Instantiate(Resources.Load<Armor>("Prefabs/Items/" + itemToEquip.Name));
        armor.transform.SetParent(playerArmor.transform);
        armor.transform.localScale = new Vector3(1, 1, 1);
        //GameObject armor = new GameObject();
        //armor.AddComponent<ItemHolder>();
        //armor.GetComponent<ItemHolder>().item = itemToEquip;
        //armor.AddComponent<SpriteRenderer>();
        //armor.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Icons/PlayerEquips/" + itemToEquip.Name);
        //armor.GetComponent<SpriteRenderer>().sortingOrder = 10;
        armor.name = itemToEquip.Name;
        //armor.transform.SetParent(playerArmor.transform);
        armor.transform.localPosition = new Vector3(0, 0, 0);
        //armor.transform.localScale = new Vector3(1, 1, 1);
        //
        itemToEquip.Stats.AddStatsToOther(player.Stats);
        //equippedWeapon = EquippedWeapon.GetComponent<IArmor>();
        //itemToEquip.Stats = itemToEquip.Stats;
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipArmor(Item item)
    {
        SoundDatabase.PlaySound(0);
        item.Stats.RemoveStatsFromOther(player.Stats);
        inventoryController.GiveItem(item);
        Destroy(playerArmor.transform.Find(item.Name).gameObject);
        UIEventHandler.ItemUnequipped(item);
        UIEventHandler.StatsChanged();
        SoundDatabase.PlaySound(0);
    }


}
