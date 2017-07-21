using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Gator : MonoBehaviour, IEnemy
{
    //public LayerMask aggroLayerMask;
    public int currentHealth, strength, defense;
    public int maxHealth;

    private Player player;
    //private NavMeshAgent navAgent;
    public CharacterStats characterStats;
    //private Collider2D[] withinAggroCollider;


    void Awake()
    {
        //navAgent = GetComponent<NavMeshAgent>();
        characterStats = new CharacterStats(10, 15, 5, 2);
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
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //void ChasePlayer(Player player)
    //{
    //    this.player = player;
    //    navAgent.destination = (player.transform.position);
    //}

    void Die()
    {
        Destroy(gameObject);
    }

}
