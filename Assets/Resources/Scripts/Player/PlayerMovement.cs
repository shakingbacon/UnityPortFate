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


    public float BaseSpeedX = 1f;
    public float BaseSpeedY = 1f;


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
        StartCoroutine(RunningLoseMana());
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }



    private void Update()
    {
        UpdateRunning();
    }

    IEnumerator RunningLoseMana()
    {
        while (true)
        {
            if (IsRunning)
            {
                player.AddMana(-((int)(player.Stats.MaxMana * 0.01f)));
                StatusBar.Instance.ManaBarFlash();
            }
            yield return new WaitForSeconds(1.5f);
        }
    }


    void UpdateRunning()
    {
        if (!cantMove && Input.GetKey(KeyCode.LeftShift))
        {
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {

                if (timeRunning > 1f)
                {
                    if (!IsRunning)
                    {
                        SoundDatabase.PlaySound(54);
                        IsRunning = true;
                    }
                }
                else
                {
                    timeRunning += Time.deltaTime;
                    BaseSpeedX = 1.25f + Mathf.Round((0.5f * timeRunning / 0.75f) * 100f) / 100f;
                    BaseSpeedY = 1.1f + Mathf.Round((0.2f * timeRunning / 0.75f) * 100f) / 100f;
                    IsRunning = false;
                }
            }
            else
            {
                IsRunning = false;
            }
        }
        else
        {
            IsRunning = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) ||
            (Input.GetKey(KeyCode.LeftShift) && (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))))
        {
            timeRunning = 0f;
            BaseSpeedX = 1f;
            BaseSpeedY = 1f;
        }
        if (!cantMove && !stun.Stunned)
        {
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            rbody.velocity = new Vector2(inputX * BaseSpeedX * moveSpeedX, inputY * BaseSpeedY * moveSpeedY);
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        knockable.FinalMove();
        if (stun.Stunned) return;
    }
}
