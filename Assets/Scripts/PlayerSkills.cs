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
                        skill.skillBurnChance = (int)(15 + 3 * skill.skillRank + StatUtilities.FindStatTotal(stats, 9) / (25 + StatUtilities.FindStatTotal(stats, 9) / 4));
                        skill.skillEffDesc = "Chance to inflict Burn: " + skill.skillBurnChance.ToString() + "%";
                        break;
                    }

            }
        }
    }



}
