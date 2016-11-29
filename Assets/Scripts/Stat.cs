using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stat {
    public string statName;
    public int statAmount; 
    public int buffedAmount;
    public int totalAmount;
    public int statID;

    public Stat(string name, int id)
    {
        statName = name;
        statID = id;
    }
    public Stat(string name, int id, int start)
    {
        statName = name;
        statID = id;
        statAmount = start;
    }

	
}
