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
    public string skillRequire;
    public int skillRank;
    public int skillMaxRank;
    public int skillDamage;
    public int skillManaCost;
    public int skillHitChance;
    public int skillCritChance;
    public int skillCritMulti;
    public SkillType skillType;

    public enum SkillType
    {
        Physical,
        Magical,
        Active,
        Passive
    }

    public Skill(string name, int id, string desc, string req, int maxrank, SkillType type)
    {
        skillName = name;
        skillID = id;
        skillIMG = Resources.Load<Sprite>("Skills/" + name);
        skillDesc = desc;
        skillRequire = req;
        skillMaxRank = maxrank;
        skillType = type;
    }
    public Skill()
    {
        skillID = -1;
    }
}
