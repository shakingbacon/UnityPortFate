using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour
{


    public static ItemDatabase Instance { get; set; }
    private List<Item> Items { get; set; }

    //// Use this for initialization
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        //BuildDatabase();
    }

    public Item GetItem(string name)
    {
        Item item = Resources.Load<Item>("Prefabs/Items/Weapons/" + name);
        item.GiveStats();

        return item;
    }

    //private void BuildDatabase()
    //   {
    //       Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
    //   }

    //   public Item GetItem(string itemName)
    //   {
    //       foreach(Item item in Items)
    //       {
    //           if (item.ItemName == itemName)
    //           {
    //               return item;
    //           }
    //       }
    //       Debug.LogWarning("COULDNT FIND ITEM: " + itemName);
    //       return null;
    //   }

}
