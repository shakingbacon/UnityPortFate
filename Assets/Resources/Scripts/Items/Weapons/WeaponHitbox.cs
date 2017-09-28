using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitbox : MonoBehaviour {

    Weapon parentWeapon;
    public float DamageMultiplier { get; set; }

    void Start()
    {
        parentWeapon = transform.parent.GetComponent<Weapon>();
    }


    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            if (!parentWeapon.EnemiesHit.Exists(aGameObject => aGameObject == col.gameObject)
                && parentWeapon.EnemiesHit.Count < parentWeapon.pierce)
            {
                parentWeapon.EnemiesHit.Add(col.gameObject);
                Damage damage = new Damage((int)(parentWeapon.CharacterStats.GetStat(BaseStat.BaseStatType.Physical).FinalValue
                    * parentWeapon.Animator.GetFloat("DamageMultiplier") * DamageMultiplier));
                parentWeapon.OnHit(damage);
                col.GetComponentInChildren<Enemy>().TakeDamage(damage);
                col.GetComponentInChildren<Enemy>().EnemyFollow.knockable.XMove = -parentWeapon.knockback;
                col.GetComponentInChildren<Enemy>().EnemyFollow.stun.StunnedDuration += parentWeapon.stunDuration;
            }
        }
    }
}
