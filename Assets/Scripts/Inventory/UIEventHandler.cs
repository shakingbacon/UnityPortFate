using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour {

    public delegate void ItemEventHandler(NewItem item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler onItemEquipped;

    public delegate void PlayerHealhEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealhEventHandler OnPlayerHealthChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChanged;

    // public 

    public static void ItemAddedToInventory(NewItem item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquipped(NewItem item)
    {
        onItemEquipped(item);
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        OnPlayerHealthChanged(currentHealth, maxHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLevelChanged()
    {
        OnPlayerLevelChanged();
    }
}
