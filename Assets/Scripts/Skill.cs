using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill {
    public string skillName;
    public int skillID;
    public Sprite skillIMG;
    //public AudioSource skillSound;
    public string skillDesc;
    public string skillEffDesc;
    public string skillRequireDesc;
    public bool skillRequire = true;
    public int skillRank;
    public int skillMaxRank;
    public int skillDamage;
    public int skillManaCost;
    // for actives hit,crit, and critmulti can be used for other values not just hit crit and multi
    public int skillHitChance;
    public int skillCritChance;
    public int skillCritMulti;
    public int skillCooldown;
    public int skillTurnEnd;
    public StatusEffects skillStatusEff = new StatusEffects();
    public SkillType skillType;

    public enum SkillType
    {
        Physical,
        Magical,
        Active,
        Passive
    }

    public Skill(string name, int id, string desc, int maxrank, SkillType type)
    {
        skillName = name;
        skillID = id;
        skillIMG = Resources.Load<Sprite>("Skills/" + name);
        skillDesc = desc;
        skillMaxRank = maxrank;
        skillType = type;
    }
    public Skill(Skill skill)
    {
        skillName = skill.skillName;
        skillID = skill.skillID;
        skillIMG = Resources.Load<Sprite>("Skills/" + skill.skillName);
        skillDesc = skill.skillDesc;
        skillMaxRank = skill.skillMaxRank;
        skillType = skill.skillType;
    }
    public Skill()
    {
        skillID = -1;
    }
}
