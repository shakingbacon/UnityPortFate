using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour {

    public Skill skill;
    bool isMouseHover;


    void Update()
    {


    }

    public void MouseEnter()
    {
        Text desc = GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").GetComponentInChildren<Text>();
        //isMouseHover = true;
        if (gameObject.GetComponent<Button>().interactable)
        {
            GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(true);
            desc.text
                = "<size=50>" + skill.skillName + "</size>\n"
                + "<size=32>" + skill.skillDesc + "</size>\n";
            if (skill.skillRequire != null)
            {
                desc.text += "<size=30>Requirement(s): " + skill.skillRequire + "</size>\n";
            }
            desc.text += "<size=35>Rank: " + skill.skillRank + "/" + skill.skillMaxRank + " (" + skill.skillType.ToString() + ")" + "</size>\n\n";
            if (skill.skillType == Skill.SkillType.Magical || skill.skillType == Skill.SkillType.Physical)
            {
                desc.text += "<size=30>" + skill.skillType.ToString() + " Damage: " + skill.skillDamage + "</size>";
            }
            if (skill.skillType != Skill.SkillType.Passive)
            {
                desc.text += "\n<size=30>Mana Cost: " + skill.skillManaCost + "</size>\n\n";
            }
            desc.text += "<size=25>" + skill.skillEffDesc + "</size>\n";
        }
    }

    public void MouseLeave()
    {
        //isMouseHover = false;
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
    }
}
