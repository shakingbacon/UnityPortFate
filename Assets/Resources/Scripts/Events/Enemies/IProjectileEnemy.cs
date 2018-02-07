using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileEnemy
{
    Projectile Projectile { get; set; }
    void ShootProjectile();
}
