using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillList {

    public List<List<Skill>> skills;

    public SkillList()
    {
        skills = new List<List<Skill>>();
    }

    public SkillList(List<List<Skill>> tocopyskills)
    {
        CopySkills(tocopyskills);
    }

    private void CopySkills(List<List<Skill>> tocopyskills)
    {
        skills = new List<List<Skill>>();
        AddPages(tocopyskills.Count);
        for (int i = 0; i < tocopyskills.Count; i += 1)
        {
            for (int k = 0; k < tocopyskills[i].Count; k += 1)
                skills[i].Add((new Skill(tocopyskills[i][k])));
        }
    }

    public void MakeNewBlankPage(int pages, int skillcount)
    {
        skills = new List<List<Skill>>();
        AddPages(pages);
        AddBlankSkills(skillcount);
    }

    private void AddBlankSkills(int skillcount)
    {
        for (int j = 0; j < skills.Count; j += 1)
        {
            while (skills[j].Count < skillcount)
            {
                skills[j].Add(new Skill());
            }
        }
    }

    private void AddPages(int pagecount)
    {
        for (int i = 0; i < pagecount; i += 1)
        {
            skills.Add(new List<Skill>());
        }
    }

    public void AddSkill(Skill skill)
    {
        for (int k = 0; k < skills.Count; k += 1)
            for (int i = 0; i < skills[k].Count; i += 1)
            {
                if (skills[k][i].skillID == -1)
                {
                    skills[k][i] = skill;
                    return;
                }
            }
    }

    public void RankSkill(Skill skill)
    {
        skill.skillRank += 1;
    }

    public void LearnSkill(Skill skill)
    {
        AddSkill(skill);
        RankSkill(skill);
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
}
