using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    //public static PlayerAttackController Instance { get; set; }

    Weapon EquippedWeapon { get { return GetComponent<PlayerWeapon>().EquippedWeapon; } }

    private void Start()
    {
        //if (Instance != null && Instance != this) Destroy(gameObject);
        //else Instance = this;
    }


    private void Update()
    {
        if (EquippedWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                PerformBasicWeaponAttack();
            }
        }
    }

    void PerformBasicWeaponAttack()
    {
        EquippedWeapon.PerformAttack();
    }


    


}
