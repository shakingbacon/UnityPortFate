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
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            SoundDatabase.PlaySound(13);
            col.gameObject.GetComponent<IEnemy>().TakeDamage(Damage);
            Extinguish();
        }
    }

}
