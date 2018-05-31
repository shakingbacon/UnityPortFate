using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPotion : MonoBehaviour, IConsumable {

    public void Consume()
    {
        Debug.Log("drink log");
    }

    public void Consume(Attributes stats)
    {
        Debug.Log("drink lol stats");
    }

}
