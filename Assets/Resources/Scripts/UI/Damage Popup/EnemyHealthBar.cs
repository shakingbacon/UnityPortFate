using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider bar;
    public Transform location;

    void Start()
    {
        bar = GetComponent<Slider>();
    }

    void FixedUpdate()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        transform.position = new Vector2(location.position.x, location.position.y + location.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        GetComponent<RectTransform>().sizeDelta =
             new Vector2((location.GetComponent<SpriteRenderer>().sprite.rect.size.x * location.localScale.x) * 0.70f, gameObject.GetComponent<RectTransform>().sizeDelta.y);
    }

    public void SetSliderValue(int min, int max)
    {
        bar.value = ((float)min / max);
    }
}
