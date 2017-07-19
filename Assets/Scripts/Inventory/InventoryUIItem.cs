using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public NewItem item;

    public Text itemText;
    public Image itemImage;

    public void SetItem(NewItem item)
    {
        this.item = item;
        SetupItemValues();
    }
	
    void SetupItemValues()
    {
        itemText.text = item.ItemName;
        itemImage.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        //print(item.ObjectSlug);
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item , GetComponent<Button>());
    }
}
