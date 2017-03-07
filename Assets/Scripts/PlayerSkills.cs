using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {
    List<Stat> stats;
    SkillDatabase skillDatabase;
    public List<List<Skill>> skills = new List<List<Skill>>();
    public List<List<Skill>> learnedSkills = new List<List<Skill>>();

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>().stats;
        skillDatabase = GameObject.FindGameObjectWithTag("Skill Database").GetComponent<SkillDatabase>();


        // learned skills page has 3 pages should be good
        AddPage(learnedSkills, 3);
        AddSkillSlots(learnedSkills, 40);
        // Basically a copy of the database list but all skills are new not referenced
        switch (GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>().job.jobID)
        {
            case 0:
                {
                    AddPage(skills, skillDatabase.mageSkills.Count);
                    for (int i = 0; i < skillDatabase.mageSkills.Count; i += 1)
                    {
                        for (int k = 0; k < skillDatabase.mageSkills[i].Count; k += 1)
                            skills[i].Add((new Skill(skillDatabase.mageSkills[i][k])));
                    }
                    break;
                }
        }

        FindSkill(0).skillRank += 1; // Basic attack rank always 1
        FindSkill(24).skillRank += 1; // Basic attack rank always 1
        learnedSkills[0][0] = FindSkill(0);
        learnedSkills[0][1] = FindSkill(24);
        SkillUpdate();
    }

    private void AddSkillSlots(List<List<Skill>> page, int skillnum)
    {
        for (int j = 0; j < page.Count; j += 1)
        {
            while (page[j].Count < skillnum)// 40 skills in a page
            {
                page[j].Add(new Skill());
            }
        }
    }

    private void AddPage(List<List<Skill>> page, int pages)
    {
        for (int i = 0; i < pages; i += 1)
        {
            page.Add(new List<Skill>());
        }
    }

    public Skill FindSkill(int id)
    {
        Skill skill = new Skill();
        for (int k = 0; k < skills.Count; k += 1)
            for (int i = 0; i < skills[k].Count; i += 1)
            {
                if (skills[k][i].skillID == id)
                {
                    skill = skills[k][i];
                }
            }
        return skill;
    }

    public void SkillUpdate()
    {
        for (int k = 0; k < skills.Count; k += 1)
        for (int i = 0; i < skills[k].Count; i += 1)
        {
            Skill skill = skills[k][i];
            switch (skill.skillID)
            {

                    case 0:
                        {
                            skill.skillDamage = StatUtilities.FindStatTotal(stats, 8);
                            break;
                        }
                    case 1:
                        {
                            skill.skillDamage = (int)(80 + (StatUtilities.FindStatTotal(stats, 9) / 1.8) * (1.8 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(50 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 35);
                            skill.skillStatusEff.burnChance = (int)(15 + 3 * skill.skillRank + StatUtilities.FindStatTotal(stats, 9) / (25 + StatUtilities.FindStatTotal(stats, 9) / 4));
                            skill.skillEffDesc = "Chance to inflict Burn: " + skill.skillStatusEff.burnChance.ToString() + "%";
                            int req = skill.skillRank * 3;
                            skill.skillRequire = StatUtilities.FindStatTotal(stats, 16) >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                   case 2:
                        {
                            skill.skillDamage = (int)(95 + (StatUtilities.FindStatTotal(stats, 9) / 1.7) * (1.85 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(45 + skill.skillDamage / (20 - skill.skillRank) + skill.skillRank * 25);
                            skill.skillHitChance = (int)(20 + 4.5 * skill.skillRank);
                            skill.skillEffDesc = "Hit Chance: +" + skill.skillHitChance+"%";
                            break;
                        }
                    case 3:
                        {
                            skill.skillDamage = (int)(95 + (StatUtilities.FindStatTotal(stats, 9) / 1.7) * (1.85 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(45 + skill.skillDamage / (20 - skill.skillRank) + skill.skillRank * 25);
                            skill.skillCritChance = (int)(26 + 4 * skill.skillRank);
                            skill.skillHitChance = (int)(-20 + 4.5 * skill.skillRank);
                            skill.skillCritMulti = (int)(10 + 5 * skill.skillRank);
                            skill.skillEffDesc = "Crit Chance: +" + skill.skillCritChance + "%, " +
                                "Crit Multi: +" + skill.skillCritMulti + "%\n" + "Hit Chance: " + skill.skillHitChance + "%";
                            break;
                        }
                    case 4:
                        {
                            skill.skillDamage = (int)(115 + (StatUtilities.FindStatTotal(stats, 9) / 1.7) * (1.9 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(60 + skill.skillDamage / (14 - skill.skillRank) + skill.skillRank * 55);
                            skill.skillStatusEff.paraChance = (int)(20 + 3 * skill.skillRank + StatUtilities.FindStatTotal(stats, 9)/(25 + StatUtilities.FindStatTotal(stats, 9)/4));
                            skill.skillCritChance = (int)(14 + 4 * skill.skillRank);
                            skill.skillEffDesc = "Chance to Paralyze: +" + skill.skillStatusEff.paraChance + "%\nCrit Chance: +" + skill.skillCritChance + "%";
                            break;
                        }
                    case 5:
                        {
                            skill.skillManaCost = (int)(75 * skill.skillRank + (StatUtilities.FindStatTotal(stats, 6) * 0.195) / (skill.skillRank + 1));
                            skill.skillCooldown = 6;
                            skill.skillTurnEnd = 6;
                            skill.skillEffDesc = string.Format("For {0} turns, when recieving damage from an enemy, your Current Mana takes damage instead of your HP. When no MP is available, damage is applied normally.",
                                skill.skillTurnEnd) + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            break;
                        }
                    case 6:
                        {
                            skill.skillDamage = (int)(200 + skill.skillRank * 75.5 + StatUtilities.FindStatTotal(stats, 5) / (8 - skill.skillRank) + StatUtilities.FindStatTotal(stats, 9) * 0.75 / StatUtilities.FindStatTotal(stats, 5));
                            skill.skillManaCost = (int)(60 + StatUtilities.FindStatTotal(stats, 9) * 0.6 * (1 - skill.skillRank / 20));
                            skill.skillCooldown = 3;
                            skill.skillEffDesc = string.Format("Restore HP: +{0}\nCooldown: {1} Turns", skill.skillDamage, skill.skillCooldown);
                            break;
                        }
                    case 15:
                        {
                            skill.skillDamage = (int)(25 + skill.skillRank * 90 + StatUtilities.FindStatTotal(stats, 9)*0.666 / (8 - skill.skillRank));
                            skill.skillManaCost = (int)(150 + skill.skillRank * 60 + StatUtilities.FindStatTotal(stats, 9) * 1.3 * (1 + skill.skillRank));
                            skill.skillHitChance = (int)(22 + skill.skillRank * 6 + StatUtilities.FindStatTotal(stats, 9) * 0.1 / (1 + skill.skillRank));
                            skill.skillCritChance = 75 + 50 * skill.skillRank; // armor/res bonus
                            skill.skillStatusEff.burnChance = (int)(17 + skill.skillRank * 10 + StatUtilities.FindStatTotal(stats, 9) * 0.1 / (1 + skill.skillRank));
                            
                            skill.skillCooldown = 5;
                            skill.skillTurnEnd = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, gain Armor/Resist: +{1}.", skill.skillTurnEnd, skill.skillCritChance) + 
                               string.Format("While this skill is active, there's a {0}% chance where the shield explodes, dealing {1} Phyical Damage with Burn chance: {2}%", skill.skillHitChance, skill.skillDamage, skill.skillStatusEff.burnChance)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            skill.skillRequire = FindSkill(1).skillRank >= req;
                            skill.skillRequireDesc = string.Format("Inferno - Rank: {0}", req);
                            break;
                        }



            }
        }
    }



}
