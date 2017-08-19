using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelDetails : MonoBehaviour {

    Skill skill;
    Button selectedSkillButton, skillRankUp, skillHotkey;
    Text skillNameText, skillDescriptionText, skillEffDescText;

    public GameObject hotSkillPanel;
    public GameObject hotkeyAssign;
    public Text hotkeyDesc;

    void Awake()
    {
        skillNameText = transform.FindChild("SkillName").GetComponent<Text>();
        skillDescriptionText = transform.FindChild("SkillDesc").GetComponent<Text>();
        skillEffDescText = transform.FindChild("SkillEffDesc").GetComponent<Text>();
        skillRankUp = transform.FindChild("Rank Up").GetComponent<Button>();
        skillHotkey = transform.FindChild("Hotkey").GetComponent<Button>();
        hotkeyAssign.SetActive(false);
        gameObject.SetActive(false);
    }


    public void SetSkill(Skill skill)
    {
        gameObject.SetActive(true);
        skillDescriptionText.text = string.Format("({0})", skill.skillType);
        skillEffDescText.text = skill.skillEffDesc;
        this.skill = skill;
        skillNameText.text = skill.skillName;
    }

    public void RankUpButton()
    {
        SoundDatabase.PlaySound(20);
        skill.skillRank += 1;
    }

    public void HotkeyButton()
    {
        SoundDatabase.PlaySound(18);
        hotkeyAssign.SetActive(!hotkeyAssign.activeInHierarchy);
        hotkeyDesc.text = "Where to assign " + skill.skillName + " to?";
    }

    public void HotKeyDeletePress(Transform self)
    {
        SoundDatabase.PlaySound(21);
        int selfIndex = self.GetSiblingIndex();
        PanelSkill panelSkill = hotSkillPanel.transform.GetChild(selfIndex).GetComponent<PanelSkill>();
        panelSkill.skill = null;
        panelSkill.UpdateImage();
    }

    public void HotkeyAssignPress(Transform self)
    {
        SoundDatabase.PlaySound(32);
        int selfIndex = self.GetSiblingIndex();
        PanelSkill panelSkill = hotSkillPanel.transform.GetChild(selfIndex).GetComponent<PanelSkill>();
        panelSkill.skill = skill;
        panelSkill.UpdateImage();
        hotkeyAssign.SetActive(!hotkeyAssign.activeInHierarchy);
    }




}
