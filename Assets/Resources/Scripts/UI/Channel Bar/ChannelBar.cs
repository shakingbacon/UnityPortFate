using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelBar : MonoBehaviour {

    public Slider channelBar;
    public Text skillName;
    public Text duration;

    public float Duration { get; set; }

    void Start()
    {
        StartCoroutine(SlideChannelBar());         
    }


    IEnumerator SlideChannelBar()
    {
        channelBar.value = 0;
        duration.text = Duration.ToString();
        float i;
        for (i = 0; i < Duration; i += Time.deltaTime)
        {
            channelBar.value = i / Duration;
            duration.text = (Duration - i).ToString("F1");
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
