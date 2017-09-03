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
            if (parentWeapon.EnemiesHit < parentWeapon.Pierce)
            {
                parentWeapon.EnemiesHit += 1;
                parentWeapon.OnHit();
                parentWeapon.CurrentDamage.FinalAmount
                    = (int)(parentWeapon.CurrentDamage.Amount * parentWeapon.Animator.GetFloat("DamageMultiplier")
                    * DamageMultiplier);
                col.GetComponent<IEnemy>().TakeDamage(parentWeapon.CurrentDamage);
            }
        }
    }
}
