﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShot : Projectile {

    void Start()
    {
        Range = 2f;
        spawnPosition = transform.position;
        GetComponent<Rigidbody2D>().AddForce(Direction * 125f * GameManager.player.transform.localScale.x);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            SoundDatabase.PlaySound(2);
            col.gameObject.GetComponent<IEnemy>().TakeDamage(Damage);
            Extinguish();
        }
    }
}
