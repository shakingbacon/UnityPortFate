using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform goToTarget;
    public int musicID;

    void OnTriggerEnter2D(Collider2D other)
    {
        SoundDatabase.PlaySound(16);
        SoundDatabase.PlayMusic(musicID);
        other.gameObject.transform.position = goToTarget.position;
        Camera.main.transform.position = goToTarget.position;
    }
}
