using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusDatabase : MonoBehaviour {

    public static List<Status> statusDatabase = new List<Status>();

    void Start()
    {
        statusDatabase.Add(new Status("Burn", 0));
        statusDatabase.Add(new Status("Paralyze", 1));
        statusDatabase.Add(new Status("Bleed", 2));
        statusDatabase.Add(new Status("Poison", 3));
        statusDatabase.Add(new Status("Cripple", 4));
        statusDatabase.Add(new Status("Blind", 5));
        statusDatabase.Add(new Status("Confuse", 6));
        statusDatabase.Add(new Status("Curse", 7));
        statusDatabase.Add(new Status("Soaked", 8));
    }

    public static Status GetStatus(int id)
    {
        return statusDatabase.Find(anID => anID.statusID == id);
    }
}
