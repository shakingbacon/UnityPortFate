using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : Weapon, IProjectileWeapon
{
    public Transform ProjectileSpawn { get; set; }

    MagicShot magicShot;

    void Start()
    {
        magicShot = Resources.Load<MagicShot>("Prefabs/Projectiles/MagicShot");
    }

    public void CastProjectile()
    {
        MagicShot shotProj = Instantiate(magicShot, ProjectileSpawn.position, ProjectileSpawn.rotation);
        shotProj.Damage = (int)(CurrentDamage.Amount * 0.45f);
        shotProj.Direction = ProjectileSpawn.right;
        shotProj.transform.localScale = GameManager.player.transform.localScale;
    }
}
