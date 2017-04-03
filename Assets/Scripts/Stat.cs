using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stat {
    public int baseAmount = 0; 
    public int buffedAmount = 0;
    public int totalAmount = 0;

    public Stat()
    {
        baseAmount = 0;
        buffedAmount = 0;
        totalAmount = 0;
    }
}
