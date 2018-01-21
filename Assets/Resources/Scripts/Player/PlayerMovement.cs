using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    //private SpriteRenderer spriteRenderer;
    private static Rigidbody2D rbody;
    Animator anim;
    public float moveSpeed;
    public static bool cantMove = false;

    public float moveSpeedX { get; set; }
    public float moveSpeedY { get; set; }

    public Stunable stun;
    public Knockable knockable;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        moveSpeedX = 2;
        moveSpeedY = 2;
        stun = new Stunable();
        rbody = GetComponent<Rigidbody2D>();
        knockable = new Knockable(rbody);
        anim = GetComponent<Animator>();
        anim.SetFloat("input_x", 1);
        knockable.Multiplier = moveSpeed;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!cantMove && !stun.Stunned)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            rbody.velocity = new Vector2(inputX * moveSpeedX, inputY * moveSpeedY);
            if (inputX == -1)
                player.transform.localScale = new Vector3(-1, 1, 1);
            else if (inputX == 1)
                player.transform.localScale = new Vector3(1, 1, 1);
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
            rbody.velocity = new Vector2(0, 0);
            anim.SetBool("isWalking", false);
        }
        knockable.FinalMove();
        if (stun.Stunned) return;
    }
}
