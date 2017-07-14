using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : MonoBehaviour, IEnemy {

    public int currentHealth, strength, defense;
    public int maxHealth;

    void Start()
    {
        maxHealth = currentHealth;
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }

}
