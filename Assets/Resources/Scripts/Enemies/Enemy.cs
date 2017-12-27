using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
//[RequireComponent(typeof(BoxCollider2D))] // pushing box
[RequireComponent(typeof(PolygonCollider2D))] // actual hitbox

public class Enemy : MonoBehaviour {
    public Animator Animator { get; set; }
    public MonsterSpawner Spawner { get; set; }
    public EnemyMovement EnemyMovement { get; set; }
    public Rigidbody2D Rigidbody2D { get; set; }

    // MUST SET THESE
    public int ID {get;set;}
    public float Knockback { get; set; }
    public CharacterStats Stats { get; set; }
    public int Experience { get; set; }
    public int Cash { get; set; }
    public Skill.SkillElement Attribute { get; set; }
    public EnemyType Type { get; set; }
    public DropTable DropTable { get; set; }
    // MUST SET ABOVE

    public int CurrentHealth { get; set; }
    public int CurrentMana { get; set; }
    public float AttackCooldown { get; set; }


    public Player Player { get; set; }
    public PickupItem PickupItemPrefab { get; set; }
    public EnemyHealthBar HealthBar { get; set; }


    public enum EnemyType
    {
        Reptile
    }

    void Awake()
    {
        AwakeStuff();
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

    public virtual void AwakeStuff()
    {
        PickupItemPrefab = Resources.Load<PickupItem>("Prefabs/Interactable/Pickup Item");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EnemyMovement = GetComponentInChildren<EnemyMovement>();
        HealthBar = EnemyHealthBarController.CreateHealthBar(transform);
        Animator = GetComponent<Animator>();
        CurrentHealth = Stats.Health;
        CurrentMana = Stats.Mana;
        Rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void PerformAttack()
    {
        Animator.SetTrigger("Attack");
    }


    public void PlayDeathAnim()
    {
        Animator.SetTrigger("Die");
    }

    public virtual void DealDamage()
    {
        if (Player.CanBeHit)
        {
            //print("took damage");
            //Player.GetComponent<Rigidbody2D>().AddForce(new Vector3(-transform.parent.localScale.x * Knockback, 0, 0));

            FloatingText floatingText = FloatingTextController.CreateFloatingText(Stats.Physical.ToString(), Player.transform);
            floatingText.SetTextColor(new Color(1,0,1));
            Player.GetComponent<PlayerMovement>().knockable.AddXKnockback(Knockback, transform);
            Player.TakeDamage(Stats.Physical);            
        }
    }

    public virtual void TakeDamage(Damage damage)
    {
        int random = Random.Range(0, 101);
        /*print(random)*/;
        //print(damage.HitChance);
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
        if (CurrentHealth <= 0)
        {
            PlayDeathAnim();
        }
    }

    public virtual void HealthDamaged(int amount)
    {
        CurrentHealth-= amount;
        HealthBar.SetSliderValue(CurrentHealth, Stats.Health);
    }

    public virtual void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if (item != null)
        {
            PickupItem instance = Instantiate(PickupItemPrefab, transform.position, Quaternion.identity);
            instance.transform.SetParent(CurrentMap.Instance.pickupItems);
            instance.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
            instance.transform.localScale = new Vector3(1, 1, 1);
            instance.ItemDrop = item;
        }
        CashDrop.DropCash(Cash, transform);
    }


    public void Die()
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

    public void AfterSpawning()
    {
        EnemyMovement.canMove = true;
    }

    public void StartToDie()
    {
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
