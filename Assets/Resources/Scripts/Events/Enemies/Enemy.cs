using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
//[RequireComponent(typeof(BoxCollider2D))] // pushing box
[RequireComponent(typeof(PolygonCollider2D))] // actual hitbox

public abstract class Enemy : Entity
{
    public Animator Animator { get; set; }
    public MonsterSpawner Spawner { get; set; }
    public EnemyMovement EnemyMovement { get; set; }
    public Rigidbody2D Rigidbody2D { get; set; }

    // MUST SET THESE
    public int ID { get; set; }
    public float Knockback { get; set; }
    //public CharacterStats Stats { get; set; }
    public int Experience { get; set; }
    public int Cash { get; set; }
    public Skill.SkillElement Attribute { get; set; }
    public EnemyType Type { get; set; }
    public DropTable DropTable { get; set; }
    // MUST SET ABOVE

    //public int CurrentHealth { get; set; }
    //public int CurrentMana { get; set; }
    public float AttackCooldown { get; set; }


    public Player Player { get; set; }
    public PickupItem PickupItemPrefab { get; set; }
    public EnemyHealthBar HealthBar { get; set; }


    public enum EnemyType
    {
        Reptile
    }

    protected virtual void Awake()
    {
        Stats = new Attributes();
        PickupItemPrefab = Resources.Load<PickupItem>("Prefabs/Interactable/Pickup Item");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EnemyMovement = GetComponentInChildren<EnemyMovement>();
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
            //print("attacked");
        }
        else if (EnemyMovement.onAttackCooldown)
        {
            AttackCooldown -= Time.deltaTime;
            if (AttackCooldown <= 0)
            {
                EnemyMovement.onAttackCooldown = false;
            }
        }
    }

    //public virtual void AwakeStuff()
    //{
    //    PickupItemPrefab = Resources.Load<PickupItem>("Prefabs/Interactable/Pickup Item");
    //    Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //    EnemyMovement = GetComponentInChildren<EnemyMovement>();
    //    HealthBar = EnemyHealthBarController.CreateHealthBar(transform);
    //    Animator = GetComponent<Animator>();
    //    CurrentHealth = MaxHealth;
    //    CurrentMana = MaxMana;
    //    Rigidbody2D = GetComponentInParent<Rigidbody2D>();
    //}

    public void PerformAttack()
    {
        Animator.SetTrigger("Attack");
    }


    public void PlayDeathAnim()
    {
        Animator.SetTrigger("Die");
    }

    public virtual void DealDamage(Entity victim)
    {
        victim.TakeDamage(new Damage());
        //if (Player.CanBeHit)
        //{
        //    //print("took damage");
        //    //Player.GetComponent<Rigidbody2D>().AddForce(new Vector3(-transform.parent.localScale.x * Knockback, 0, 0));

        //    FloatingText floatingText = FloatingTextController.CreateFloatingText(Stats.Physical.ToString(), Player.transform);
        //    floatingText.SetTextColor(new Color(1, 0, 1));
        //    Player.GetComponent<PlayerMovement>().knockable.AddXKnockback(Knockback, transform);
        //    Player.TakeDamage(Stats.Physical);
        //}
    }

    public override void TakeDamage(Damage damage)
    {
        int random = Random.Range(0, 101);
        /*print(random)*/
        ;
        //print(damage.HitChance);
        print("hit chance: " + damage.HitChance);
        print("dodge: " + Stats.Dodge);
        if (((damage.HitChance - Stats.Dodge) < random))
        {
            FloatingText floatingText = FloatingTextController.CreateFloatingText("MISS", gameObject.transform);
            floatingText.transform.localScale = new Vector3(1.25f, 1.25f);
        }
        else // DID HIT
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

    public virtual void HealthDamaged(int amount)
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
        DestroyHealthBar();
        Destroy(transform.parent.gameObject);
    }

    public void DestroyHealthBar()
    {
        Destroy(HealthBar.gameObject);
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
