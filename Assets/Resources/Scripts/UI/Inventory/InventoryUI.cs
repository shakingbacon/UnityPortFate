using System.Collections;
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
        itemContainer = Resources.Load<InventoryUIItem>("Prefabs/UI/Inventory/InvItemContainer");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        UIEventHandler.OnItemRemovedFromInventory += ItemRemoved;
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

    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer, scrollViewContent);
        emptyItem.transform.localPosition = new Vector3(1, 1, 1);
        emptyItem.SetItem(item);
        // emptyItem.transform.SetParent(scrollViewContent);
        scrollViewContent.sizeDelta = new Vector2(scrollViewContent.rect.width, scrollViewContent.rect.height + emptyItem.GetComponent<RectTransform>().rect.height);
        emptyItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void ItemRemoved()
    {
        scrollViewContent.sizeDelta = new Vector2(scrollViewContent.rect.width, scrollViewContent.rect.height - 80);
    }
}
