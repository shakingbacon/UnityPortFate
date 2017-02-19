using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill {
    public string skillName;
    public int skillID;
    public Texture2D skillIMG;
    //public AudioSource skillSound;
    public string skillDesc;
    public string skillRequire;
    public int skillRank;
    public int skillMaxRank;
    public int skillDamage;
    public int skillManaCost;
    public SkillType skillType;

    public enum SkillType
    {
        Physical,
        Magical,
        Active,
        Passive
    }

    public Skill(string name, int id, Texture2D img, string desc, string req, int maxrank, SkillType type)
    {
        skillName = name;
        skillID = id;
        skillIMG = img;
        skillDesc = desc;
        skillRequire = req;
        skillMaxRank = maxrank;
        skillType = type;
    }
}
