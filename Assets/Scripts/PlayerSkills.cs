using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {
    List<Stat> stats;
    SkillDatabase skillDatabase;
    public List<Skill> skills = new List<Skill>();

    void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>().stats;
        skillDatabase = GameObject.FindGameObjectWithTag("Skill Database").GetComponent<SkillDatabase>();
        skills.Add((skillDatabase.FindSkill(0)));
        SkillUpdate();
    }

    public Skill FindSkill(int id)
    {
        Skill skill = skills[0];
        for (int i = 0; i < skills.Count; i += 1)
        {
            if (skills[i].skillID == id)
            {
                skill = skills[i];
            }
        }
        return skill;
    }


    void SkillUpdate()
    {
        for (int i = 0; i < skills.Count; i += 1)
        {
            switch (skills[i].skillID)
            {
                case 0:
                    {
                        skills[i].skillDamage = StatUtilities.FindStatTotal(stats, 8);
                        break;
                    }
            }
        }
    }
}
