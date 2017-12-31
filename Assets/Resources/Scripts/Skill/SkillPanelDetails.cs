using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelDetails : MonoBehaviour
{

    Skill currentSkill;
    Button selectedSkillButton, skillRankUp, skillHotkey;
    Text skillNameText, skillDescriptionText, skillEffDescText, skillRankText;

    public GameObject hotSkillPanel;
    public GameObject hotkeyAssign;
    public Text hotkeyDesc;

    void Awake()
    {
        skillRankText = transform.FindChild("SkillRank").GetComponent<Text>();
        skillNameText = transform.FindChild("SkillName").GetComponent<Text>();
        skillDescriptionText = transform.FindChild("SkillDesc").GetComponent<Text>();
        skillEffDescText = transform.FindChild("SkillEffDesc").GetComponent<Text>();
        skillRankUp = transform.FindChild("Rank Up").GetComponent<Button>();
        skillHotkey = transform.FindChild("Hotkey").GetComponent<Button>();
        hotkeyAssign.SetActive(false);
        gameObject.SetActive(false);
        PlayerSkillUpdate.OnSkillChanged += () => SetSkill(currentSkill);
    }


    public void SetSkill(Skill skill)
    {
        gameObject.SetActive(true);
        skillNameText.text = skill.skillName;
        skillRankText.text = string.Format("Rank: {0} / {1}", skill.skillRank, skill.skillMaxRank);
        if (skill.skillType == Skill.SkillType.Active || skill.skillType == Skill.SkillType.Passive || skill.skillType == Skill.SkillType.Utility)
        {
            if (skill.skillStyle != Skill.SkillStyle.None)
            {
                skillDescriptionText.text = string.Format("({0}, {1})", skill.skillType, skill.skillStyle);
            }
            else
            {
                skillDescriptionText.text = string.Format("({0})", skill.skillType);
            }
        }
        else if (skill.skillType == Skill.SkillType.Magical || skill.skillType == Skill.SkillType.Physical)
        {
            if (skill.skillElement != Skill.SkillElement.None)
                skillDescriptionText.text = string.Format("({0}, {1})", skill.skillType, skill.skillElement);
            else
                skillDescriptionText.text = string.Format("({0})", skill.skillType);
        }
        skillEffDescText.text = string.Format("{0}\n\n{1}", skill.skillDesc, skill.skillEffDesc);
        currentSkill = skill;
    }

    public void RankUpButton()
    {
        if (currentSkill.skillRank == currentSkill.skillMaxRank)
        {
            SoundDatabase.PlaySound(33);
            EventNotifier.Instance.MakeEventNotifier("Skill already at max rank!");
        }
        else if (PlayerSkillController.Instance.RankUpSkill(currentSkill))
        {
            EventNotifier.Instance.MakeEventNotifier(string.Format("{0} rank + 1 ({1}/{2})", currentSkill.skillName, currentSkill.skillRank, currentSkill.skillMaxRank));
            SoundDatabase.PlaySound(20);
            PlayerSkillUpdate.SkillChanged();
        }
    }

    public void HotkeyButton()
    {
        if (currentSkill.skillRank != 0)
        {
            SoundDatabase.PlaySound(18);
            hotkeyAssign.SetActive(!hotkeyAssign.activeInHierarchy);
            hotkeyDesc.text = "Where to assign " + currentSkill.skillName + " to?";
        }
        else
        {
            EventNotifier.Instance.MakeEventNotifier("Skill not yet learned!");
        }
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
