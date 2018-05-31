using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Parent must have interface: IHasHitbox
public class DamagingHitbox : MonoBehaviour
{
    IHasHitbox HurtingObject { get; set; }
    public float DamageMultiplier { get; set; }

    //public Damage damage { get; set; }

    protected virtual void Start()
    {
        HurtingObject = GetComponentInParent<IHasHitbox>();
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        Entity entity = col.GetComponent<Entity>();
        if (entity != null)
        {
            if (!HurtingObject.EntitiesHit.Exists(anEntity => anEntity == entity)
                && HurtingObject.EntitiesHit.Count < HurtingObject.Pierce)
            {
                HurtingObject.EntitiesHit.Add(entity);
                Damage damage = new Damage();
                damage.DamageAmount = (int)(HurtingObject.Damage * DamageMultiplier);
                damage.HitChance = HurtingObject.HitChance;
                damage.Knockback = HurtingObject.Knockback;
                damage.Stun = HurtingObject.StunDuration;
                HurtingObject.OnHitEffects(damage);
                entity.TakeDamage(damage);
            }
        }
    }
}
