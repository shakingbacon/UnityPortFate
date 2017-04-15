using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDatabase : MonoBehaviour {
    public static List<Status> statuses = new List<Status>();

    void Start()
    {
        statuses.Add(new Status("Burn", 0));
        statuses.Add(new Status("Paralyze", 1));
        statuses.Add(new Status("Bleed", 2));
        statuses.Add(new Status("Poison", 3));
        statuses.Add(new Status("Cripple", 4));
        statuses.Add(new Status("Blind", 5));
        statuses.Add(new Status("Confuse", 6));
        statuses.Add(new Status("Curse", 7));
    }
}
