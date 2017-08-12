using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    public float moveSpeed = 0.1f;
    //private Camera myCam;


	// Use this for initialization
	void Start () {
        //myCam = GetComponent<Camera>();
        //myCam.GetComponent<Camera>().orthographicSize = 4;

    }
	
	// Update is called once per frame
	void Update () {
        float s_baseOrthographicSize = Screen.height / 100.0f / 2.0f;
        Camera.main.orthographicSize = s_baseOrthographicSize;
        //myCam.orthographicSize = (Screen.height / 100f) / 2.3f;
        if (target && !GameManager.inBattle)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed) + new Vector3(0, 0, -11); //from, to ,howfast
        }
        
	}
}
