using System.Collections;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rgbody;
    public static PlayerMovementController Instance { get; set; }

    private bool CanMove
    {
        get { return _animator.GetBool("CanMove"); }
        set { _animator.SetBool("CanMove", value); }
    } 

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        _rgbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {

        float x = 0f, y = 0f;
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isWalking", false);
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            _animator.SetBool("isWalking", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("isRunning", true);
        }

        if (CanMove)
        {
            if (_animator.GetBool(("isWalking")))
            {
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) x = 1.7f;
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) y = 1.5f;
                if (_animator.GetBool("isRunning") && (x != 0 || y != 0))
                {
                    x *= 1.5f;
                    y *= 1.3f;
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
        }
        _rgbody.velocity = new Vector2(x, y);
    }

    public void DisableMovement() => CanMove = false;
    public void EnableMovement() => CanMove = true;

    //public IEnumerator CannotMove(float time)
    //{
    //    CanMove = false;
    //    yield return new WaitForSeconds(time);
    //    CanMove = true;
    //}
}