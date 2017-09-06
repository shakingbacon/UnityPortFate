using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Gator : MonoBehaviour, IEnemy
{
    public Animator Animator { get; set; }
    //public LayerMask aggroLayerMask;
    public int currentHealth, strength, defense;
    public int maxHealth;

    private Player player;
    //private NavMeshAgent navAgent;
    public CharacterStats characterStats;


    [SerializeField] public int MonsterID { get; set; }
    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public PickupItem pickupItem;

    public EnemyHealthBar healthBar;
    //private Collider2D[] withinAggroCollider;


    void Awake()
    {
        MonsterID = 0;
        healthBar = EnemyHealthBarController.CreateHealthBar(transform);
        Animator = GetComponent<Animator>();
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("Leather Hat", 35),
            new LootDrop("Longsword", 5),
            new LootDrop("Log Potion", 40)
        };
        Experience = 20;
        //navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(5,1,5,5, 275, 100, 100, 25, 40, 10, 95, 5, 4, 1);
        maxHealth = currentHealth;
    }
    //void FixedUpdate()
    //{
    //    withinAggroCollider = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), 5, aggroLayerMask);
    //    if (withinAggroCollider.Length > 0)
    //    {
    //        ChasePlayer(withinAggroCollider[0].GetComponent<Player>());
    //    }
    //}


    public void PerformAttack()
    {
        player.TakeDamage(5);
    }
    
    public void TakeDamage(Damage damage)
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
                floatingText.transform.localScale = new Vector3(1.3f, 1.3f);
                floatingText.SetCritColor();
            }
            HealthDamaged(damage.Amount);
        }
        if (currentHealth <= 0)
        {
            DestroyHealthBar();
            PlayDeathAnim();
        }
    }

    public void HealthDamaged(int amount)
    {
        currentHealth -= amount;
        healthBar.SetSliderValue(currentHealth, maxHealth);
    }

    //void ChasePlayer(Player player
    //{
    //    this.player = player;
    //    navAgent.destination = (player.transform.position);
    //}

    public void DestroyHealthBar()
    {
        Destroy(healthBar.gameObject);
    }

    public void PlayDeathAnim()
    {
        Animator.SetTrigger("Die");
    }
     // this function is event animation of die animation
    public void Die()
    {
        DropLoot();
        CombatEvents.EnemyDied(this);
        Destroy(gameObject);
    }

    void DropLoot()
    {
        Item item = DropTable.GetDrop();
        if (item != null)
        {
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
            instance.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
            instance.transform.localScale = new Vector3(1, 1, 1);
            instance.ItemDrop = item;
        }
    }


}
