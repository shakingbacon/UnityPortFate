using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item, IWeapon {

    //public string Name { get; set; }
    //public string Description { get; set; }
    //public int Cost { get; set; }
    //public Mortal Stats { get; set; }

    [HideInInspector] public Attributes player;
    public Animator Animator { get; set; }
    //public List<BaseStat> Stats { get; set; }
    public PlayerSkillController playerSkillController { get; set; }
    public int Pierce { get; set; }
    public float Knockback { get; set; }
    public float StunDuration { get; set; }
    public List<GameObject> EnemiesHit { get; set; }

    int collideSoundID = -1;

    public enum WeaponTypes
    {
        Sword,
        Axe,
        Wand,
        Staff
    }

    protected override void Awake()
    {
        base.Awake();
        EnemiesHit = new List<GameObject>();
        Animator = GetComponent<Animator>();
        Pierce = 2;
        ResetEnemiesHit();
    }

    public virtual void SetAttackSpeed(float speed)
    {
        Animator.SetFloat("AttackSpeed", speed);
    }

    public virtual void SetDamageMultiplier(float dmg)
    {
        Animator.SetFloat("DamageMultiplier", dmg);
    }

    public virtual void PerformAttack()
    {
        if (!Animator.GetBool("IsLastAnimation"))
        {
            //CurrentDamage = damage;
            //Debug.Log("damage dealt: " + damage);
            Animator.SetTrigger("Basic Attack");
        }
    }

    public virtual void PerformSkillAnimation()
    {
        if (!Animator.GetBool("IsLastAnimation"))
        {
            Animator.SetTrigger("Skill");
        }
    }

    public virtual void PerformChannelAnimation(Skill skill)
    {
        if (!Animator.GetBool("IsLastAnimation"))
        {
            ChannelBarController.Instance.MakeChannelBar(skill.skillName, skill.skillChannelDuration);
            Animator.SetTrigger("Channel");
            Animator.SetFloat("ChannelTime", 1/skill.skillChannelDuration);
        }
            
    }

    // Animation Events
    public virtual void IsLastAnimation()
    {
        Animator.SetBool("IsLastAnimation", true);
    }

    public virtual void EndLastAnimation()
    {
        Animator.SetBool("IsLastAnimation", false);
    }

    public virtual void PlayerCantMove()
    {
        PlayerMovement.cantMove = true;
    }

    public virtual void PlayerCanMove()
    {
        PlayerMovement.cantMove = false;
    }

    public virtual void ActivateSkill()
    {
        playerSkillController.ActivateSkill(playerSkillController.UsingSkill);
    }

    public void SetCollideSound(int id)
    {
        collideSoundID = id;
    }

    public virtual void OnHit(Damage dmg)
    {
        if (dmg.DidCrit)
            SoundDatabase.PlaySound(11);
        else
            SoundDatabase.PlaySound(collideSoundID);
    }

    public void ResetEnemiesHit()
    {
        EnemiesHit.Clear();
    }

}
