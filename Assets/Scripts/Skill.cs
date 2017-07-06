using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill {
    public string skillName;
    public int skillID;
    public Sprite skillIMG;
    public int skillSoundID = -1;// from sounds list , -1 id means random basic atk sound
    public string skillDesc;
    public string skillEffDesc;
    public string skillRequireDesc;
    public bool skillRequire = true;
    public int skillRank;
    public int skillMaxRank;
    public int skillDamage;
    public int skillManaCost;
    // for actives/passives dmg, hit,crit, and critmulti can be used for other values not just hit crit and multi
    public int skillHitChance;
    public int skillCritChance;
    public int skillCritMulti;
    public int skillCooldown;
    public int skillDuration;
    public int skillCooldownEnd;
    public bool skillOnCooldown;
    public int skillPriority = 0;
    public StatusEffects skillStatusEff = new StatusEffects();
    public SkillType skillType;
    public SkillHitboxData skillHitboxData = new SkillHitboxData();

    public enum SkillType
    {
        Physical,
        Magical,
        True,
        Active,
        Passive
    }

    public Skill(string name, int id, int soundid, string desc, int maxrank, SkillType type)
    {
        skillName = name;
        skillID = id;
        skillIMG = Resources.Load<Sprite>("Skills/" + name);
        skillSoundID = soundid;
        skillDesc = desc;
        skillMaxRank = maxrank;
        skillType = type;
        skillPriority = 0;
    }

    public Skill(string name, int id, string desc, int maxrank, SkillType type)
    {
        skillName = name;
        skillID = id;
        skillIMG = Resources.Load<Sprite>("Skills/" + name);
        skillSoundID = -1;
        skillDesc = desc;
        skillMaxRank = maxrank;
        skillType = type;
        skillPriority = 0;
    }

    public Skill(Skill skill)
    {
        skillName = skill.skillName;
        skillID = skill.skillID;
        skillSoundID = skill.skillSoundID;
        skillIMG = Resources.Load<Sprite>("Skills/" + skill.skillName);
        skillDesc = skill.skillDesc;
        skillRank = skill.skillRank;
        skillMaxRank = skill.skillMaxRank;
        skillDamage = skill.skillDamage;
        skillManaCost = skill.skillManaCost;
        skillHitChance = skill.skillHitChance;
        skillCritChance = skill.skillCritChance;
        skillCritMulti = skill.skillCritMulti;
        skillCooldown = skill.skillCooldown;
        skillDuration = skill.skillDuration;
        skillCooldownEnd = skill.skillCooldownEnd;
        skillType = skill.skillType;
        skillPriority = skill.skillPriority;
        skillStatusEff = new StatusEffects(skill.skillStatusEff);
    }
    public Skill()
    {
        skillID = -1;
    }
    public Skill(string name, int id, string desc)// usually a status effect 
    {
        skillName = name;
        skillID = id;
        skillDesc = desc;
        skillDuration = -1;
    }

}
