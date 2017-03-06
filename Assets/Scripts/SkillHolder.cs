using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour {

    public Skill skill;
    bool isMouseHover;
    GameManager manager;
    PlayerStats playerStats;
    PlayerSkills playerSkills;


    void Start()
    {
        playerSkills = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>();
        playerStats = GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        if (!manager.inBattle)
        {
            if (StatUtilities.FindStatTotal(playerStats.stats, 18) > 0)
            {
                // if skill require
                // learn new skill
                if (skill.skillRank == 0)
                {
                    // put in learned skill
                    for (int k = 0; k < playerSkills.learnedSkills.Count; k += 1)
                    {
                        for (int i = 0; i < playerSkills.learnedSkills[k].Count; i += 1)
                        {
                            if (playerSkills.learnedSkills[k][i].skillID == -1)
                            {
                                playerSkills.learnedSkills[k][i] = skill;
                                k = 5;
                                break;
                            }
                        }
                    }
                }
                if (!(skill.skillRank == skill.skillMaxRank))
                {

                    skill.skillRank += 1;
                    StatUtilities.IncreaseStat(playerStats.stats, 18, -1);
                    MouseEnter();// reset desc
                    playerStats.StatsUpdate();
                    // if passive give stats
                }
                else
                {
                    StartCoroutine(showTextForTime("Skill at max rank!", 1));
                }
                // else requirements not met
            }
            else
            {
                StartCoroutine(showTextForTime("Not enough SP!", 1));
            }
        }
    }

    IEnumerator showTextForTime(string text, float time)
    {
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = text;
        yield return new WaitForSeconds(time);
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = "";
    }

    // mouseEnter usage is in inspector
    public void MouseEnter()
    {
        Text desc = GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").GetComponentInChildren<Text>();
        //isMouseHover = true;
        if (gameObject.GetComponent<Button>().interactable)
        {
            if (gameObject.tag == "Holder Right")
            {
                GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").GetComponent<RectTransform>().localPosition = new Vector3(-200, 0);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").GetComponent<RectTransform>().localPosition = new Vector3(200, 0);
            }
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
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = "";
    }

}
