using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashDrop : Interactable
{
    int cashAmount;
    int chance;

    void Start()
    {
        interactString = "Pick Up";
    }

    public override void Interact()
    {
        SoundDatabase.PlaySound(16);
        PickUpCash();
        PlayerInteractController.Instance.ShowInteractNotifier(false);
    }

    void PickUpCash()
    {
        UIEventHandler.MoneyAdded(cashAmount);
        //EventNotifier.Instance.MakeEventNotifier(string.Format("Obtained: {0} Cash", cashAmount));
        Destroy(gameObject);
    }

    public static void DropCash(int amount, Transform location)
    {
        CashDrop dropped = Instantiate(Resources.Load<CashDrop>("Prefabs/Interactable/CashDrop"), CurrentMap.Instance.pickupItems);
        dropped.transform.position = location.position;
        dropped.cashAmount = amount;
    }
}