using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockable {
    // class using this class must this to  rigid.movepos

    Rigidbody2D rigidbody2d { get; set; }


    protected float xMove = 0;
    protected float yMove = 0;
    float multiplier = 1;
    public float Multiplier { get { return multiplier; } set { multiplier = 1 * value; } }
    public float XMove { get { return xMove; } set { xMove += ChangeMoveByScale(value); } }
    public float YMove { get { return yMove; } set { yMove += value; } }

    // this function should be used in fixed update
    public void FinalMove()
    {
        rigidbody2d.MovePosition(rigidbody2d.position + new Vector2(xMove * Time.fixedDeltaTime, yMove * Time.fixedDeltaTime) * Multiplier);
        xMove = 0;
        yMove = 0;
    }


    float ChangeMoveByScale(float value)
    {
        return value * - rigidbody2d.transform.localScale.x;
    }

    public Knockable(Rigidbody2D body)
    {
        rigidbody2d = body;
        multiplier = 1;
    }

}
