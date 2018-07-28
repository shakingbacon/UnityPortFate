using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name { get; set; }

    public string Description { get; set; }
    //string ActionName { get; set; }
    public int Cost { get; set; }
    public Attributes Stats { get; set; }
    public string ItemType { get; set; }

    protected virtual void Awake()
    {
        GiveStats();
    }

    public virtual void GiveStats()
    {
        Stats = new Attributes(); 
    }
}