using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;
    public Text itemText;
    public Image itemImage;

    public void SetItem(Item item)
    {
        this.item = item;
        SetupItemValues();
    }
	
    void SetupItemValues()
    {
        itemText.text = item.Name;
        itemImage.sprite = Resources.Load<Sprite>("Icons/Items/" + item.Name);
        itemImage.SetNativeSize();
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item , GetComponent<Button>());
    }


}
