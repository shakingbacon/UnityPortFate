using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextController : MonoBehaviour {
    static FloatingText popText;
    static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        popText = Resources.Load<FloatingText>("Prefabs/UI/Damage Popup/DmgPopParent");
    }

    public static FloatingText CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popText);
        instance.location = location;
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.SetSiblingIndex(0);
        instance.SetText(text);
        return instance;
    }

}
