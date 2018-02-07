using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGator : Enemy, IProjectileEnemy
{
    public Projectile Projectile { get; set; }

    public Transform projectileSpawn;

    public void ShootProjectile()
    {
        Projectile currentProjectile = Instantiate(Projectile);
        currentProjectile.CollideTag = "Player";
        currentProjectile.Damage = new Damage();

        currentProjectile.transform.position = projectileSpawn.position;
        if (transform.localScale.x == -1)
        {
            currentProjectile.transform.Rotate(180, 180, 0);
        }
        currentProjectile.transform.localScale = new Vector3(1, 1, 1);
        currentProjectile.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 40f * transform.localScale.x);

        currentProjectile.Damage.HitChance = Stats.Hit - 5;
        currentProjectile.Damage.DamageAmount = (int)(Stats.Physical * 0.45f);
        currentProjectile.Damage.Knockback = 12.5f;
        currentProjectile.Damage.Stun = 0.1f;
    }

    protected override void Awake()
    {
        base.Awake();

        EnemyMovement.xOffSet = Random.Range(2f, 3f);
        EnemyMovement.yOffSet = Random.Range(0f, 1.3f);

        ID = 1;

        Stats.Strength = 2;
        Stats.Vitality = 2;
        Stats.Intelligence = 1;
        Stats.Wisdom = 1;
        Stats.Agility = 6;
        Stats.Perception = 5;
        Stats.Luck = 5;

        Stats.MaxHealth = 275;
        Stats.MaxMana = 50;

        Stats.Physical = 15;
        Stats.Magical = 10;

        Stats.Armor = 35;
        Stats.Resist = 7;

        Stats.Hit = 90;
        Stats.Dodge = 3;
        Stats.Crit = 4;

        Stats.AttackSpeed = 400;
        Knockback = 12.5f;
        Experience = 15;
        Cash = 30;
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>()
        {
            new LootDrop("Leather Hat", 10)
        };

        Projectile = Resources.Load<MagicShot>("Prefabs/Projectiles/MagicShot");

        Stats.CurrentHealth = Stats.MaxHealth;
        Stats.CurrentMana = Stats.MaxMana;

    }
}
