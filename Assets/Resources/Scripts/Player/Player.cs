using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mortal
{

    //public CharacterStats Stats { get; set; }
    Animator animator;


    int currentMana = 0;

    public new int CurrentHealth { get; set; }
    public new int CurrentMana { get { return currentMana; } set { currentMana = value; UIEventHandler.ManaChanged(); } }

    public Job currentJob;
    public PlayerLevel PlayerLevel { get; set; }
    public bool CanBeHit { get; set; }

    void Awake()
    {
        CanBeHit = true;
        animator = GetComponent<Animator>();
        PlayerLevel = GetComponent<PlayerLevel>();
        //this.currentHealth = this.maxHealth;
        //Stats = new CharacterStats(2, 5, 3, 3, 0, 0, 0, 0, 0, 0, 95, 95, 3, 1);
        UIEventHandler.OnStatsChanged += StatsUpdate;
        UIEventHandler.OnPlayerLevelChanged += StatsUpdate;
    }


    public void HealFullHP()
    {
        CurrentHealth = MaxHealth;
        UIEventHandler.HealthChanged();
    }

    public void HealFullMP()
    {
        CurrentMana = MaxMana;
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

    public delegate int TakeDamageModifier(int damage);
    public static event TakeDamageModifier OnTakeDamage;

    public void TakeDamage(int amount)
    {
        if (OnTakeDamage != null)
            amount = OnTakeDamage(amount);
        if (amount > 0)
        {
            StartCoroutine(GotHitFlashing());
            CurrentHealth -= amount;
            if (CurrentHealth <= 0)
            {
                Die();
            }
            UIEventHandler.HealthChanged();
        }
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
        CurrentHealth = MaxHealth;
        UIEventHandler.HealthChanged();
    }

    public void StatsUpdate()
    {
        switch (0)
        {
            case 0:// Mage Stat Updates
                {   // These are stats based off other stats
                    //
                    MaxHealth = 225 + Strength * 11 + PlayerLevel.Level * 32;
                    //
                    MaxMana = 475 + Intelligence * 26 + PlayerLevel.Level * 60;
                    //
                    Physical = 35 + Strength + PlayerLevel.Level * 3;
                    //
                    Magical = 60 + Intelligence * 6 + PlayerLevel.Level * 8;
                    //
                    Armor = 10 + Strength * 4 + PlayerLevel.Level * 6;
                    //
                    Resist = 15 + Intelligence * 9 + PlayerLevel.Level * 10;
                    //
                    Hit = 90 + Agility / 6 + Luck / 5;
                    //
                    Dodge = Agility / 7 + Luck / 3;
                    //
                    Crit = Agility / 5 + Luck / 4;
                    break;
                }
        }
        UIEventHandler.HealthChanged();
        UIEventHandler.ManaChanged();
    }
}
