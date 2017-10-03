using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelDetails : MonoBehaviour {

    Skill currentSkill;
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
        skillNameText.text = skill.skillName;
        skillDescriptionText.text = string.Format("({0}, {1})", skill.skillType, skill.skillElement);
        skillEffDescText.text = string.Format("{0}\n\n{1}",skill.skillDesc, skill.skillEffDesc);
        currentSkill = skill;
    }

    public void RankUpButton()
    {
        SoundDatabase.PlaySound(20);
        currentSkill.skillRank += 1;
    }

    public void HotkeyButton()
    {
        SoundDatabase.PlaySound(18);
        hotkeyAssign.SetActive(!hotkeyAssign.activeInHierarchy);
        hotkeyDesc.text = "Where to assign " + currentSkill.skillName + " to?";
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
        panelSkill.skill = currentSkill;
        panelSkill.UpdateImage();
        hotkeyAssign.SetActive(!hotkeyAssign.activeInHierarchy);
    }




}
