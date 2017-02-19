using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody;
    Animator anim;
    GameManager manager;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        anim.SetFloat("input_x", 1);
        //spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!manager.inBattle)
        {
            Vector2 moveVect = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (moveVect != Vector2.zero)
            {
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
            rbody.MovePosition(rbody.position + moveVect * Time.deltaTime * 1.3f);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

	}
}
