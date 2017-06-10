using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenFader : MonoBehaviour {

    public static Animator anim;
    public static bool isFading = false;
    public static Image img; 

	void Start () {
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
	} 

    public static IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
            yield return null;

    }

    public static IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");
        
        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
}
