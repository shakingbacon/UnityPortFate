using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelSkill : MonoBehaviour {
    public Skill skill = null;
    public Image skillImage;
    public Image cooldownCircle;
    public Text key;

    Sprite skillNullSprite;
    public float cooldownTotal;
    public float cooldownRemain;

    void Start()
    {
        skillNullSprite = Resources.Load<Sprite>("Icons/UI/CrossBlue");
        skillImage.sprite = skillNullSprite;
        key.text = gameObject.name;
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

    public void UpdateImage()
    {
        if (skill == null)
        {
            skillImage.sprite = skillNullSprite;
        }
        else
        {
            skillImage.sprite = Resources.Load<Sprite>("Icons/Skills/" + skill.skillName);
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
