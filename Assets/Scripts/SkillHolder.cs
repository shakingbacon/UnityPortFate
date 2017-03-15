using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour {

    public Skill skill;
    bool isMouseHover;
    GameManager manager;
    PlayerStats playerStats;
    EnemyStats enemyStats;
    PlayerSkills playerSkills;


    void Start()
    {
        enemyStats = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
        playerSkills = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>();
        playerStats = GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>();
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        if (!manager.inBattle)
        {
            // rank up
            if (StatUtilities.FindStatTotal(playerStats.stats, 18) > 0)
            {   
                // update skills to check requirement
                playerSkills.SkillUpdate();
                if (skill.skillRequire)
                {
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
                        playerSkills.SkillUpdate();
                        playerStats.StatsUpdate();
                        playerSkills.SkillUpdate();
                        MouseEnter();// reset desc
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
                    StartCoroutine(showTextForTime("Requirements not met!", 1));
                }
            }
            else
            {
                StartCoroutine(showTextForTime("Not enough SP!", 1));
            }
        }
        else // in battle
        {
            DamageCalc.SkillAttack(playerStats.stats, enemyStats.enemy.stats, skill);
            GameManager.OpenCloseSkillPage();
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

            desc.text += "<size=35>Rank: " + skill.skillRank + "/" + skill.skillMaxRank + " (" + skill.skillType.ToString() + ")" + "</size>\n";
            if (skill.skillRequireDesc != null && skill.skillRank != skill.skillMaxRank)
            {
                desc.text += "<size=13>Req: (" + skill.skillRequireDesc + ")</size>\n";
            }
            else
            {
                desc.text += "\n";
            }
            if (skill.skillType == Skill.SkillType.Magical || skill.skillType == Skill.SkillType.Physical)
            {
                desc.text += "<size=30>" + skill.skillType.ToString() + " Damage: " + skill.skillDamage + "</size>";
            }
            if (skill.skillType != Skill.SkillType.Passive)
            {
                desc.text += "\n<size=30>Mana Cost: " + skill.skillManaCost + "</size>\n\n";
            }
            else
            {
                desc.text += "\n\n\n";
            }
            desc.text += "<size=22>" + skill.skillEffDesc + "</size>\n";
        }
    }

    public void MouseLeave()
    {
        //isMouseHover = false;
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = "";
    }

}
