using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public static PlayerWeaponController Instance { get; set; }

    public Transform rightHand;
        
    public Weapon EquippedWeapon { get { return rightHand.GetComponentInChildren<Weapon>(); } }

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    // 0 is false, other is true
    public void WeaponHitboxActivate()
    {
        EquippedWeapon.ActivateHitbox(true);
    }


    public void WeaponHitboxDeactivate()
    {
        EquippedWeapon.ActivateHitbox(false);
    }



}
