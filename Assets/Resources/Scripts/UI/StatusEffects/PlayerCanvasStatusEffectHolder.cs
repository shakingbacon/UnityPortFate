using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasStatusEffectHolder : MonoBehaviour
{
    public Image img;
    public float Duration { get; set; } = 0;

    private void FixedUpdate()
    {
        if (Duration < 0) Destroy(gameObject);
        Duration -= Time.fixedDeltaTime;
    }
}
