using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public CharacterStats Stats { get; set; }
    Animator animator;

    public int CurrentHealth { get; set; }
    public int CurrentMana { get; set; }

    public Job currentJob;
    public PlayerLevel PlayerLevel { get; set; }
    public bool CanBeHit { get; set; }
    
    void Awake()
    {
        CanBeHit = true;
        animator = GetComponent<Animator>();
        PlayerLevel = GetComponent<PlayerLevel>();
        //this.currentHealth = this.maxHealth;
        Stats = new CharacterStats(2, 5, 3, 3, 0, 0, 0, 0, 0, 0, 95, 95, 3, 1);
        UIEventHandler.OnStatsChanged += StatsUpdate;
        UIEventHandler.OnPlayerLevelChanged += StatsUpdate;
    }


    public void HealFullHP()
    {
        CurrentHealth = Stats.Health;
        UIEventHandler.HealthChanged();
    }

    public void HealFullMP()
    {
        CurrentMana = Stats.Mana;
        UIEventHandler.ManaChanged();
    }

    public void AddHealth(int amount)
    {
        CurrentHealth += amount;
        UIEventHandler.HealthChanged();
    }

    public void AddMana(int amount)
    {
        CurrentMana += amount;
        UIEventHandler.ManaChanged();
    }

    public void TakeDamage(int amount)
    {
        StartCoroutine(GotHitFlashing());
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            Die();
        }
        UIEventHandler.HealthChanged();
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
    
    private void Die()
    {
        Debug.Log("Player dead. reset health");
        CurrentHealth = Stats.Health;
        UIEventHandler.HealthChanged();
    }

    public void StatsUpdate()
    {
        switch (0)
        {
            case 0:// Mage Stat Updates
                {   // These are stats based off other stats
                    //
                    Stats.Health = 225 + Stats.Strength * 11 + PlayerLevel.Level * 32;
                    //
                    Stats.Mana = 475 + Stats.Intelligence * 26 + PlayerLevel.Level * 60;
                    //
                    Stats.Physical = 35 + Stats.Strength + PlayerLevel.Level * 3;
                    //
                    Stats.Magical = 60 + Stats.Intelligence * 6 + PlayerLevel.Level * 8;
                    //
                    Stats.Armor = 10 + Stats.Strength * 4 + PlayerLevel.Level * 6;
                    //
                    Stats.Resist = 15 + Stats.Intelligence * 9 + PlayerLevel.Level * 10;
                    //
                    Stats.Hit = 90 + Stats.Agility / 6 + Stats.Luck / 5;
                    //
                    Stats.Dodge = Stats.Agility / 7 + Stats.Luck / 3;
                    //
                    Stats.Crit = Stats.Agility / 5 + Stats.Luck / 4;
                    break;
                }
        }
        UIEventHandler.HealthChanged();
        UIEventHandler.ManaChanged();
    }
}
