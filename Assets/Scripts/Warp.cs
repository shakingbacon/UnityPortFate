using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform goToTarget;
    public int musicID;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ScreenFader.img.enabled = true;
        SoundDatabase.PlaySound(16);
        GameManager.cantMove = true;
        yield return StartCoroutine(ScreenFader.FadeToBlack());
        SoundDatabase.PlayMusic(musicID);
        other.gameObject.transform.position = goToTarget.position;
        Camera.main.transform.position = goToTarget.position;
        yield return StartCoroutine(ScreenFader.FadeToClear());
        GameManager.cantMove = false;
        ScreenFader.img.enabled = false;

    }
}
