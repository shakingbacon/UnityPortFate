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

    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public PickupItem pickupItem;

    public EnemyHealthBar healthBar;
    //private Collider2D[] withinAggroCollider;


    void Awake()
    {
        healthBar = EnemyHealthBarController.CreateHealthBar(transform);
        print("GG");
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

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetSliderValue(currentHealth, maxHealth);
        FloatingTextController.CreateFloatingText(amount.ToString(), gameObject.transform);
        if (currentHealth <= 0)
        {
            Destroy(healthBar.gameObject);
            PlayDeathAnim();
        }
    }

    //void ChasePlayer(Player player)
    //{
    //    this.player = player;
    //    navAgent.destination = (player.transform.position);
    //}

    public void PlayDeathAnim()
    {
        Animator.SetTrigger("Die");
    }

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
