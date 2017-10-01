using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public Damage Damage { get; set; }
    [HideInInspector]public Vector3 spawnPosition;

    int soundID;
    
    void Awake()
    {
        Damage = new Damage();
    }

    void Update()
    {
        if (Vector3.Distance(spawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    public virtual void SoundHit()
    {
        SoundDatabase.PlaySound(soundID);
    }

    public void SetSound(int id) { soundID = id; }

    public virtual void OnHitActivations(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            //Debug.Log("Hit an Enemy");
            SoundHit();
            Enemy enemy = col.GetComponent<Enemy>();
            enemy.EnemyMovement.inRange = true;
            enemy.TakeDamage(Damage);
            enemy.EnemyMovement.knockable.AddXKnockback(Damage.Knockback, transform);
            enemy.EnemyMovement.stun.StunnedDuration += Damage.Stun;
            Extinguish();
        }
    }

    public virtual void Extinguish()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        OnHitActivations(col);
    }
}
