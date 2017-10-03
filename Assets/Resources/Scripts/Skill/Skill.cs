using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Skill {
    public string skillName;
    public int skillID;
    public string skillDesc;
    public string skillEffDesc;
    public int skillRank;
    public int skillMaxRank;
    public float skillCooldown;

    public int skillDamage;
    public int skillMana;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillType skillType;
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillStyle skillStyle;
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillElement skillElement;
    public List<SkillAilment> skillAilments;


    public Skill()
    {
    }

    [JsonConstructor]
    public Skill(string name, int id, string effdesc, int maxrank, SkillType type, SkillStyle style, SkillElement element, List<SkillAilment> ailments)
    {
        this.skillName = name;
        this.skillID = id;
        this.skillDesc = effdesc;
        this.skillRank = 0;
        this.skillMaxRank = maxrank;
        this.skillType = type;
        this.skillStyle = style;
        skillElement = element;
        skillAilments = ailments;
    }

    public enum SkillElement
    {
        Fire
    }

    public enum SkillType
    {
        Physical,
        Magical,
        Active,
        Passive
    }

    public enum SkillStyle
    {
        Melee,
        Projectile,
        Aura,
        None
    }

    public SkillAilment FindAilment(SkillAilment.AilmentType type)
    {
        return skillAilments.Find(anAilment => anAilment.ailmentType == type);
    }
}
