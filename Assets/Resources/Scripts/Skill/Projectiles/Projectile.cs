using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public Damage Damage { get; set; }

    public Vector3 SpawnPosition { get; set; }

    public string CollideTag { get; set; } = "Enemy";


    protected int SoundID { get; set; }

    protected List<Entity> EntitiesHit = new List<Entity>();
    protected int Pierce { get; set; }

    protected virtual void Start()
    {
        SpawnPosition = transform.position;
        Pierce = 1;
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
        Entity entity = col.GetComponent<Entity>();
        if (entity != null)
        {
            if (!EntitiesHit.Exists(anEntity => anEntity == entity))
            {
                EntitiesHit.Add(entity);
                Damage calculatedDamage = new Damage(SkillActiveEvents.DamageSkillHitEnemy(Damage));
                SoundDatabase.PlaySound(SoundID);
                entity.TakeDamage(calculatedDamage);
                Explode();
                Extinguish();
            }
        }
    }

    public virtual void Explode()
    {

    }

    public virtual void Extinguish()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == CollideTag)
        {
            OnHitActivations(col);
        }
    }
}
