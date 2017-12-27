using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEvents : MonoBehaviour
{
    public delegate Skill SkillEvent(Skill skill);
    public static event SkillEvent OnSkillUse;

    public static Skill SkillUsed(Skill skill)
    {
        if (OnSkillUse != null)
        {
            Skill newSkill = new Skill(skill);
            newSkill = OnSkillUse(skill);
            return newSkill;
        }
        return skill;
    }

}
