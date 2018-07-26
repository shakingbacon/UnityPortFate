using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(EventTrigger))]
public abstract class ItemHolder : MonoBehaviour
{
    protected EventTrigger.Entry click, enter, exit;
    protected Item item;

    public Item Item
    {
        get { return item; }
        set { SetItem(value); }
    }

    protected virtual void Start()
    {
        var trigger = GetComponent<EventTrigger>();
        //
        click = new EventTrigger.Entry { eventID = EventTriggerType.PointerClick };
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

    private void SetItem(Item item)
    {
        this.item = item;
        if (item != null) GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.name);
    }

    protected abstract void ClickAction(PointerEventData data);
    protected abstract void EnterAction();
    protected abstract void ExitAction();
}