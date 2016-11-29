using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;

    }
}
