public class Terrain
{
    public string Name { get; set; }
    int ID { get; set; }

    public enum DestroyedBy
    {
        Axe,
        Hammer,
        Hoe,
        Scythe
    }
    public DestroyedBy CanBeDestroyedBy { get; set; }
    public bool CanPickUp { get; set; }

}
