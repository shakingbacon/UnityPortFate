using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyMovement : MonoBehaviour
{

    public float moveSpeedX;
    public float moveSpeedY;

    public float CurrentSpeedX { get; set; }
    public float CurrentSpeedY { get; set; }


    public Enemy self;
    public Entity target { get { if (Targets.Count != 0) return Targets[0]; else return null; } }
    CircleCollider2D range;
    Rigidbody2D rigidbody2d;
    public bool inRange;
    public float xOffSet { get; set; }
    public float yOffSet { get; set; }
    bool inXRange = false;
    bool inYRange = false;
    public bool canMove, canAttack, attacking, onAttackCooldown = false;

    public Knockable knockable;
    public Stunable stun;

    List<Entity> Targets { get; set; } = new List<Entity>();

    void Start()
    {
        stun = new Stunable();
        rigidbody2d = transform.parent.GetComponentInParent<Rigidbody2D>();
        knockable = new Knockable(rigidbody2d);
        canMove = false;
        range = GetComponent<CircleCollider2D>();
        range.isTrigger = true;
    }

    void FixedUpdate()
    {
        CurrentSpeedX = 0;
        CurrentSpeedY = 0;

        if (rigidbody2d != null)
        {
            FollowPlayer();
            rigidbody2d.velocity = new Vector2(CurrentSpeedX, CurrentSpeedY);
            knockable.FinalMove();
            if (stun.Stunned) return;
            CanAttack();
            FacePlayer();
        }

    }

    void FollowPlayer()
    {
        if (inRange && canMove && !stun.Stunned)
        {
            if (!(target.transform.position.x - xOffSet <= transform.position.x && transform.position.x <= target.transform.position.x + xOffSet))
            {
                inXRange = false;
                if (transform.position.x < target.transform.position.x)
                    CurrentSpeedX += moveSpeedX;
                else
                    CurrentSpeedX -= moveSpeedX;
            }
            else
            {
                inXRange = true;
            }
            if (!(target.transform.position.y - yOffSet <= transform.position.y && transform.position.y <= target.transform.position.y + yOffSet))
            {
                inYRange = false;
                if (target.transform.position.y > self.transform.position.y)
                {
                    CurrentSpeedY += moveSpeedY;
                }
                else
                {
                    CurrentSpeedY -= moveSpeedY;
                }

            }
            else
            {
                inYRange = true;
            }
        }
    }

    void CanAttack()
    {
        if (target != null)
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
        if (!attacking && target != null)
        {
            if (transform.position.x <= target.transform.position.x)
            {
                self.transform.parent.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                self.transform.parent.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Entity entity = other.GetComponent<Entity>();
        if (entity != null && self.ApplicableTargets.Exists(aTag => aTag == other.tag))
        {
            Targets.Add(entity);
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Entity entity = other.GetComponent<Entity>();
        if (entity != null && self.ApplicableTargets.Exists(aTag => aTag == other.tag))
        {
            inRange = false;
            Targets.Remove(entity);
        }
    }

}
