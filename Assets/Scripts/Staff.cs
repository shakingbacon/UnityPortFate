using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    Animator animator;
    public List<BaseStat> Stats{get;set;}
    public Transform ProjectileSpawn { get; set; }
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        
        animator.SetTrigger("Basic Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.right;
        fireballInstance.transform.localScale = GameManager.playerGameObject.transform.localScale;
    }
}
