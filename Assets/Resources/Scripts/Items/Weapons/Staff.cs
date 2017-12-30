using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon, IProjectileWeapon
{
    WeaponHitbox staffBase;
    [SerializeField] float baseDamage;



    public Transform ProjectileSpawn { get; set; }

    public new string ItemType { get { return WeaponTypes.Staff.ToString(); } }

    MagicShot magicShot;

    protected override void Awake()
    {
        base.Awake();
        staffBase = transform.GetChild(0).GetComponent<WeaponHitbox>();
        staffBase.DamageMultiplier = baseDamage;
        magicShot = Resources.Load<MagicShot>("Prefabs/Projectiles/MagicShot");
    }

    public void CastProjectile()
    {
        MagicShot shotProj = Instantiate(magicShot, ProjectileSpawn.position, ProjectileSpawn.rotation);
        shotProj.Damage = new Damage();
        shotProj.Damage.HitChance = Stats.Hit - 5;
        shotProj.Damage.DamageAmount = (int)(Stats.Magical * 0.45f);
        shotProj.Direction = ProjectileSpawn.right;
        shotProj.transform.localScale = GameManager.player.transform.localScale;
    }
}
