using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    Animator animator;
    public List<BaseStat> Stats{get;set;}
    public CharacterStats CharacterStats { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Basic Attack");
    }

    public void PerformSpecialAttack()
    {
        animator.SetTrigger("");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.GetComponent<IEnemy>().TakeDamage(CharacterStats.GetStat(BaseStat.BaseStatType.Physical).GetCalcStatValue());
;        }
    }
}
