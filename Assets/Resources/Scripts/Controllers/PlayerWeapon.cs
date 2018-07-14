using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public static PlayerWeapon Instance { get; set; }
    public Weapon EquippedWeapon { get; set; }

    Transform playerHand;

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
        playerHand = transform.Find("Hand");
        //PlayerEquipController.Instance.OnEquipItem += WieldWeapon;
        //PlayerEquipController.Instance.OnUnequipItem += UnwieldWeapon;
    }

    public void WieldWeapon(Item weapon)
    {
        EquippedWeapon = Instantiate(Resources.Load<Weapon>("Prefabs/Items/" + weapon.Name), playerHand);
    }

    public void UnwieldWeapon()
    {
       Destroy(EquippedWeapon.gameObject);
    }
}
