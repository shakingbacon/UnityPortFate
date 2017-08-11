using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    NewItem currentlyEquippedItem;
    IWeapon equippedWeapon;
    CharacterStats characterStats;
    InventoryController inventoryController;

    void Start()
    {
        spawnProjectile = transform.FindChild("ProjectileSpawn");
        characterStats = GetComponent<Player>().characterStats;
        inventoryController = GetComponent<InventoryController>();
    }

    public void EquipWeapon(NewItem itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            UnequipWeapon();
        }
        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Items/Weapons/" + itemToEquip.ItemName), playerHand.transform);
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        characterStats.AddStatBonus(itemToEquip.Stats);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon()
    {
        characterStats.RemoveStatBonus(equippedWeapon.Stats);
        inventoryController.GiveItem(currentlyEquippedItem.ItemName);
        Destroy(playerHand.transform.GetChild(0).gameObject);
        UIEventHandler.StatsChanged();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }

    private int CalculateDamage()
    {
        int damageToDeal = 0;
        damageToDeal = ((characterStats.GetStat(BaseStat.BaseStatType.Physical).GetCalcStatValue() * 2) +
            Random.Range(2,8));
        damageToDeal += CalculateCrit(damageToDeal);
        return damageToDeal;
    }

    private int CalculateCrit(int damage)
    {
        if (Random.value <= .1f)
        {
            int critDamage = (int)(damage * Random.Range(.5f, .75f));
            return critDamage;
        }
        return 0;
    }
}
