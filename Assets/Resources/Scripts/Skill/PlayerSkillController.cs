using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillController : MonoBehaviour {

    public static PlayerSkillController Instance { get; set; }
    Player player;
    public GameObject skillPanel;
    public Transform projectileSpawn;
    public Skill UsingSkill { get; set; }

    public ConsumableController consumableController;
    public PlayerWeaponController playerWeaponController;
    public PlayerArmorController playerArmorController;
    // assigned in inspector
    public SkillPanelDetails skillDetailsPanel;


    void Start()
    {
        player = GetComponent<Player>();
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        consumableController = GetComponent<ConsumableController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
        playerArmorController = GetComponent<PlayerArmorController>();
        LearnSkill(SkillDatabase.Instance.GetSkill("Fireball"));
        LearnSkill(SkillDatabase.Instance.GetSkill(1));
    }


    public void LearnSkill(Skill skill)
    {
        UIEventHandler.SkillLearned(skill);
        PlayerSkillUpdate.UpdateSkills();
    }

    public void SetSkillDetails(Skill skill)
    {
        skillDetailsPanel.SetSkill(skill);
    }


    public void ActivateSkill(Skill skill)
    {
        if (player.CurrentMana >= skill.skillMana)
        {
            player.AddMana(-skill.skillMana);
            switch (skill.skillType)
            {
                case Skill.SkillType.Active:
                    {
                        if (skill.skillChannelDuration > 0f)
                        {
                            PlayerActivesController.Instance.AddActive(skill);
                        }
                        break;
                    }
                case Skill.SkillType.Magical:
                    {
                        if (skill.skillStyle == Skill.SkillStyle.Projectile)
                        {
                            CastSkillProjectile(skill);
                        }
                        break;
                    }
            }
        }
        

    }
    public void CastSkillProjectile(Skill skill)
    {
        Projectile projectile = Instantiate(Resources.Load<Projectile>("Prefabs/Projectiles/" + skill.skillName));
        projectile.Damage = skill.skillDamage;
        projectile.Direction = projectileSpawn.right;
        projectile.transform.position = projectileSpawn.position;
        projectile.Damage.HitChance = player.Stats.Hit;
        if (projectileSpawn.parent.localScale.x == -1)
        {
            projectile.transform.Rotate(180, 180, 0);
        }
        projectile.transform.localScale = new Vector3(1, 1, 1);
    }

}
