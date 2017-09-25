using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {
    public Item ItemDrop { get; set; }

    void Start()
    {
        interactString = "Pick Up";
    }

    public override void Interact()
    {
        SoundDatabase.PlaySound(16);
        Pickup();
        PlayerInteractController.Instance.ShowInteractNotifier(false);
    }

    void Pickup()
    {
        InventoryController.Instance.GiveItem(ItemDrop);
        Destroy(gameObject);
    }

}
