using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public Damage Damage { get; set; }

    public Vector3 SpawnPosition { get; set; }

    protected int SoundID { get; set; }

    protected virtual void Start()
    {
        SpawnPosition = transform.position;
    }



    void Update()
    {
        if (Vector3.Distance(SpawnPosition, transform.position) >= Range)
        {
            Extinguish();
        }
    }

    public virtual void OnHitActivations(Collider2D col)
    {
        //Debug.Log("Hit an Enemy");
        Damage calculatedDamage = new Damage(SkillActiveEvents.DamageSkillHitEnemy(Damage));
        SoundDatabase.PlaySound(SoundID);
        Enemy enemy = col.GetComponent<Enemy>();
        enemy.EnemyMovement.inRange = true;
        enemy.TakeDamage(calculatedDamage);

        Extinguish();
    }

    public virtual void Extinguish()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy")
        {
            OnHitActivations(col);
        }
    }
}
