using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody;
    Animator anim;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveVect = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        /*
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }*/
        
        if (moveVect != Vector2.zero)
        {
            print(moveVect.x);
            anim.SetBool("isWalking", true);
            if (moveVect.x != 0)
            {
                anim.SetFloat("input_x", moveVect.x);
            }
            
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        print(anim.GetBool("isWalking"));

        rbody.MovePosition(rbody.position + moveVect * Time.deltaTime * 1.3f);
	}
}
