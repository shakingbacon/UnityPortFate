using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : MonoBehaviour {
    public List<Skill> skills = new List<Skill>();
    public List<List<Skill>> mageSkills = new List<List<Skill>>();
    // Mage skills #1-100, Rouge skills #101-200, Warrior skills #201-300
    void Start()
    {
        skills.Add(new Skill());
        skills.Add(new Skill("Basic Attack", 0, "Attack with your weapon", 1, Skill.SkillType.Physical));
        skills.Add(new Skill("Inferno", 1, "Fire burns, set ablaze", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Tsunami", 2, "Wash away and drown", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Tornado", 3, "Things around you fly", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Thunderstorm", 4, "Call thunder", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Mana Gaurd", 5, "Mana gaurds your health", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Restore", 6, "Restore Health", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Meditate", 7, "Focus your mind", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Corpse Drain", 8, "Gain more when killing", 8, Skill.SkillType.Passive));
        skills.Add(new Skill("Max MP +", 9, "Expand your mind", 8, Skill.SkillType.Passive));
        skills.Add(new Skill("Magic Mastery", 10, "Train your skills", 8, Skill.SkillType.Passive));
        skills.Add(new Skill("Mana Armor", 11, "Mana is armor", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("As One", 12, "Become one with yourself", 1, Skill.SkillType.Passive));
        skills.Add(new Skill("Barrier", 13, "Create a barrier", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Elemental Affinty", 14, "Learn the elements", 5, Skill.SkillType.Passive));
        skills.Add(new Skill("Volcano Shield", 15, "Harden yourself with fire", 5, Skill.SkillType.Active));
        skills.Add(new Skill("Purity", 16, "Purify yourself", 5, Skill.SkillType.Active));
        skills.Add(new Skill("Cyclone Pressure", 17, "Pressure the enemy", 5, Skill.SkillType.Active));
        skills.Add(new Skill("Electric Charge", 18, "Charge your battery", 5, Skill.SkillType.Active));
        skills.Add(new Skill("Elemental Burst", 19, "Channel all elements", 7, Skill.SkillType.Magical));
        skills.Add(new Skill("风水", 20, "Understand surroundings", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Glass Cannon", 21, "All in", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Soaked Shock", 22, "Careful", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Plasma Fusion", 23, "Feel the power", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Magical Attack", 24, "Basic magical attack", 1, Skill.SkillType.Magical));
        skills.Add(new Skill("", 25, "", , Skill.SkillType.));
        skills.Add(new Skill("", 26, "", , Skill.SkillType.));
        skills.Add(new Skill("", 27, "", , Skill.SkillType.));
        skills.Add(new Skill("", 28, "", , Skill.SkillType.));
        skills.Add(new Skill("", 29, "", , Skill.SkillType.));
        skills.Add(new Skill("", 30, "", , Skill.SkillType.));
        //// Mage Skills
        // add pages
        AddPage(mageSkills, 2);

        //-1, -1, -1, -1, -1, -1, -1, -1,
        //-1, -1, -1, -1, -1, -1, -1, -1,
        //-1, -1, -1, -1, -1, -1, -1, -1,
        //-1, -1, -1, -1, -1, -1, -1, -1,
        //-1, -1, -1, -1, -1, -1, -1, -1

        List<List<int>> mage =
            new List<List<int>>(new[]{
                // A 8 x 5 matrix, what is seen here will be the same on screen
            new List<int>(new []{
             1, 2, 3, 4, -1, -1, -1, 8,
            15, 16, 17, 18, -1, -1, -1, -1,
            23, 20, 21, 22, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1,
            0, 24, 14, 19, -1, -1, -1, -1}),
            new List<int>(new []{
            5, 9, 10, 12, -1, -1, -1, -1,
            6, 7, 11, 13, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1})
            });
        AddSkills(mageSkills, mage);
    }


    private void AddPage(List<List<Skill>> page, int pages)
    {
        for (int i = 0; i < pages; i += 1)
        {
            page.Add(new List<Skill>());
        }
    }

    private void AddSkills(List<List<Skill>> listToAdd, List<List<int>> listOfItems)
    {
        for (int k = 0; k < listOfItems.Count; k += 1)
        {
            while (listToAdd[k].Count < 40)// 40 skills in a page
            {
                listToAdd[k].Add(new Skill());
            }
            for (int l = 0; l < listOfItems[k].Count; l += 1)
            {
                for (int j = 0; j < skills.Count; j += 1)
                {
                    if (skills[j].skillID == listOfItems[k][l])
                    {
                        listToAdd[k][l] = skills[j];
                        break;
                    }
                }
            }
        }
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

    void ExtraInfoAdd()
    {
        for (int i = 0; i < skills.Count; i += 1)
        {
            switch (skills[i].skillID)
            {
                case 1:
                    {
                        
                        break;
                    }
            }
        }
    }

    

}
