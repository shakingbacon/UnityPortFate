using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody;
    Animator anim;
    public float moveSpeed;
    public static bool cantMove = false;

    public Stun stun;
    public Knockable knockable;

    
	// Use this for initialization
	void Start () {
        stun = new Stun();
        rbody = GetComponent<Rigidbody2D>();
        knockable = new Knockable(rbody);
        anim = GetComponent<Animator>();
        anim.SetFloat("input_x", 1);
        knockable.Multiplier = moveSpeed;
        //spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!cantMove && !stun.Stunned)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");            
            knockable.YMove += inputY;
            if (inputX == -1)
            {
                GameManager.player.transform.localScale = new Vector3(-1, 1, 1);
                knockable.XMove += inputX;
            }
            else if (inputX == 1)
            {
                GameManager.player.transform.localScale= new Vector3(1, 1, 1);
                knockable.XMove -= inputX;
            }
            if (inputX != 0 || inputY != 0)
            {
                anim.SetBool("isWalking", true);
                if (inputX != 0)
                {
                    anim.SetFloat("input_x", inputX);
                }
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        knockable.FinalMove();
        if (stun.Stunned) return;

    }
}
