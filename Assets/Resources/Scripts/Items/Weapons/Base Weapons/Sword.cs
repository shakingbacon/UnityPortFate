using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sword : Weapon
{
    DamagingHitbox swordTip;
    DamagingHitbox swordBase;
    DamagingHitbox swordHilt;

    protected float TipDamage { get; set; }
    protected float BaseDamage { get; set; }
    protected float HiltDamage { get; set; }

    protected override void Awake()
    {
        base.Awake();
        swordTip = transform.GetChild(0).GetComponent<DamagingHitbox>();
        swordBase = transform.GetChild(1).GetComponent<DamagingHitbox>();
        swordHilt = transform.GetChild(2).GetComponent<DamagingHitbox>();
        swordTip.DamageMultiplier = TipDamage;
        swordBase.DamageMultiplier = BaseDamage;
        swordHilt.DamageMultiplier = HiltDamage;
    }

    public override void GiveStats()
    {
        base.GiveStats();
        ItemType = WeaponTypes.Sword.ToString();
    }

}
