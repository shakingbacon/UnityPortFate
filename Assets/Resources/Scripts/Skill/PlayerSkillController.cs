using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillController : MonoBehaviour
{

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

    public List<PlayerSkill> Skills = new List<PlayerSkill>();

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
        //UIEventHandler.OnSkillLearn += Skills.Add;

    }

    void Update()
    {
        foreach (PlayerSkill skill in Skills)
        {
            if (skill.cooldownRemain > 0)
            {
                skill.cooldownRemain -= Time.deltaTime;
            }
        }  
    }


    public Skill GetSkill(int id)
    {
        foreach (Skill skill in Skills)
        {
            if (skill.skillID == id)
                return skill;
        }
        Debug.LogError("DIDNT FIND SKILL");
        return new Skill();
    }

    public void LearnSkill(Skill skill)
    {
        PlayerSkill newSkill = new PlayerSkill(skill);
        Skills.Add(newSkill);
        UIEventHandler.SkillLearned(newSkill);
        PlayerSkillUpdate.UpdateSkills();
    }

    public void LearnSkill(int id)
    {
        PlayerSkill newSkill = new PlayerSkill(SkillDatabase.Instance.GetSkill(id));
        Skills.Add(newSkill);
        UIEventHandler.SkillLearned(newSkill);
        PlayerSkillUpdate.UpdateSkills();
    }

    public bool RankUpSkill(Skill skill)
    {
        if (player.SkillPoints > 0)
        {
            player.SkillPoints -= 1;
            skill.skillRank += 1;
            SkillPassiveEffects.ApplyRankUpBonus(skill.skillID);
            return true;
        }
        else
        {
            SoundDatabase.PlaySound(33);
            EventNotifier.Instance.MakeEventNotifier("Not enough skill points!");
            return false;
        }
    }

    public void SetSkillDetails(PlayerSkill skill)
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
            switch (usingSkill.skillType)
            {
                case Skill.SkillType.Active:
                    {
                        PlayerActivesController.Instance.AddActive(usingSkill);
                        break;
                    }
                case Skill.SkillType.Utility:
                    {
                        SkillPassiveEffects.ApplySkillEffect(skill.skillID);
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
        projectile.Damage.HitChance = player.Stats.Hit;

        projectile.Direction = projectileSpawn.right;
        projectile.transform.position = projectileSpawn.position;
        if (projectileSpawn.parent.localScale.x == -1)
        {
            projectile.transform.Rotate(180, 180, 0);
        }
        projectile.transform.localScale = new Vector3(1, 1, 1);
    }

}
