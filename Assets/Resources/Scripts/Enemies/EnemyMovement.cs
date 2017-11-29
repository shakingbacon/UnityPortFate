using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyMovement : MonoBehaviour {

    public float moveSpeedX;
    public float moveSpeedY;

    Transform enemy;
    Transform target;
    CircleCollider2D range;
    Rigidbody2D rigidbody2d;
    public bool inRange;
    float xOffSet;
    float yOffSet;
    bool inXRange = false;
    bool inYRange = false;
    public bool canMove, canAttack, attacking, onAttackCooldown = false;

    public Knockable knockable;
    public Stunable stun;

    void Start()
    {
        stun = new Stunable();
        rigidbody2d = transform.parent.GetComponentInParent<Rigidbody2D>();
        knockable = new Knockable(rigidbody2d);
        xOffSet = Random.Range(0.6f, 0.8f);
        yOffSet = Random.Range(0f, 0.9f);
        canMove = false;
        enemy = transform.parent.parent;
        target = GameObject.FindWithTag("Player").transform; //target the player
        range = GetComponent<CircleCollider2D>();
        range.isTrigger = true;
    }

    void FixedUpdate()
    {
        moveSpeedX = 0;
        moveSpeedY = 0;
        FollowPlayer();
        rigidbody2d.velocity = new Vector2(moveSpeedX, moveSpeedY);
        knockable.FinalMove();
        if (stun.Stunned) return;
        CanAttack();
        FacePlayer();
    }

    void FollowPlayer()
    {
        if (rigidbody2d != null)
        {
            if (inRange && canMove && !stun.Stunned)
            {
                if (!(target.position.x - xOffSet <= transform.position.x && transform.position.x <= target.position.x + xOffSet))
                {
                    inXRange = false;
                    if (transform.position.x < target.position.x)
                        moveSpeedX = 0.5f;
                    else
                        moveSpeedX = -0.5f;
                }
                else
                {
                    inXRange = true;
                    moveSpeedX = 0;
                }
                if (!(target.position.y - yOffSet <= transform.position.y && transform.position.y <= target.position.y + yOffSet))
                {
                    inYRange = false;
                    if (target.position.y > enemy.position.y)
                    {
                        moveSpeedY = 0.5f;
                    }
                    else
                    {
                        moveSpeedY = -0.5f;
                    }

                }
                else
                {
                    inYRange = true;
                    moveSpeedY = 0;

                }
            }
        }
    }

    void CanAttack()
    {
        if (inXRange && inYRange)
        {
            if (!onAttackCooldown)
            {
                canAttack = true;
            }
            else
            {
                canAttack = false;
            }
        }
    }

    void FacePlayer()
    {
        if (!attacking)
        {
            if (transform.position.x <= target.position.x)
            {
                enemy.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                enemy.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

}
