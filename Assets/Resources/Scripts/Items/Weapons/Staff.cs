using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Staff : Weapon, IProjectileWeapon
{
    DamagingHitbox staffBase;
    protected float StaffDamage { get; set; }

    public Transform ProjectileSpawn { get; set; }

    protected Projectile ProjectilePrefab { get; set; }
    //MagicShot magicShot;
    protected Projectile currentProjectile;

    protected override void Awake()
    {
        base.Awake();
        staffBase = transform.GetChild(0).GetComponent<DamagingHitbox>();
        staffBase.DamageMultiplier = StaffDamage;
    }

    public override void GiveStats()
    {
        base.GiveStats();
        ItemType = WeaponTypes.Staff.ToString();
    }

    public virtual void CastProjectile()
    {
        currentProjectile = Instantiate(ProjectilePrefab);
        currentProjectile.Damage = new Damage();


        currentProjectile.Direction = ProjectileSpawn.right;
        currentProjectile.transform.position = ProjectileSpawn.position;
        if (ProjectileSpawn.parent.localScale.x == -1)
        {
            currentProjectile.transform.Rotate(180, 180, 0);
        }
        currentProjectile.transform.localScale = new Vector3(1, 1, 1);
    }
}
