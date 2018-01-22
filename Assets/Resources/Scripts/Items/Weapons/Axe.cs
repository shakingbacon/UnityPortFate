using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon {

    DamagingHitbox axeBlade;
    DamagingHitbox axeHandle;

    protected float bladeDamage;
    protected float handleDamage;

    protected override void Awake()
    {
        base.Awake();
        axeBlade = transform.GetChild(0).GetComponent<DamagingHitbox>();
        axeHandle = transform.GetChild(1).GetComponent<DamagingHitbox>();
        axeBlade.DamageMultiplier = bladeDamage;
        axeHandle.DamageMultiplier = handleDamage;
    }

    public override void GiveStats()
    {
        base.GiveStats();
        ItemType = WeaponTypes.Sword.ToString();
    }

}
