using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile {

    void Start()
    {
        Damage.DidHit = true;
        Damage.Knockback = 7f;
        Damage.Stun = 0.25f;
        Range = 3f;
        Damage.Amount = 175;
        spawnPosition = transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * 150f * GameManager.player.transform.localScale.x);
        SetSound(13);
    }

}
