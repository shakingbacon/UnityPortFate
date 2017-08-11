using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {
    public NewItem ItemDrop { get; set; }

    public override void Interact()
    {
        SoundDatabase.PlaySound(16);
        InventoryController.Instance.GiveItem(ItemDrop);
        Destroy(gameObject);
    }
}
