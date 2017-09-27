using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon {
    public Animator Animator { get; set; }
    public List<BaseStat> Stats { get; set; }
    public PlayerSkillController playerSkillController { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int pierce;
    public float knockback;
    public List<GameObject> EnemiesHit { get; set; }


    int collideSoundID = -1;

    void Start()
    {
        StartActivations();
        pierce = 2;
        ResetEnemiesHit();
    }

    public virtual void StartActivations()
    {
        Animator = GetComponent<Animator>();
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

    public virtual void OnHit(Damage dmg)
    {
        if (dmg.DidCrit)
            SoundDatabase.PlaySound(11);
        else
            SoundDatabase.PlaySound(collideSoundID);
    }

    public void ResetEnemiesHit()
    {
        EnemiesHit = new List<GameObject>();
    }


}
