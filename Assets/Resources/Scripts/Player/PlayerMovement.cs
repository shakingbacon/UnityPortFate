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

    public bool IsRunning { get; set; }
    public float timeRunning = 0f;

    float RunningX { get; set; }
    float RunningY { get; set; }


    // Use this for initialization
    void Start()
    {
        player = GetComponent<Player>();
        moveSpeedX = 1.75f;
        moveSpeedY = 1.3f;
        stun = new Stunable();
        rbody = GetComponent<Rigidbody2D>();
        knockable = new Knockable(rbody);
        anim = GetComponent<Animator>();
        anim.SetFloat("input_x", 1);
        knockable.Multiplier = moveSpeedX;
        IsRunning = false;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void Update()
    {
        UpdateRunning();
    }

    void UpdateRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RunningX = 1.25f;
            RunningY = 1.1f;
            moveSpeedX *= RunningX;
            moveSpeedY *= RunningY;
        }
        if (!cantMove && Input.GetKey(KeyCode.LeftShift))
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {
                timeRunning += Time.deltaTime;
                if (timeRunning > 1.25f)
                {
                    if (!IsRunning)
                    {
                        SoundDatabase.PlaySound(54);
                        moveSpeedX /= RunningX;
                        moveSpeedY /= RunningY;
                        RunningX = 1.55f;
                        RunningY = 1.2f;
                        moveSpeedX *= RunningX;
                        moveSpeedY *= RunningY;
                        IsRunning = true;
                    }
                }
                else
                {
                    IsRunning = false;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) ))
        {
            timeRunning = 0f;
            IsRunning = false;
            moveSpeedX /= RunningX;
            moveSpeedY /= RunningY;
        }

        if ( && (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))

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
