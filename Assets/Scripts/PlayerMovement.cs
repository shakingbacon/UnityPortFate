using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody;
    Animator anim;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetFloat("input_x", 1);
        //spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.inBattle && !GameManager.inIntro && !GameManager.cantMove)
        {
            Vector2 moveVect = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (moveVect.x == -1)
            {
                GameManager.playerGameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveVect.x == 1)
            {
                GameManager.playerGameObject.transform.localScale= new Vector3(1, 1, 1);
            }
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
            rbody.MovePosition(rbody.position + moveVect * Time.deltaTime * moveSpeed);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
	}
}
