using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    WeaponHitbox swordTip;
    WeaponHitbox swordBase;
    WeaponHitbox swordHilt;

    [SerializeField] float tipDamage;
    [SerializeField] float baseDamage;
    [SerializeField] float hiltDamage;


    public override void StartActivations()
    {
        base.StartActivations();
        swordTip = transform.GetChild(0).GetComponent<WeaponHitbox>();
        swordBase = transform.GetChild(1).GetComponent<WeaponHitbox>();
        swordHilt = transform.GetChild(2).GetComponent<WeaponHitbox>();
        swordTip.DamageMultiplier = tipDamage;
        swordBase.DamageMultiplier = baseDamage;
        swordHilt.DamageMultiplier = hiltDamage;
    }

}
