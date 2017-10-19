using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    //private SpriteRenderer spriteRenderer;
    private static Rigidbody2D rbody;
    Animator anim;
    public float moveSpeed;
    public static bool cantMove = false;

    public Stunable stun;
    public Knockable knockable;

	// Use this for initialization
	void Start () {
        stun = new Stunable();
        rbody = GetComponent<Rigidbody2D>();
        knockable = new Knockable(rbody);
        anim = GetComponent<Animator>();
        anim.SetFloat("input_x", 1);
        knockable.Multiplier = moveSpeed;
        //spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public static IEnumerator SetVelocityForSetTime(float x, float time)
    {
        rbody.velocity = new Vector2(x, 0);
        print(rbody.velocity);
        yield return new WaitForSeconds(time);
        rbody.velocity = new Vector2();
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (!cantMove && !stun.Stunned)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");            
            knockable.YKnockback += inputY;
            if (inputX == -1)
            {
                GameManager.player.transform.localScale = new Vector3(-1, 1, 1);
                knockable.AddXKnockback(inputX);
            }
            else if (inputX == 1)
            {
                GameManager.player.transform.localScale= new Vector3(1, 1, 1);
                knockable.AddXKnockback(inputX);
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
