using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHolder : MonoBehaviour {

    public Skill skill = new Skill();
    bool isMouseHover;
    static bool showingQuickSkillNotifier;
    static bool showingSkillPageNotifier;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    void ButtonClick()
    {
        if (!GameManager.inBattle)
        {
            if (SkillPage.quickSkillsPressed) // making quick skill list
            {
                if (skill.skillType != Skill.SkillType.Passive)
                {
                    // check if it clicks small buttons
                    if (gameObject.transform.parent.name != "Quick Skills")
                    {
                        bool exists = false;
                        foreach (Transform quickSkill in QuickSkills.quickSkillGameObject)
                        {
                            if (quickSkill.GetComponent<SkillHolder>().skill == skill)
                            {
                                exists = true;
                            }
                        }
                        if (!exists)
                        {
                            if (QuickSkills.quickSkillGameObject.childCount == 8)
                            {
                                StartCoroutine(showTextForTime("Max of 8 Selected!", 1));
                                SoundDatabase.PlaySound(33);
                            }
                            else
                            {
                                QuickSkills.AddQuickSkill(skill);
                                SoundDatabase.PlaySound(20);
                            }
                        }
                        else
                        {
                            SoundDatabase.PlaySound(33);
                            StartCoroutine(showTextForTime("Already selected!", 1));
                        }
                    }
                    else
                    {
                        // destroy small button
                        Destroy(gameObject);
                        SoundDatabase.PlaySound(0);
                    }
                }
                else
                {
                    SoundDatabase.PlaySound(33);
                    StartCoroutine(showTextForTime("Cannot select Passive!", 1));
                }
            }
            else
            {
                if (gameObject.transform.parent.name == "Quick Skills")
                {
                    SoundDatabase.PlaySound(33);
                }
                else
                {
                    // rank up
                    if (PlayerStats.stats.skillPoints > 0)
                    {
                        // update skills to check requirement
                        PlayerSkills.SkillUpdate();
                        if (skill.skillRequire)
                        {
                            // learn new skill
                            if (skill.skillRank == 0)
                            {
                                // put in learned skill
                                for (int k = 0; k < PlayerSkills.learnedSkills.Count; k += 1)
                                {
                                    for (int i = 0; i < PlayerSkills.learnedSkills[k].Count; i += 1)
                                    {
                                        if (PlayerSkills.learnedSkills[k][i].skillID == -1)
                                        {
                                            PlayerSkills.learnedSkills[k][i] = skill;
                                            k = 5;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!(skill.skillRank == skill.skillMaxRank))
                            {
                                SoundDatabase.PlaySound(20);
                                skill.skillRank += 1;
                                PlayerStats.stats.skillPoints -= 1;
                                SkillPage.UpdateSkillPoints();
                                PlayerSkills.SkillUpdate();
                                //playerStats.StatsUpdate();
                                //PlayerSkills.SkillUpdate();
                                MouseEnter();// reset desc
                                             // if passive give stats
                            }
                            else
                            {
                                SoundDatabase.PlaySound(33);
                                StartCoroutine(showTextForTime("Skill at max rank!", 1));
                            }
                            // else requirements not met
                        }
                        else
                        {
                            SoundDatabase.PlaySound(33);
                            StartCoroutine(showTextForTime("Requirements not met!", 1));
                        }
                    }
                    else
                    {
                        SoundDatabase.PlaySound(33);
                        StartCoroutine(showTextForTime("Not enough SP!", 1));
                    }
                }
            }
        }
        else // in battle
        {
            if (gameObject.transform.parent.name == "Quick Skills")
            {
                if (skill.skillType != Skill.SkillType.Passive)
                {
                    if (skill.skillRank == 0)
                    {
                        SoundDatabase.PlaySound(33);
                        StartCoroutine(showTextForTime(BattleUI.quickSkillNotifier, "Skill not learned!", 1));
                    }
                    else if (PlayerStats.stats.mana - skill.skillManaCost < 0)
                    {
                        SoundDatabase.PlaySound(33);
                        StartCoroutine(showTextForTime(BattleUI.quickSkillNotifier, "Not enough MP!", 1));
                    }
                    else
                    {
                        StartCoroutine(DamageCalc.StartBattle(PlayerStats.stats, EnemyHolder.enemy.stats, skill));
                    }
                }
                else
                {
                    SoundDatabase.PlaySound(33);
                    StartCoroutine(showTextForTime(BattleUI.quickSkillNotifier, "Cannot use Passive!", 1));
                }
            }
            else
            {
                if (skill.skillType != Skill.SkillType.Passive)
                {
                    if (skill.skillRank == 0)
                    {
                        SoundDatabase.PlaySound(33);
                        StartCoroutine(showTextForTime("Skill not learned!", 1));
                    }
                    else if (PlayerStats.stats.mana - skill.skillManaCost < 0)
                    {
                        SoundDatabase.PlaySound(33);
                        StartCoroutine(showTextForTime("Not enough MP!", 1));
                    }
                    else
                    {
                        StartCoroutine(DamageCalc.StartBattle(PlayerStats.stats, EnemyHolder.enemy.stats, skill));
                    }
                }
                else
                {
                    SoundDatabase.PlaySound(33);
                    StartCoroutine(showTextForTime("Cannot use Passive!", 1));
                }
            }
        }
    }

    IEnumerator showTextForTime(string text, float time)
    {
        if (!showingSkillPageNotifier)
        {
            showingSkillPageNotifier = true;
            while (showingSkillPageNotifier)
            {
                GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = text;
                yield return new WaitForSeconds(time);
                GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = "";
                showingSkillPageNotifier = false;
            }
        }
    }

    IEnumerator showTextForTime(Text where, string text, float time)
    {
        if (!showingQuickSkillNotifier)
        {
            showingQuickSkillNotifier = true;
            while (showingQuickSkillNotifier)
            {
                where.text = text;
                yield return new WaitForSeconds(time);
                where.text = "";
                showingQuickSkillNotifier = false;
            }
        }
    }

    // mouseEnter usage is in inspector
    public void MouseEnter()
    {
        // hovering over quick skill in battle
        if (gameObject.transform.parent.name == "Quick Skills")
        {
            string text = skill.skillName + "\n";
            if (skill.skillType == Skill.SkillType.Physical)
            {
                text += skill.skillDamage + " Physical dmg\n";
            }
            else if(skill.skillType == Skill.SkillType.Magical)
            {
                text += skill.skillDamage + " Magical dmg\n";
            }
            text += skill.skillManaCost + " Mana Cost";
            BattleUI.quickSkillDesc.text = text;
        }
        else
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
    }

    public void MouseLeave()
    {
        if (!SkillPage.skillPage.gameObject.activeInHierarchy)
        {
            BattleUI.quickSkillDesc.text = "";
        }
        else
        {
            GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").FindChild("Notifier Text").GetComponent<Text>().text = "";
        }
    }

}
