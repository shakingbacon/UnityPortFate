using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(EventTrigger))]

public abstract class ItemHolder : MonoBehaviour
{
    protected Item item = null;
    public Item Item { get { return item; } set { SetItem(value); } }
    protected EventTrigger.Entry click, enter, exit;

    virtual protected void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        //
        click = new EventTrigger.Entry();
        click.eventID = EventTriggerType.PointerClick;
        click.callback.AddListener(data => ClickAction((PointerEventData)data));
        trigger.triggers.Add(click);
        // 
        enter = new EventTrigger.Entry();
        enter.eventID = EventTriggerType.PointerEnter;
        enter.callback.AddListener(data => EnterAction());
        trigger.triggers.Add(enter);
        //
        exit = new EventTrigger.Entry();
        exit.eventID = EventTriggerType.PointerExit;
        exit.callback.AddListener(data => ExitAction());
        trigger.triggers.Add(exit);
    }

    void SetItem(Item item)
    {
        this.item = item;
        if (item != null)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.name);
        }
    }

    protected abstract void ClickAction(PointerEventData data);
    protected abstract void EnterAction();
    protected abstract void ExitAction();

}
