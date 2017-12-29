using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    Item currentlyEquippedItem;
    Weapon equippedWeapon;
    Player player;
    InventoryController inventoryController;
    public PlayerSkillController playerSkillController;

    void Start()
    {
        spawnProjectile = transform.FindChild("ProjectileSpawn");
        player = GetComponent<Player>();
        inventoryController = GetComponent<InventoryController>();
        UIEventHandler.OnSkillUse += UpdatePanelCooldowns;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) ActivateHotKeySkill(0);
        if (Input.GetKeyDown(KeyCode.W)) ActivateHotKeySkill(1);
        if (Input.GetKeyDown(KeyCode.E)) ActivateHotKeySkill(2);
        if (Input.GetKeyDown(KeyCode.R)) ActivateHotKeySkill(3);
        if (Input.GetKeyDown(KeyCode.A)) ActivateHotKeySkill(4);
        if (Input.GetKeyDown(KeyCode.S)) ActivateHotKeySkill(5);
        if (Input.GetKeyDown(KeyCode.D)) ActivateHotKeySkill(6);
        if (Input.GetKeyDown(KeyCode.F)) ActivateHotKeySkill(7);
        if (Input.GetKeyDown(KeyCode.X) && EquippedWeapon != null)
        {
            PerformWeaponAttack();
        }
    }

    public void ActivateHotKeySkill(int index)
    {
        PanelSkill panel = playerSkillController.skillPanel.transform.GetChild(index).GetComponent<PanelSkill>();
        if (EquippedWeapon != null && panel.skill != null && !EquippedWeapon.GetComponent<Animator>().GetBool("IsLastAnimation"))
        {
            if (!(panel.cooldownRemain > 0) && player.CurrentMana > panel.skill.skillMana)
            {
                playerSkillController.UsingSkill = panel.skill;
                UIEventHandler.SkillUsed();
                if (panel.skill.skillType == Skill.SkillType.Active)
                {
                    PerformChannel(panel.skill);
                }
                else
                {
                    PerformSkill();
                }
            }
        }
    }

    public void UpdatePanelCooldowns()
    {
        foreach (Transform skill in playerSkillController.skillPanel.transform)
        {
            if (skill.GetComponent<PanelSkill>().skill != null)
            {
                if (skill.GetComponent<PanelSkill>().skill.skillID == playerSkillController.UsingSkill.skillID)
                {
                    skill.GetComponent<PanelSkill>().SkillUsed();
                }
            }
        }
    }


    public void EquipWeapon(Item itemToEquip)
    {
        UnequipWeapon(itemToEquip);
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Prefabs/Items/Weapons/" + itemToEquip.Name), playerHand.transform);
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
        {
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        itemToEquip.Stats.AddStatsToOther(player.Stats);
        equippedWeapon = EquippedWeapon.GetComponent<Weapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        //EquippedWeapon.transform.localScale = new Vector3(1, 1, 1);
        equippedWeapon.playerSkillController = playerSkillController;
        equippedWeapon.player = player.Stats;

        SoundDatabase.PlaySound(0);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon(Item item)
    {
        if (EquippedWeapon != null)
        {
            SoundDatabase.PlaySound(0);
            player.Stats.RemoveStatsFromOther(equippedWeapon.Stats);
            inventoryController.GiveItem(currentlyEquippedItem.Name);
            Destroy(playerHand.transform.GetChild(0).gameObject);
            UIEventHandler.ItemUnequipped(item);
            UIEventHandler.StatsChanged();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }
    
    public void PerformChannel(Skill skill)
    {
        equippedWeapon.PerformChannelAnimation(skill);
    }

    public void PerformSkill()
    {
        equippedWeapon.PerformSkillAnimation();
    }
}
