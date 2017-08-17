﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelContainer : MonoBehaviour {

    public Skill skill;
    public Text skillText;
    public Image skillImage;


    public void SetSkill(Skill skill)
    {
        this.skill = skill;
        SetupSkillValues();
    }

    void SetupSkillValues()
    {
        skillText.text = skill.skillName;
        skillImage.sprite = Resources.Load<Sprite>("Icons/Skills/" + skill.skillName);
        skillImage.SetNativeSize();
    }

    public void OnSelectSkillButton()
    {
        PlayerSkillController.Instance.SetSkillDetails(skill);
    }
}
