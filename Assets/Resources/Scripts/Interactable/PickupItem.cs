using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable {
    public Item ItemDrop { get; set; }

    void Start()
    {
        interactString = "Pick Up";
    }
    //public override void EnterInteractionArea(Collider2D player)
    //{
        
    //}

    public override void Interact()
    {
        SoundDatabase.PlaySound(16);
        InventoryController.Instance.GiveItem(ItemDrop);
        PlayerInteractController.Instance.ShowInteractNotifier(false);
        Destroy(gameObject);
    }
}
