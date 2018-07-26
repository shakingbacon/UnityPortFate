public class PickupItem : Interactable
{
    public Item ItemDrop { get; set; }

    private void Start()
    {
        interactString = "Pick Up";
    }

    public override void Interact()
    {
        SoundDatabase.PlaySound(16);
        Pickup();
        PlayerInteractController.Instance.ShowInteractNotifier(false);
    }

    protected virtual void Pickup()
    {
        InventoryController.Instance.AddItem(ItemDrop);
        EventNotifier.Instance.MakeEventNotifier($"Obtained item: {ItemDrop.Name}");
        Destroy(gameObject);
    }
}