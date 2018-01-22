using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Projectile
{

    bool CanExplode = true;

    protected override void Start()
    {
        base.Start();
        if (CanExplode)
        {
            Range = 3f;
            GetComponent<Rigidbody2D>().AddForce(Direction * 150f * GameManager.Instance.player.transform.localScale.x);
        }
        else
        {
            Range = 0.5f;
        }
        SoundID = 13;
    }

    public override void Explode()
    {
        if (CanExplode)
        {
            Fireball fire1, fire2, fire3, fire4;
            fire1 = MiniFireballFromExplosion(90);
            fire1.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150));
            fire2 = MiniFireballFromExplosion(0);
            fire2.GetComponent<Rigidbody2D>().AddForce(new Vector2(150, 0));
            fire3 = MiniFireballFromExplosion(-90);
            fire3.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -150));
            fire4 = MiniFireballFromExplosion(180);
            fire4.GetComponent<Rigidbody2D>().AddForce(new Vector2(-150, 0));

            // diagonal
            fire1 = MiniFireballFromExplosion(135);
            fire1.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 100));
            fire2 = MiniFireballFromExplosion(-45);
            fire2.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, -100));
            fire3 = MiniFireballFromExplosion(-135);
            fire3.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, -100));
            fire4 = MiniFireballFromExplosion(45);
            fire4.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 100));

        }
    }

    Fireball MiniFireballFromExplosion(int rotation)
    {
        Fireball fireball = Instantiate(Resources.Load<Fireball>("Prefabs/Projectiles/Fireball"));
        fireball.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        fireball.transform.position = transform.position;
        fireball.transform.Rotate(0, 0, rotation);
        fireball.Damage = new Damage(Damage);
        fireball.Damage.DamageAmount = (int)(fireball.Damage.DamageAmount * 0.75f);
        fireball.CanExplode = false;
        fireball.EnemiesHit = EnemiesHit;
        return fireball;
    }

}
