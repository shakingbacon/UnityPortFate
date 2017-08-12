using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    Animator animator;
    public List<BaseStat> Stats { get; set; }
    public CharacterStats CharacterStats { get; set; }
    public int CurrentDamage { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack(int damage)
    {
        if (!animator.GetBool("IsLastAnimation"))
        {
            CurrentDamage = damage;
            Debug.Log("damage dealt: " + damage);
            animator.SetTrigger("Basic Attack");
        }
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage((int)(CurrentDamage * animator.GetFloat("DamageOutput")));
;        }
    }

    public void IsLastAnimation()
    {
        animator.SetBool("IsLastAnimation", true);
    }

    public void EndLastAnimation()
    {
        animator.SetBool("IsLastAnimation", false);
    }

    public void SetDamageOutput(float dmg)
    {
        animator.SetFloat("DamageOutput", dmg);
    }
}
