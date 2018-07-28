using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public Transform RightHand;

    public static PlayerWeaponController Instance { get; set; }

    public Weapon EquippedWeapon => RightHand.GetComponentInChildren<Weapon>();

    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    // 0 is false, other is true
    public void WeaponHitboxActivate()
    {
        //EquippedWeapon.ActivateHitbox(true);
    }


    public void WeaponHitboxDeactivate()
    {
        //EquippedWeapon.ActivateHitbox(false);
    }
}