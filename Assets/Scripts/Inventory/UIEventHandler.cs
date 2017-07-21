using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    public delegate void ItemEventHandler(NewItem item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler onItemEquipped;

    public delegate void PlayerHealhEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealhEventHandler OnPlayerHealthChanged;

    public 

    public static void ItemAddedToInventory(NewItem item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquipped(NewItem item)
    {
        onItemEquipped(item);
    }

    public static void HealthChanged(int maxHealth, int currentHealth)
    {
        OnPlayerHealthChanged(maxHealth, currentHealth);
    }


}
