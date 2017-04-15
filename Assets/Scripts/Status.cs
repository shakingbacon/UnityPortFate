using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Status {
    public string statusName;
    public Sprite statusIMG;
    public int statusID;

    public Status(string name, int id)
    {
        statusName = name;
        statusIMG = Resources.Load<Sprite>("StatusEffects/" + name);
        statusID = id;
    }

    public Status()
    {
        statusID = -1;
    }
}
