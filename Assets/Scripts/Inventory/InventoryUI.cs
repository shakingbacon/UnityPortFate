﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public RectTransform inventoryPanel;
    public RectTransform scrollViewContent;
    InventoryUIItem itemContainer { get; set; }
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }

	// Use this for initialization
	void Start () {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            menuIsActive = !menuIsActive;
            inventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }


    public void ItemAdded(NewItem item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer, scrollViewContent);
        emptyItem.SetItem(item);
        // emptyItem.transform.SetParent(scrollViewContent);
        emptyItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}