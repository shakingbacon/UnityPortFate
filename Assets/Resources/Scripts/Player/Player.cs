using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterStats characterStats;
    Animator animator;
    public int currentHealth;
    public int maxHealth;
    public PlayerLevel PlayerLevel { get; set; }
    public int Cash { get; private set; }
    public bool CanBeHit { get; set; }
    void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerLevel = GetComponent<PlayerLevel>();
        //this.currentHealth = this.maxHealth;
        characterStats = new CharacterStats(2, 5, 3, 3, 0, 0, 0, 0, 0, 0, 95, 95, 3, 1);
        AddCash(10);
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(GotHitFlashing());
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }
    
    IEnumerator GotHitFlashing()
    {
        CanBeHit = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color color1 = new Color(0.75f, 0.2f, 0.2f);
        Color color2 = new Color(0.35f, 0.2f, 0.2f);
        spriteRenderer.color = color1;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = color2;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = color1;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = color2;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = color1;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
        CanBeHit = true;
    }
    
    public void AddCash(int amount)
    {
        Cash += amount;
    }

    private void Die()
    {
        Debug.Log("Player dead. reset health");
        this.currentHealth = this.maxHealth;
        UIEventHandler.HealthChanged(this.currentHealth, this.maxHealth);
    }
}
