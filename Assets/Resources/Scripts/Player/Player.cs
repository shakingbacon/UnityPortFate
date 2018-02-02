using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Attributes Stats { get; set; }
    //public CharacterStats Stats { get; set; }
    Animator animator;

    public int CurrentHealth { get { return Stats.CurrentHealth; } set { Stats.CurrentHealth = value; UIEventHandler.HealthChanged(); } }
    public int CurrentMana { get { return Stats.CurrentMana; } set { Stats.CurrentMana = value; UIEventHandler.ManaChanged(); } }



    public string Name { get; set; }
    //public JobTypes CurrentJob { get; set; }

    //public enum enum JobTypes
    //{
    //    Mage,
    //    Rogue,
    //    Warrior
    //}

    public PlayerLevel PlayerLevel { get; set; }

    int sp;
    public int SkillPoints { get { return sp; } set { sp = value; UIEventHandler.SpChanged(); } }


    public bool CanRegenerate { get; set; }
    public bool CanBeHit { get; set; }


    void Awake()
    {
        UIEventHandler.OnSPChange += () => SkillUI.Instance.SetSPText(sp.ToString());
        SkillPoints = 3;
        //Stats = new Attributes();
        CanBeHit = true;
        animator = GetComponent<Animator>();
        PlayerLevel = GetComponent<PlayerLevel>();
        //this.currentHealth = this.maxHealth;
        //Stats = new CharacterStats(2, 5, 3, 3, 0, 0, 0, 0, 0, 0, 95, 95, 3, 1);
        UIEventHandler.OnStatsChanged += StatsUpdate;
        UIEventHandler.OnPlayerLevelChanged += StatsUpdate;
        CanRegenerate = true;
    }

    public void HealFullHP()
    {
        Stats.CurrentHealth = Stats.MaxHealth;
        UIEventHandler.HealthChanged();
    }

    public void HealFullMP()
    {
        CurrentMana = Stats.MaxMana;
        UIEventHandler.ManaChanged();
    }

    public void AddHealth(int amount)
    {
        if (CurrentHealth + amount > Stats.MaxHealth)
            CurrentHealth = Stats.MaxHealth;
        else
            CurrentHealth += amount;
        UIEventHandler.HealthChanged();
    }

    public void AddMana(int amount)
    {
        if (CurrentMana + amount > Stats.MaxMana)
        {
            CurrentMana = Stats.MaxMana;
        }
        else
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
            Stats.CurrentHealth -= amount;
            if (Stats.CurrentHealth <= 0)
            {
                Die();
            }
            StatusBar.Instance.HealthBarFlash();
            UIEventHandler.HealthChanged();
        }
        StartCoroutine(GotHitFlashing());
    }

    public IEnumerator Regenerate()
    {
        while (CanRegenerate)
        {
            AddHealth((int)Stats.HealthRegen);
            AddMana((int)Stats.ManaRegen);
            yield return new WaitForSeconds(10f);
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
        Stats.CurrentHealth = Stats.MaxHealth;
        UIEventHandler.HealthChanged();
    }

    public void StatsUpdate()
    {
        Stats.UpdateStats(PlayerLevel.Level);
        UIEventHandler.HealthChanged();
        UIEventHandler.ManaChanged();
    }
}
