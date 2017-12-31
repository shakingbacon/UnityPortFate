using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : Projectile {

    protected override void Start()
    {
        base.Start();
        Range = 2f;
        GetComponent<Rigidbody2D>().AddForce(Direction * 125f * GameManager.player.transform.localScale.x);
        SoundID = 56;
    }
}
