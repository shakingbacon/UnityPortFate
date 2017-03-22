using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHolder : MonoBehaviour {
    public Item item;
    Text desc;
    void Start()
    {
        desc = GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").GetComponentInChildren<Text>();
    }

    public void MouseEnter()
    {
        if (item.itemID != -1)
        {
            desc.text = item.itemTooltip;
            GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(true);
        }
        
    }

    public void MouseLeave()
    {
        GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(false);
    }
}
