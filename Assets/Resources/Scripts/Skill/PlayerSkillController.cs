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

    public GameObject hotkeyButton;

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
        LearnSkill(2);
        LearnSkill(3);
    }

    public Skill GetSkill(int id)
    {
        foreach (Transform skillChild in SkillUI.Instance.learnedSkills)
        {
            Skill skill = skillChild.GetComponent<SkillPanelContainer>().skill;
            if (skill.skillID == id)
                return skill;
        }
        Debug.LogError("DIDNT FIND SKILL");
        return new Skill();
    }


    public void LearnSkill(Skill skill)
    {
        UIEventHandler.SkillLearned(skill);
        PlayerSkillUpdate.UpdateSkills();
    }

    public void LearnSkill(int id)
    {
        UIEventHandler.SkillLearned(SkillDatabase.Instance.GetSkill(id));
        PlayerSkillUpdate.UpdateSkills();
    }

    public void SetSkillDetails(Skill skill)
    {
        skillDetailsPanel.SetSkill(skill);
        if (skill.skillType == Skill.SkillType.Passive)
        {
            skillDetailsPanel.transform.FindChild("Hotkey").gameObject.SetActive(false);
        }
        else
            skillDetailsPanel.transform.FindChild("Hotkey").gameObject.SetActive(true);
    }


    public void ActivateSkill(Skill skill)
    {
        Skill usingSkill = SkillEvents.SkillUsed(new Skill(skill));

        if (player.CurrentMana >= usingSkill.skillMana)
        {
            player.AddMana(-usingSkill.skillMana);
            print("LOL");
            switch (usingSkill.skillType)
            {
                case Skill.SkillType.Active:
                    {
                        if (usingSkill.skillChannelDuration > 0f)
                        {
                            PlayerActivesController.Instance.AddActive(usingSkill);
                        }
                        break;
                    }
                case Skill.SkillType.Magical:
                    {
                        if (skill.skillStyle == Skill.SkillStyle.Projectile)
                        {
                            
                            CastSkillProjectile(usingSkill);
                        }
                        break;
                    }
            }
        }
    }
    public void CastSkillProjectile(Skill skill)
    {
        Projectile projectile = Instantiate(Resources.Load<Projectile>("Prefabs/Projectiles/" + skill.skillName));
        projectile.Damage = skill;
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
