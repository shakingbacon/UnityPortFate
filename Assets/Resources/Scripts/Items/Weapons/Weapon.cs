using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon {
    public Animator Animator { get; set; }
    public List<BaseStat> Stats { get; set; }
    public PlayerSkillController playerSkillController { get; set; }
    public Damage CurrentDamage { get; set; }
    public int Pierce { get; private set; }
    public int EnemiesHit { get; set; }


    int collideSoundID = -1;

    void Start()
    {
        StartActivations();
        Pierce = 1;
        EnemiesHit = 0;
    }

    public virtual void StartActivations()
    {
        Animator = GetComponent<Animator>();
    }

    public virtual void SetDamageMultiplier(float dmg)
    {
        Animator.SetFloat("DamageMultiplier", dmg);
    }

    public virtual void PerformAttack(Damage damage)
    {
        if (!Animator.GetBool("IsLastAnimation"))
        {
            CurrentDamage = damage;
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
        UIEventHandler.SkillUsed();
    }

    public void SetCollideSound(int id)
    {
        collideSoundID = id;
    }

    public virtual void OnHit()
    {
        if (CurrentDamage.DidCrit)
            SoundDatabase.PlaySound(11);
        else
            SoundDatabase.PlaySound(collideSoundID);
    }

}
