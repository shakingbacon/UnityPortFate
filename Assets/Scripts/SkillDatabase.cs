using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : MonoBehaviour {
    public static List<Skill> skills = new List<Skill>();
    public static List<List<Skill>> mageSkills = new List<List<Skill>>();
    // Mage skills #1-100, Rouge skills #101-200, Warrior skills #201-300
    void Start()
    {
        skills.Add(new Skill());
        skills.Add(new Skill("Basic Attack", 0, "Attack with your weapon", 1, Skill.SkillType.Physical));
        skills.Add(new Skill("Inferno", 1, 13, "Fire burns, set ablaze", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Tsunami", 2, 28, "Wash away and drown", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Tornado", 3, 30, "Things around you fly", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Thunderstorm", 4, 27, "Call thunder", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Mana Gaurd", 5, 19, "Mana gaurds your health", 5, Skill.SkillType.Active));
        skills.Add(new Skill("Restore", 6, 14, "Restore Health", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Meditate", 7, 10, "Focus your mind", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Corpse Drain", 8, "Gain more when killing", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Max MP +", 9, "Expand your mind", 8, Skill.SkillType.Passive));
        skills.Add(new Skill("Magic Mastery", 10, "Train your skills", 8, Skill.SkillType.Passive));
        skills.Add(new Skill("Mana Armor", 11, "Mana is armor", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("As One", 12, "Become one with yourself", 1, Skill.SkillType.Passive));
        skills.Add(new Skill("Barrier", 13, 10, "Create a barrier", 6, Skill.SkillType.Active));
        skills.Add(new Skill("Elemental Affinty", 14, "Learn the elements", 5, Skill.SkillType.Passive));
        skills.Add(new Skill("Volcano Shield", 15, 39, "Harden yourself with fire", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Purity", 16, 19, "Purify yourself", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Cyclone Pressure", 17, 40, "Pressure the enemy", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Electric Charge", 18, 44, "Charge your battery", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Elemental Burst", 19, 50, "Channel all elements", 7, Skill.SkillType.Magical));
        skills.Add(new Skill("风水", 20, "Understand surroundings", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Glass Cannon", 21, "All in", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Soaked Shock", 22, "Careful", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Plasma Fusion", 23, "Feel the power", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Magical Attack", 24, 31, "Basic magical attack", 1, Skill.SkillType.Magical));
        //////////////
        skills.Add(new Skill("Solar Flare", 25, 13, "Power of the sun", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Lunar Blade", 26, 52, "Power of the moon", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Elemental Strike", 27, "Strike with elements", 10, Skill.SkillType.Physical));
        skills.Add(new Skill("Shining Rays", 28, 51, "Call upon the light", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Razor Leaf", 29, 49, "Sharp leaves", 10, Skill.SkillType.Physical));
        skills.Add(new Skill("Spirit Strike", 30, 53, "Attack the soul", 10, Skill.SkillType.Magical));
        skills.Add(new Skill("Adaptation", 31, 45, "Easy yourself", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Heat Wave", 32, 48, "Hot stuff", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Lunar Eclipse", 33, 47, "Moon?", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Dark Veil", 34, 54, "So dark", 3, Skill.SkillType.Active));
        skills.Add(new Skill("Respiration", 35, "Breathe", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Scorched Touch", 36, "Sizzle", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Lunatic", 37, "Crazy", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Photosynthesis", 38, "Absorb sun", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("升天", 39, "Ascend", 3, Skill.SkillType.Passive));
         skills.Add(new Skill("Gravity", 40, "Heavy", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Night's Shadow", 41, "Darkness", 3, Skill.SkillType.Passive));
        //
        skills.Add(new Skill("Rising Tide", 42, "High tide", 3, Skill.SkillType.Passive));
        skills.Add(new Skill("Run", 43, -2, "", 0, Skill.SkillType.Active));
        //skills.Add(new Skill("", 43, "", , Skill.SkillType.));
        //skills.Add(new Skill("", 44, "", , Skill.SkillType.));
        //skills.Add(new Skill("", 45, "", , Skill.SkillType.));
        //skills.Add(new Skill("", 46, "", , Skill.SkillType.));
        //skills.Add(new Skill("", 47, "", , Skill.SkillType.));
        //skills.Add(new Skill("", 48, "", , Skill.SkillType.));
        //skills.Add(new Skill("", 49, "", , Skill.SkillType.));



        // statuses the hit chance is the chance
        skills.Add(new Skill("Burn", 1000, ""));
        skills.Add(new Skill("Paralyze", 1001, ""));
        skills.Add(new Skill("Bleed", 1002, ""));
        skills.Add(new Skill("Poison", 1003, ""));
        skills.Add(new Skill("Cripple", 1004, ""));
        skills.Add(new Skill("Blind", 1005, ""));
        skills.Add(new Skill("Confuse", 1006, ""));
        skills.Add(new Skill("Curse", 1007, ""));
        skills.Add(new Skill("Soaked", 1008, ""));

        AddAllHitboxData();
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
                // An 8 x 5 matrix, what is seen here will be the same on screen 
            new List<int>(new []{
             1, 2, 3, 4, 29, 25, 26, 30,
            15, 16, 17, 18, 31, 32, 33, 34,
            -1, -1, -1, -1, 35, 36, 37, 8,
            23, 20, 21, 22, 38, 39, 40, 41,
            27, 19, 14, -1, -1, -1, -1, -1}),
            new List<int>(new []{
            5, 9, 10, 12, 28, -1, -1, -1,
            6, 7, -1, 13, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, -1, -1,
            -1, -1, -1, -1, -1, -1, 0, 24})
            });
        AddSkills(mageSkills, mage);
    }

    private void AddAllHitboxData()
    {
        foreach(Skill skill in skills)
        {
            switch (skill.skillID)
            {
                case 0: { GiveHitbox(skill, 0, 1.25f); break; }
            }
        }
    }

    private void GiveHitbox(Skill skill, int id, float timer)
    {
        skill.skillHitboxData = new SkillHitboxData(id, timer);
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

    public static Skill GetSkill(int id)
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
