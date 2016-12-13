using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform goToTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = goToTarget.position;
        Camera.main.transform.position = goToTarget.position;

    }
}
