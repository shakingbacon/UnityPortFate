using UnityEngine;

public class PlayerMovementController : PlayerAnimatorController
{
    private Rigidbody2D _rgbody;
    public static PlayerMovementController Instance { get; set; }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        _rgbody = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        
        float x = 0f, y = 0f;
        HoldingArrowKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);
        HoldingShift = Input.GetKey(KeyCode.LeftShift);

        if (CanMove)
        {
            if (HoldingArrowKey)
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) x = 1.7f;
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) y = 1.4f;
                if (HoldingShift && (x != 0 || y != 0))
                {
                    if (RunningTime < 1.0f) RunningTime += Time.deltaTime;
                    else RunningTime = 1.0f;
                    x *= 1 + 0.9f * RunningTime;
                    y *= 1 + 0.4f * RunningTime;
                }

                if (Input.GetKey(KeyCode.LeftArrow)) x = -x;
                if (Input.GetKey(KeyCode.DownArrow)) y = -y;
                if (x < 0)
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1,
                        transform.localScale.y,
                        transform.localScale.z);
                else if (x != 0)
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,
                        transform.localScale.z);
            }
            if (!HoldingArrowKey || !HoldingShift) { RunningTime = 0; }
        }
        else { RunningTime = 0; }

        _rgbody.velocity = new Vector2(x, y);
    }

    private void DisableMovement() => CanMove = false;
    private void EnableMovement() => CanMove = true;
}