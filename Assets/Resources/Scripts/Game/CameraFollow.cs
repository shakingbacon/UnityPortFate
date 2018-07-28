using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float _baseOrthographicSize;
    public float MoveSpeed = 0.1f;
    public Transform Target;

    private void Start()
    {
    }

    private void Update()
    {
        GetComponent<Camera>().orthographicSize = Screen.height / 100f / 2.3f;
        if (Target)
            transform.position =
                Vector3.Lerp(transform.position, Target.position, MoveSpeed) +
                new Vector3(0, 0, -3); //from, to ,howfast
    }
}