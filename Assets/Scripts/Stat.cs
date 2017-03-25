using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stat {
    public int baseAmount; 
    public int buffedAmount;
    public int totalAmount;

    public Stat()
    {
        baseAmount = 0;
        buffedAmount = 0;
        totalAmount = 0;
    }
}
