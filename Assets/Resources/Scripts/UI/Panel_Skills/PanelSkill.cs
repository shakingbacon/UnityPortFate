using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelSkill : MonoBehaviour {
    public Skill skill = new Skill();
    public Image skillImage;
    public Image cooldownCircle;

    private float cooldownTotal;
    public float cooldownRemain;
    //public float timer;

    void Start()
    {
        skill = SkillDatabase.Instance.GetSkill("Fireball");
    }

    void Update()
    {
        if (cooldownRemain > 0)
        {
            UpdateCooldownCirlce();
        }
        else if (cooldownRemain <= 0)
        {
            cooldownCircle.fillAmount = 0;
        }
    }


    public void SkillUsed()
    {
        cooldownTotal = skill.skillCooldown;
        cooldownRemain = skill.skillCooldown;
    }

    void UpdateCooldownCirlce()
    {
        cooldownCircle.fillAmount = cooldownRemain / cooldownTotal;
        cooldownRemain -= Time.deltaTime;
    }

}
