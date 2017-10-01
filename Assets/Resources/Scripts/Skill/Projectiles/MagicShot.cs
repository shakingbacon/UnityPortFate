using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : Projectile {

    void Start()
    {
        Damage.DidHit = true;
        Range = 2f;
        Damage.Knockback = 3f;
        Damage.Stun = 0.1f;
        spawnPosition = transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * 125f * GameManager.player.transform.localScale.x);
        SetSound(56);
    }
}
