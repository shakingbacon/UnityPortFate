using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon {

    WeaponHitbox axeCut;
    WeaponHitbox axeHandle;

    [SerializeField]
    float cutDamage;
    [SerializeField] float handleDamage;

    public override void StartActivations()
    {
        base.StartActivations();
        axeCut = transform.GetChild(0).GetComponent<WeaponHitbox>();
        axeHandle = transform.GetChild(1).GetComponent<WeaponHitbox>();
        axeCut.DamageMultiplier = cutDamage;
        axeHandle.DamageMultiplier = handleDamage;
    }


}
