using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    WeaponHitbox swordTip;
    WeaponHitbox swordBase;
    WeaponHitbox swordHilt;

    protected float TipDamage { get; set; }
    protected float BaseDamage { get; set; }
    protected float HiltDamage { get; set; }

    public override WeaponTypes Type { get { return WeaponTypes.Sword; } }

    protected override void Awake()
    {
        base.Awake();
        swordTip = transform.GetChild(0).GetComponent<WeaponHitbox>();
        swordBase = transform.GetChild(1).GetComponent<WeaponHitbox>();
        swordHilt = transform.GetChild(2).GetComponent<WeaponHitbox>();
        swordTip.DamageMultiplier = TipDamage;
        swordBase.DamageMultiplier = BaseDamage;
        swordHilt.DamageMultiplier = HiltDamage;
    }

    //public override void GiveStats()
    //{
    //    base.GiveStats();
    //}

}
