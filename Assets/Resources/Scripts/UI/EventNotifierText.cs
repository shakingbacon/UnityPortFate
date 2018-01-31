using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventNotifierText : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f);
        float duration = 3f;
        float time;
        for (time = 0f; time <= duration; time += Time.deltaTime)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1 - time / duration);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
