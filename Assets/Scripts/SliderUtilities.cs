using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUtilities : MonoBehaviour {

    public static void UpdateSliderFillWithText(Slider slider, int value1, int value2, string textname)
    {
        string text = string.Format("{0} / {1}", value1, value2);
        float percentage = (value1 * 1f/ value2 * 1f);
        slider.value = percentage;
        slider.transform.FindChild(textname).GetComponent<Text>().text = text;
    }

    public static void UpdateSliderFillWithText(Slider slider, int value1, int value2, string extratext, string textname)
    {
        string text = string.Format("{0} {1} / {2}",extratext, value1, value2);
        float percentage = (value1 * 1f / value2 * 1f);
        slider.value = percentage;
        slider.transform.FindChild(textname).GetComponent<Text>().text = text;
    }
}
