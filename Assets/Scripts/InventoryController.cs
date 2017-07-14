using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    public static InventoryController Instance { get; set; }
    public ConsumableController consumableController;
    public PlayerWeaponController playerWeaponController;

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        consumableController = GetComponent<ConsumableController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerWeaponController.EquipWeapon(new NewItem(new List<BaseStat>(), "staff"));
        }
    }
	
}
