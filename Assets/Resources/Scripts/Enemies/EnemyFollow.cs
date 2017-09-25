using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyFollow : MonoBehaviour {

    public float moveSpeedX;
    public float moveSpeedY;
    public float minRange;

    Transform enemy;
    Transform target;
    CircleCollider2D range;
    bool inRange;
    public float xOffSet = 0.1f;
    public float yOffSet = 0.1f;
    bool noMoveY = false;
    public bool canMove, canAttack, onAttackCooldown = false;

    void Start()
    {
        canMove = false;
        enemy = transform.parent.parent;
        target = GameObject.FindWithTag("Player").transform; //target the player
        range = GetComponent<CircleCollider2D>();
        yOffSet = 0.1f;
    }

    void Update()
    {
        if (inRange && canMove)
        {
            print("GG");
            if (!noMoveY)
            {
                if (transform.position.y > target.position.y)
                {
                    enemy.Translate(Vector3.down * Time.deltaTime * moveSpeedY);
                }
                else
                {
                    enemy.Translate(Vector3.up * Time.deltaTime * moveSpeedY);
                }
            }
            if (target.position.y - yOffSet <= transform.position.y && transform.position.y <= target.position.y + yOffSet)
            {
                noMoveY = true;
                if (!(target.position.x - minRange <= transform.position.x && transform.position.x <= target.position.x + minRange))
                {
                    if (transform.position.x <= target.position.x)
                    {
                        enemy.Translate(Vector3.right * Time.deltaTime * moveSpeedX);
                        enemy.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        enemy.Translate(Vector3.left * Time.deltaTime * moveSpeedX);
                        enemy.localScale = new Vector3(1, 1, 1);
                    }
                }
                else
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
            else
            {
                noMoveY = false;
            }
        }
    }

    void FixedUpdate()
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
