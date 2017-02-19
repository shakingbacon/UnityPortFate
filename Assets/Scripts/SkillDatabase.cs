using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : MonoBehaviour {
    public List<Skill> skills = new List<Skill>();

    // Mage skills #1-100, Rouge skills #101-300, Warrior skills #301-400
    void Start()
    {
        skills.Add(new Skill("Basic Attack", 0, null, "Attack with your weapon", null, 0, Skill.SkillType.Physical));
        // Mage Skills

    }
}
