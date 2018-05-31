using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PolygonCollider2D))]

public abstract class Enemy : Entity
{
    public Animator Animator { get; set; }
    public MonsterSpawner Spawner { get; set; }
    public EnemyMovement EnemyMovement { get; set; }
    public Rigidbody2D Rigidbody2D { get; set; }

    // MUST SET THESE 
    public int ID { get; set; }
    public float Knockback { get; set; }
    public int Experience { get; set; }
    public int Cash { get; set; }
    public DropTable DropTable { get; set; } = new DropTable();

    float AttackCooldown { get; set; }
    public Player Player { get; set; }
    public PickupItem PickupItemPrefab { get; set; }
    public EnemyHealthBar HealthBar { get; set; }

    public List<string> ApplicableTargets = new List<string>() { "Player" };

    protected virtual void Awake()
    {
        PickupItemPrefab = Resources.Load<PickupItem>("Prefabs/Interactable/Pickup Item");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EnemyMovement = GetComponentInChildren<EnemyMovement>();
        EnemyMovement.self = this;
        HealthBar = EnemyHealthBarController.CreateHealthBar(transform);
        Animator = GetComponent<Animator>();
        Stats.CurrentHealth = Stats.MaxHealth;
        Stats.CurrentMana = Stats.MaxMana;
        Rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (EnemyMovement.canAttack)
        {
            PerformAttack();
            AttackCooldown = Stats.AttackSpeed;
            EnemyMovement.canAttack = false;
            EnemyMovement.onAttackCooldown = true;
        }
        else if (EnemyMovement.onAttackCooldown)
        {
            AttackCooldown -= Time.fixedDeltaTime;
            if (AttackCooldown <= 0)
            {
                EnemyMovement.onAttackCooldown = false;
            }
        }
    }

    public void PerformAttack()
    {
        Animator.SetTrigger("Attack");
    }


    public void PlayDeathAnim()
    {
        Animator.SetTrigger("Die");
    }

    // base CreateDamage always deals base physical stat
    public virtual Damage CreateDamage()
    {
        Damage dmg = new Damage();
        dmg.User = transform;
        dmg.DamageAmount = Stats.Physical;
        dmg.CritChance = Stats.Crit;
        dmg.HitChance = Stats.Hit;
        dmg.Knockback = Knockback;
        return dmg;
    }

    public virtual void DealDamage()
    {
        EnemyMovement.CurrentTarget.TakeDamage(CreateDamage());
    }

    public override void TakeDamage(Damage damage)
    {
        damage.CalculateWithDefences(Stats);
        if (!damage.DidHit)
        {
            FloatingText floatingText = FloatingTextController.CreateFloatingText("MISS", gameObject.transform);
            floatingText.transform.localScale = new Vector3(1.25f, 1.25f);
        }
        else
        {
            FloatingText floatingText = FloatingTextController.CreateFloatingText(damage.DamageAmount.ToString(), gameObject.transform);
            if (damage.DidCrit)
            {
                floatingText.transform.localScale = new Vector3(1.4f, 1.4f);
                floatingText.SetCritColor();
            }
            EnemyMovement.knockable.AddXKnockback(damage.Knockback);
            EnemyMovement.stun.AddStun(damage.Stun);
            HealthDamaged(damage.DamageAmount);
        }
        if (Stats.CurrentHealth <= 0)
        {
            PlayDeathAnim();
        }
    }

    protected virtual void HealthDamaged(int amount)
    {
        Stats.CurrentHealth -= amount;
        HealthBar.SetSliderValue(Stats.CurrentHealth, Stats.MaxHealth);
    }

    public virtual void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if (item != null)
        {
            PickupItem instance = Instantiate(PickupItemPrefab, transform.position, Quaternion.identity);
            instance.transform.SetParent(CurrentMap.Instance.pickupItems);
            instance.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.Name);
            instance.transform.localScale = new Vector3(1, 1, 1);
            instance.ItemDrop = item;
        }
        CashDrop.DropCash(Cash, transform);
    }


    public override void Die()
    {
        DropLoot();
        CombatEvents.EnemyDied(this);
        Spawner.Respawn();
        DestroySelf();
    }

    public void DestroySelf()
    {
        Destroy(HealthBar.gameObject);
        Destroy(transform.parent.gameObject);
    }

    public void SetHealthBarNotActive()
    {
        HealthBar.gameObject.SetActive(false);
    }

    public void AfterSpawning()
    {
        HealthBar.UpdateHealthBar();
        HealthBar.gameObject.SetActive(true);
        EnemyMovement.canMove = true;
    }

    public void StartToDie()
    {
        SetHealthBarNotActive();
        Destroy(Rigidbody2D);
    }


    public void Attacking()
    {
        EnemyMovement.attacking = true;
    }

    public void FinishAttacking()
    {
        EnemyMovement.attacking = false;
    }


}
