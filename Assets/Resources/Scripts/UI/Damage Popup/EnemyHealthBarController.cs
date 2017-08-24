using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarController : MonoBehaviour {

    static EnemyHealthBar healthBar;
    static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        healthBar = Resources.Load<EnemyHealthBar>("Prefabs/UI/Damage Popup/Enemy Health");
    }

    public static EnemyHealthBar CreateHealthBar(Transform location)
    {
        EnemyHealthBar instance = Instantiate(healthBar);
        instance.location = location;
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.SetSiblingIndex(0);
        instance.SetSliderValue(1, 1);
        return instance;
    }
}
