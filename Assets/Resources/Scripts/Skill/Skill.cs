using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Skill {

    public string skillName;
    public string skillEffDesc;
    public int skillRank;
    public int skillMaxRank;
    public float skillCooldown;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillType skillType;
    public SkillStyle skillStyle;

    public Skill()
    {
    }

    [Newtonsoft.Json.JsonConstructor]
    public Skill(string name, string effdesc, int maxrank, SkillType type, SkillStyle style)
    {
        this.skillName = name;
        this.skillEffDesc = effdesc;
        this.skillRank = 0;
        this.skillMaxRank = maxrank;
        this.skillType = type;
        this.skillStyle = style;
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
}
