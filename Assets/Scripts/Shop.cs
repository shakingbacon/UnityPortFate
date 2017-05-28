using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    public static Vector3 boundary;
    public static Vector3 position;
    public static Transform shop;
    public static Transform shopItems;
    public static Transform itemDesc;
    public static Button prev;
    public static Button next;
    public static Transform rest;
    public static Image clerk;
    public static Text greeting;
    public static Button exit;
    public static Text numText;
    public static Transform buying;
    public static Item buyingItem;
    public static bool showBuying = false;
    //
    public static List<List<Item>> items = new List<List<Item>>();
    public static  int pageNum;

    void Awake()
    {
        boundary = new Vector3(2f, 2f);
        shop = gameObject.transform;
        shopItems = gameObject.transform.FindChild("Shop Items");
        itemDesc = gameObject.transform.FindChild("Item Desc");
        prev = gameObject.transform.FindChild("Prev").GetComponent<Button>();
        next = gameObject.transform.FindChild("Next").GetComponent<Button>();
        clerk = gameObject.transform.FindChild("Clerk").GetComponent<Image>();
        greeting = gameObject.transform.FindChild("Greeting").GetComponent<Text>();
        exit = gameObject.transform.FindChild("Exit").GetComponent<Button>();
        numText = gameObject.transform.FindChild("Page Num").GetComponent<Text>();
        buying = gameObject.transform.FindChild("Buying");
        buying.FindChild("Yes").GetComponent<Button>().onClick.AddListener(BuyingYes);
        buying.FindChild("No").GetComponent<Button>().onClick.AddListener(BuyingNo);
        rest = gameObject.transform.FindChild("Rest");
        prev.onClick.AddListener(PrevButton);
        next.onClick.AddListener(NextButton);
        exit.onClick.AddListener(CloseButton);
        rest.GetComponentInChildren<Button>().onClick.AddListener(RestButton);
    }

    void Update()
    {
        Vector3 playerPos = GameManager.playerGameObject.transform.position;
        if (GameManager.thereIsShop)
        {
            if (position.x + boundary.x < playerPos.x || position.x - boundary.x > playerPos.x ||
                position.y + boundary.y < playerPos.y || position.y - boundary.y > playerPos.y)
            {
                CloseButton();
            }
        }
    }

    public static void IsHospital(bool yes)
    {
        rest.gameObject.SetActive(yes);
    }

    public static void RestButton()
    {
        SoundDatabase.PlaySound(19);
        if (GameManager.player.GetMaxHP(50) > GameManager.player.health)
        {
            GameManager.player.SetHP(GameManager.player.GetMaxHP(50));
        }
        if (GameManager.player.GetMaxMP(50) > GameManager.player.mana)
        {
            GameManager.player.SetMP(GameManager.player.GetMaxMP(50));
        }
        StatusBar.UpdateSliders();
    }

    public static void BuyingYes()
    {
        if (buyingItem.itemType == Item.ItemType.Food)
        {
            GameManager.player.cash -= buyingItem.itemCost;
            ItemDatabase.ActivateFood(buyingItem.itemID);
            BuyingShow(false);
        }
        else
        {
            SoundDatabase.PlaySound(9);
            GameManager.player.AddCash(-(buyingItem.itemCost));
            Inventory.AddItem(buyingItem.itemID);
            BuyingShow(false);
        }
    }

    public static void BuyingNo()
    {
        SoundDatabase.PlaySound(21);
        BuyingShow(false);
    }

    public static void BuyingShow(bool yes)
    {
        showBuying = yes;
        buying.gameObject.SetActive(yes);
        if (yes)
        {
            buying.FindChild("Text").GetComponent<Text>().text = "";
            buying.FindChild("Item IMG").GetComponent<Image>().sprite = buyingItem.itemImg;
            if (GameManager.player.cash -
                buyingItem.itemCost < 0)
            {
                buying.FindChild("Text").GetComponent<Text>().text += string.Format("You cant afford this item!\n");
                buying.FindChild("Yes").GetComponent<Button>().interactable = false;
            }
            else if (Inventory.CountItems() == 15)
            {
                buying.FindChild("Text").GetComponent<Text>().text += string.Format("Your Inventory is full!\n");
                buying.FindChild("Yes").GetComponent<Button>().interactable = false;
            }
            else
            {
                buying.FindChild("Text").GetComponent<Text>().text += string.Format("Do you want to buy this item?\n{0}\n",buyingItem.itemName);
                buying.FindChild("Text").GetComponent<Text>().text += string.Format("{0}$ - {1}$ = {2}$", GameManager.player.cash, buyingItem.itemCost, GameManager.player.cash - buyingItem.itemCost);
                buying.FindChild("Yes").GetComponent<Button>().interactable = true;
            }
        }
    }

    public static void PrevButton()
    {
        SoundDatabase.PlaySound(18);
        pageNum -= 1;
        numText.text = (pageNum + 1).ToString();
        UpdatePage(pageNum);
    }

    public static void NextButton()
    {
        SoundDatabase.PlaySound(18);
        pageNum += 1;
        numText.text = (pageNum + 1).ToString();
        UpdatePage(pageNum);

    }

    public static void CloseButton()
    {
        SoundDatabase.PlaySound(34);
        GameManager.thereIsShop = false;
        pageNum = 0;
        Destroy(shop.gameObject);
    }

    public static void UpdatePage(int index)
    {
        int i = 0;
        foreach(Transform item in shop.GetChild(0))
        {
            ShopItemHolder holder = item.GetComponent<ShopItemHolder>();
            holder.item = items[pageNum][i];
            if (items[pageNum][i].itemID == -1)
            {
                item.GetComponent<Button>().interactable = false;
                item.GetComponent<Image>().enabled = false;
            }
            else
            {
                item.GetComponent<Image>().enabled = true;
                item.GetComponent<Button>().interactable = true;
                item.GetComponent<Image>().sprite
                    = holder.item.itemImg;
            }
            i += 1;
        }
        if (pageNum == 0)
        {
            prev.interactable = false;
        }
        else
        {
            prev.interactable = true;
        }
        if (pageNum + 1 < items.Count)
        {
            next.interactable = true;
        }
        else
        {
            next.interactable = false;
        }
        numText.text = (1 + pageNum).ToString(); 
    }

}
