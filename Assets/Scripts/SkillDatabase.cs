using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : MonoBehaviour {
    public List<Skill> skills = new List<Skill>();
    public List<Skill> mageSkills = new List<Skill>();
    // Mage skills #1-100, Rouge skills #101-200, Warrior skills #201-300
    void Start()
    {
        skills.Add(new Skill("Basic Attack", 0, "Attack with your weapon", null, 0, Skill.SkillType.Physical));
        skills.Add(new Skill("Inferno", 1, "Fire burns, set ablaze", null, 0, Skill.SkillType.Magical));
        // Mage Skills
        for (int i = 0; i < 40; i += 1)
        {
            mageSkills.Add(new Skill());
        }
        mageSkills[0] = FindSkill(1);
    }

    public Skill FindSkill(int id)
    {
        Skill stat = skills[0];
        for (int i = 0; i < skills.Count; i += 1)
        {
            if (skills[i].skillID == id)
            {
                stat = skills[i];
            }
        }
        return stat;
    }

}
