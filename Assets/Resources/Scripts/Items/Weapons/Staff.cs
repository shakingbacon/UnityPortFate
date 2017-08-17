using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    Animator animator;
    public bool InAnimation { get; set; }
    public List<BaseStat> Stats { get; set; }
    public Transform ProjectileSpawn { get; set; }
    public int CurrentDamage { get; set; }

    public PlayerSkillController playerSkillController { get; set; }
    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Prefabs/Items/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        
        animator.SetTrigger("Basic Attack");
    }

    public void PerformSkillAnimation()
    {
        animator.SetTrigger("");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.right;
        fireballInstance.transform.localScale = GameManager.player.transform.localScale;
    }
}
