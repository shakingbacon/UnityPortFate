using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile {

    void Start()
    {
        Range = 3f;
        Damage = 15;
        spawnPosition = transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * 150f * GameManager.player.transform.localScale.x);
        SetSound(13);
    }

}
