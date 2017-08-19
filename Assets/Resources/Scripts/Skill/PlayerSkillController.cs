using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillController : MonoBehaviour {

    public static PlayerSkillController Instance { get; set; }
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
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        consumableController = GetComponent<ConsumableController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
        playerArmorController = GetComponent<PlayerArmorController>();
        LearnSkill(SkillDatabase.Instance.GetSkill("Fireball"));
    }


    public void LearnSkill(Skill skill)
    {
        UIEventHandler.SkillLearned(skill);
    }

    public void SetSkillDetails(Skill skill)
    {
        skillDetailsPanel.SetSkill(skill);
    }


    public void ActivateSkill(Skill skill)
    {
        CastSkillProjectile(skill);
    }

    public void CastSkillProjectile(Skill skill)
    {
        Projectile projectile = Instantiate(Resources.Load<Projectile>("Prefabs/Projectiles/" + skill.skillName));
        projectile.Direction = projectileSpawn.right;
        projectile.transform.position = projectileSpawn.position;
        if (projectileSpawn.parent.localScale.x == -1)
        {
            projectile.transform.Rotate(180, 180, 0);
        }
        projectile.transform.localScale = new Vector3(1, 1, 1);
    }

}
