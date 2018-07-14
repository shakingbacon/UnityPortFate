using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 0.1f;
    private Camera myCam;
    float baseOrthographicSize;

    void Start()
    {
        myCam = GetComponent<Camera>();
        myCam.GetComponent<Camera>().orthographicSize = 4;
    }

    void Update()
    {

        myCam.orthographicSize = (Screen.height / 100f) / 2.3f;
        if (target)
        {

            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed) + new Vector3(0, 0, -3); //from, to ,howfast
        }

    }
}
