using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImage : MonoBehaviour {
    public static Transform playerImage;

    void Start()
    {
        playerImage = gameObject.transform;
    }

    public static void UpdateImage(string where, string name, bool enable)
    {
        playerImage.FindChild(where).GetComponent<Image>().sprite = Resources.Load<Sprite>("Player/" + name);
        playerImage.FindChild(where).GetComponent<Image>().preserveAspect = true;
        playerImage.FindChild(where).GetComponent<Image>().enabled = enable;
    }
    public static void UpdateImage(string where, Item item, bool enable)
    {
        playerImage.FindChild(where).GetComponent<Image>().sprite = Resources.Load<Sprite>("Player/" + item.itemName);
        playerImage.FindChild(where).GetComponent<Image>().preserveAspect = true;
        playerImage.FindChild(where).GetComponent<Image>().enabled = enable;
    }
}
