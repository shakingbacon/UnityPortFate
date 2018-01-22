using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenStaff : Staff
{

    public override void GiveStats()
    {
        base.GiveStats();
        Name = "Wooden Staff";
        Description = "A big stick of wood";
        Cost = 625;

        Stats.Physical = 45;
        Stats.Magical = 85;
        Stats.AttackSpeed = 100;

        ProjectilePrefab = Resources.Load<Projectile>("Prefabs/Projectiles/MagicShot");

        StaffDamage = 1.0f;
    }

    public override void CastProjectile()
    {
        base.CastProjectile();
        currentProjectile.Damage.HitChance = player.Hit - 5;
        currentProjectile.Damage.DamageAmount = (int)(Stats.Magical * 0.45f);
        currentProjectile.Damage.Knockback = 3f;
        currentProjectile.Damage.Stun = 0.1f;
    }

}
