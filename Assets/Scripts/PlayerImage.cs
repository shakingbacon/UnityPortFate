using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerImage : MonoBehaviour {
    public static Transform playerImageGameObject;

    void Start()
    {
        playerImageGameObject = gameObject.transform;
    }

    public static void UpdateImage(string where, string name, bool enable)
    {
        playerImageGameObject.FindChild(where).GetComponent<Image>().sprite = Resources.Load<Sprite>("Player/" + name);
        playerImageGameObject.FindChild(where).GetComponent<Image>().preserveAspect = true;
        playerImageGameObject.FindChild(where).GetComponent<Image>().enabled = enable;
    }
    public static void UpdateImage(string where, Item item, bool enable)
    {
        playerImageGameObject.FindChild(where).GetComponent<Image>().sprite = Resources.Load<Sprite>("Player/" + item.itemName);
        playerImageGameObject.FindChild(where).GetComponent<Image>().preserveAspect = true;
        playerImageGameObject.FindChild(where).GetComponent<Image>().enabled = enable;
    }
}
