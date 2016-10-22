using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float moveSpeed = 0.1f;
    private Camera myCam;


	// Use this for initialization
	void Start () {

        myCam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	void Update () {

        myCam.orthographicSize = (Screen.height / 100f) / 3.5f;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed) + new Vector3(0,0,-10); //from, to ,howfast
        }
	}
}
