using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemHolder : MonoBehaviour {

    public Item item;

    public void MouseEnter()
    {
        if (item.itemID != -1)
        {
            GameObject.FindGameObjectWithTag("Shop").transform.FindChild("Item Desc").gameObject.SetActive(true);
            Transform desc = GameObject.FindGameObjectWithTag("Shop").transform.FindChild("Item Desc");
            int i = 0;
            for (; i < 4; i++)
            {
                desc.GetChild(i).GetComponent<Text>().text = item.itemRegularText[i];
            }
            desc.GetChild(4).GetComponent<Text>().text 
                = item.itemStatText;
        }
    }
    
    public void MouseLeave()
    {
        GameObject.FindGameObjectWithTag("Shop").transform.FindChild("Item Desc").gameObject.SetActive(false);
    }

    public void MouseClick()
    {
        if (item.itemID != -1)
        {
            SoundDatabase.PlaySound(16);
            Shop.buyingItem = item;
            Shop.BuyingShow(true);
        }
    }
    

}
