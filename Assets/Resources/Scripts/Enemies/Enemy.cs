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
    public EnemyFollow EnemyFollow { get; set; }
    public Rigidbody2D Rigidbody2D { get; set; }

    // MUST SET THESE
    public float Knockback {get;set;}
    public CharacterStats Stats { get; set; }
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    // MUST SET ABOVE

    public int CurrentHealth { get; set; }
    public int CurrentMana { get; set; }
    public float AttackCooldown { get; set; }


    public Player Player { get; set; }
    public PickupItem PickupItemPrefab { get; set; }
    public EnemyHealthBar HealthBar { get; set; }

    void Awake()
    {
        AwakeStuff();
    }

    void FixedUpdate()
    {
        if (EnemyFollow.canAttack)
        {
            PerformAttack();
            AttackCooldown = Stats.GetStat(BaseStat.BaseStatType.AttackSpeed).GetCalcStatValue();
            EnemyFollow.canAttack = false;
            EnemyFollow.onAttackCooldown = true;
            //print("attacked");
        }
        else if (EnemyFollow.onAttackCooldown)
        {
            AttackCooldown -= Time.deltaTime;
            if (AttackCooldown <= 0)
            {
                EnemyFollow.onAttackCooldown = false;
            }
        }
    }

    public virtual void AwakeStuff()
    {
        PickupItemPrefab = Resources.Load<PickupItem>("Prefabs/Interactable/Pickup Item");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        EnemyFollow = GetComponentInChildren<EnemyFollow>();
        HealthBar = EnemyHealthBarController.CreateHealthBar(transform);
        Animator = GetComponent<Animator>();
        CurrentHealth = Stats.GetStat(BaseStat.BaseStatType.Health).GetCalcStatValue();
        CurrentMana = Stats.GetStat(BaseStat.BaseStatType.Mana).GetCalcStatValue();
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
            Player.GetComponent<Rigidbody2D>().MovePosition(
                new Vector2(Player.GetComponent<Rigidbody2D>().position.x - (Knockback * transform.parent.localScale.x), Player.GetComponent<Rigidbody2D>().position.y));
            Player.TakeDamage(Stats.GetStat(BaseStat.BaseStatType.Physical).GetCalcStatValue());
        }
    }

    public virtual void TakeDamage(Damage damage)
    {
        if (!damage.DidHit)
        {
            FloatingText floatingText = FloatingTextController.CreateFloatingText("MISS", gameObject.transform);
            floatingText.transform.localScale = new Vector3(1.25f, 1.25f);
        }
        else
        {
            FloatingText floatingText = FloatingTextController.CreateFloatingText(damage.Amount.ToString(), gameObject.transform);
            if (damage.DidCrit)
            {
                floatingText.transform.localScale = new Vector3(1.4f, 1.4f);
                floatingText.SetCritColor();
            }
            HealthDamaged(damage.Amount);
        }
        if (CurrentHealth <= 0)
        {
            PlayDeathAnim();
        }
    }

    public virtual void HealthDamaged(int amount)
    {
        CurrentHealth-= amount;
        HealthBar.SetSliderValue(CurrentHealth, Stats.GetStat(BaseStat.BaseStatType.Health).GetCalcStatValue());
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
        EnemyFollow.canMove = true;
    }

    public void StartToDie()
    {
        Destroy(Rigidbody2D);
    }


    public void Attacking()
    {
        EnemyFollow.attacking = true;
    }

    public void FinishAttacking()
    {
        EnemyFollow.attacking = false;
    }


}
