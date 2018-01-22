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
        if (col.tag == "Enemy")
        {
            if (!HurtingObject.EnemiesHit.Exists(aGameObject => aGameObject == col.gameObject)
                && HurtingObject.EnemiesHit.Count < HurtingObject.Pierce)
            {
                HurtingObject.EnemiesHit.Add(col.gameObject);
                Damage damage = new Damage((int)(HurtingObject.Damage * DamageMultiplier));
                damage.HitChance = HurtingObject.HitChance;
                damage.Knockback = HurtingObject.Knockback;
                damage.Stun = HurtingObject.StunDuration;
                HurtingObject.OnHitEffects(damage);
                col.GetComponentInChildren<Enemy>().TakeDamage(damage);
            }
        }
    }
}
