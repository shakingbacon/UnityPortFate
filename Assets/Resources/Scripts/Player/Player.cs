using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Animator animator;

    public int CurrentHealth { get { return Stats.CurrentHealth; } set { Stats.CurrentHealth = value; UIEventHandler.HealthChanged(); } }
    public int CurrentMana { get { return Stats.CurrentMana; } set { Stats.CurrentMana = value; UIEventHandler.ManaChanged(); } }

    public PlayerLevel PlayerLevel { get; set; }
    public PlayerMovement PlayerMovement { get; set; }

    int sp;
    public int SkillPoints { get { return sp; } set { sp = value; UIEventHandler.SpChanged(); } }

    void Awake()
    {
        UIEventHandler.OnSPChange += () => SkillUI.Instance.SetSPText(sp.ToString());
        SkillPoints = 3;
        CanBeHit = true;
        animator = GetComponent<Animator>();
        PlayerLevel = GetComponent<PlayerLevel>();
        PlayerMovement = GetComponent<PlayerMovement>();
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

    public delegate Damage TakeDamageModifier(Damage damage);
    public static event TakeDamageModifier OnTakeDamage;

    public override void TakeDamage(Damage dmg)
    {
        if (true)
        {
            if (OnTakeDamage != null)
                dmg = OnTakeDamage(dmg);
            dmg.CalculateWithDefences(Stats);
            if (dmg.DidHit)
            {
                Stats.CurrentHealth -= dmg.DamageAmount;
                if (Stats.CurrentHealth <= 0)
                {
                    Die();
                }
                FloatingText floatingText = FloatingTextController.CreateFloatingText(dmg.DamageAmount.ToString(), transform);
                if (dmg.DidCrit) floatingText.SetCritColor();
                StatusBar.Instance.HealthBarFlash();
                UIEventHandler.HealthChanged();
                StartCoroutine(GotHitFlashing());
                PlayerMovement.knockable.AddXKnockback(dmg.Knockback, dmg.User);
                if (dmg.Stun > 0)
                {
                    animator.SetTrigger("CannotAttack");
                    PlayerCanvasStatusEffect.Instance.AddStatus("Stun", dmg.Stun);
                    PlayerMovement.stun.AddStun(dmg.Stun);
                }
            }
            else
            {
                FloatingTextController.CreateFloatingText("MISS", transform);
            }
        }
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

    public override void Die()
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
