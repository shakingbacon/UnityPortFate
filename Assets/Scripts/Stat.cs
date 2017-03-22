using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stat {
    public int statAmount; 
    public int buffedAmount;
    public int totalAmount;

    public Stat()
    {
        statAmount = 0;
        buffedAmount = 0;
        totalAmount = 0;
    }

    public Stat(int start)
    {
        statAmount = start;
    }
}
