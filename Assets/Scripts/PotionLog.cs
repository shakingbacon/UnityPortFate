using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable {
    public void Consume()
    {
        Debug.Log("drink log");
    }

    public void Consume(CharacterStats stats)
    {
        Debug.Log("drink lol stats");
    }

}
