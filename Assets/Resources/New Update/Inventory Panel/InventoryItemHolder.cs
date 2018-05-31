using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryItemHolder : MonoBehaviour {

    Item item;

    InventoryItemDescription desc;

    void Start()
    {
        desc = GetComponentInParent<InventoryPanel2>().itemDesc;
        print(desc);
        EventTrigger trigger = GetComponent<EventTrigger>();
        //
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener(data => ItemAction());
        trigger.triggers.Add(entry);
        // 
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener(data => desc.SetDescription(item));
        trigger.triggers.Add(entry);
        //
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener(data => desc.gameObject.SetActive(false));
        trigger.triggers.Add(entry);
        desc.gameObject.SetActive(false);
    }



    public void SetItem(Item item)
    {
        this.item = item;
        Image image = GetComponent<Image>();
        image.sprite = Resources.Load<Sprite>("Icons/Items/" + item.name);
    }

    void ItemAction()
    {
        if (item is Weapon)
        {
            print("equipped: " + item.name);
            Destroy(gameObject);
            //InventoryController.Instance.EquipWeapon(item);
        }
        desc.gameObject.SetActive(false);
    }
    

}
