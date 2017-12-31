using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile {

    protected override void Start()
    {
        base.Start();
        Range = 3f;
        GetComponent<Rigidbody2D>().AddForce(Direction * 150f * GameManager.player.transform.localScale.x);
        SoundID = 13;
    }

    void OnDestroy()
    {
       
    }

}
