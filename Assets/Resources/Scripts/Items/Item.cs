using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
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
