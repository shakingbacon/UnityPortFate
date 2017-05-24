using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopList {

    public List<List<Item>> itemList;
    public int listID;
    public bool canRest;

	public ShopList(List<List<Item>> items, int id)
    {
        itemList = items;
        listID = id;
    }

    public ShopList(List<List<Item>> items, int id, bool canrest)
    {
        itemList = items;
        listID = id;
        canRest = canrest;
    }
}
