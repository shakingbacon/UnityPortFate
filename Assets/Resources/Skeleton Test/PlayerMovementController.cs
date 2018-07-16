using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public static PlayerMovementController Instance { get; set; }

    Rigidbody2D rgbody;
    Animator animator;

    bool CanMove { get; set; } = true;

    void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;

        rgbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


    }

    void Update()
    {
        float x = 0, y = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) x = -1.7f;
        else if (Input.GetKey(KeyCode.RightArrow)) x = 1.7f;
        if (Input.GetKey(KeyCode.UpArrow)) y = 1.5f;
        else if (Input.GetKey(KeyCode.DownArrow)) y = -1.5f;

        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        bool pressingShift = false;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            pressingShift = true;
            x *= 1.5f;
            y *= 1.3f;
        }

        if (x != 0 || y != 0)
        {
            if (pressingShift) animator.SetBool("isRunning", true);
            animator.SetBool("isWalking", true);
        }
        else 

        if (CanMove)
        {
            if (animator.GetBool("isWalking"))
            {
                if (x < 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
                else if (x != 0) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            x = 0; y = 0;
        }
        rgbody.velocity = new Vector2(x, y);

    }

    public IEnumerator CannotMove(float time)
    {
        CanMove = false;
        yield return new WaitForSeconds(time);
        CanMove = true;
    }



}