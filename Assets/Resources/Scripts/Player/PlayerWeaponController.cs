using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    Item currentlyEquippedItem;
    Weapon equippedWeapon;
    Player player;
    InventoryController inventoryController;
    public PlayerSkillController playerSkillController;


    bool InAction { get; set; }

    void Start()
    {
        spawnProjectile = transform.Find("ProjectileSpawn");
        player = GetComponent<Player>();
        inventoryController = GetComponent<InventoryController>();
        UIEventHandler.OnSkillUse += UpdatePanelCooldowns;
    }

    void Update()
    {
        if (equippedWeapon != null)
        {
            if (equippedWeapon.Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                if (Input.GetKeyDown(KeyCode.Q)) ActivateHotKeySkill(0);
                else if (Input.GetKeyDown(KeyCode.W)) ActivateHotKeySkill(1);
                else if (Input.GetKeyDown(KeyCode.E)) ActivateHotKeySkill(2);
                else if (Input.GetKeyDown(KeyCode.R)) ActivateHotKeySkill(3);
                else if (Input.GetKeyDown(KeyCode.A)) ActivateHotKeySkill(4);
                else if (Input.GetKeyDown(KeyCode.S)) ActivateHotKeySkill(5);
                else if (Input.GetKeyDown(KeyCode.D)) ActivateHotKeySkill(6);
                else if (Input.GetKeyDown(KeyCode.F)) ActivateHotKeySkill(7);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (player.GetComponent<PlayerMovement>().IsRunning)
                {
                    PerformDashAttack();
                }
                else
                {
                    PerformWeaponAttack();
                }
            }
        }

    }

    public void ActivateHotKeySkill(int index)
    {
        PanelSkill panel = playerSkillController.skillPanel.transform.GetChild(index).GetComponent<PanelSkill>();
        if (panel.playerSkill != null)
        {
            if (!(panel.playerSkill.cooldownRemain > 0))
                //!playerSkillController.SkillsThatAreOnCooldown.Exists(aSkill => aSkill.skill.skillID == panel.cooldownSkill.skill.skillID))
            {
                //playerSkillController.SkillsThatAreOnCooldown.Add(panel.cooldownSkill);
                if (player.CurrentMana > panel.playerSkill.skillMana)
                {
                    playerSkillController.UsingSkill = panel.playerSkill;
                    UIEventHandler.SkillUsed();
                    if (panel.playerSkill.skillType == Skill.SkillType.Active || panel.playerSkill.skillType == Skill.SkillType.Utility)
                    {
                        PerformChannel(panel.playerSkill);
                    }
                    else
                    {
                        PerformSkill();
                    }
                }
                else
                {
                    EventNotifier.Instance.MakeEventNotifier("Not enough Mana!");
                }
            }
            else
            {
                EventNotifier.Instance.MakeEventNotifier("Skill on cooldown!");
            }
        }
    }

    public void UpdatePanelCooldowns()
    {
        foreach (Transform skill in playerSkillController.skillPanel.transform)
        {
            if (skill.GetComponent<PanelSkill>().playerSkill != null)
            {
                if (skill.GetComponent<PanelSkill>().playerSkill.skillID == playerSkillController.UsingSkill.skillID)
                {
                    skill.GetComponent<PanelSkill>().SkillUsed();
                }
            }
        }
    }


    public void EquipWeapon(Item itemToEquip)
    {
        UnequipWeapon(itemToEquip);
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Prefabs/Items/" + itemToEquip.Name), playerHand.transform);
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
        equippedWeapon.SetAttackSpeed(player.Stats.AttackSpeed);
        SoundDatabase.PlaySound(0);
        UIEventHandler.ItemEquipped(itemToEquip);
        UIEventHandler.StatsChanged();
    }

    public void UnequipWeapon(Item item)
    {
        if (EquippedWeapon != null)
        {
            SoundDatabase.PlaySound(0);
            //print("unequipped");
            //print(equippedWeapon.Stats.Physical);
            equippedWeapon.Stats.RemoveStatsFromOther(player.Stats);
            inventoryController.GiveItem(currentlyEquippedItem.Name);
            Destroy(playerHand.transform.GetChild(0).gameObject);
            UIEventHandler.ItemUnequipped(item);
            UIEventHandler.StatsChanged();
        }
    }

    public void PerformWeaponAttack()
    {
        player.GetComponent<PlayerMovement>().timeRunning = 0f;
        equippedWeapon.PerformAttack();
    }

    public void PerformDashAttack()
    {
        player.GetComponent<PlayerMovement>().timeRunning = 0f;
        equippedWeapon.PerformDashAttack();
    }

    public void PerformChannel(Skill skill)
    {
        player.GetComponent<PlayerMovement>().timeRunning = 0f;
        equippedWeapon.PerformChannelAnimation(skill);
    }

    public void PerformSkill()
    {
        player.GetComponent<PlayerMovement>().timeRunning = 0f;
        equippedWeapon.PerformSkillAnimation();
    }
}
