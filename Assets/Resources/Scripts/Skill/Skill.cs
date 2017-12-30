using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Skill : Damage {
    public string skillName;
    public int skillID;
    public string skillDesc;
    public string skillEffDesc;
    public int skillRank;
    public int skillMaxRank;
    public float skillCooldown;
    public float skillChannelDuration;
    public float skillActiveDuration;

    public int skillMana;

    public List<int> extras;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillType skillType;
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillStyle skillStyle;
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SkillElement skillElement;
    public List<SkillAilment> skillAilments;

    public enum SkillElement
    {
        None,
        Fire
    }

    public enum SkillType
    {
        Physical,
        Magical,
        Active,
        Passive,
        Utility
    }

    public enum SkillStyle
    {
        None,
        Melee,
        Projectile,
        Channel,
        Aura
    }

    public Skill()
    {
    }

    public Skill(Skill skill)
    {
        skillName = skill.skillName;
        skillMana = skill.skillMana;
        skillID = skill.skillID;
        skillDesc = skill.skillDesc;
        skillRank = skill.skillRank;
        skillMaxRank = skill.skillMaxRank;
        skillAilments = new List<SkillAilment>();
        skillAilments.ForEach(anAilment => skillAilments.Add(anAilment));
        skillType = skill.skillType;
        skillStyle = skill.skillStyle;
        skillElement = skill.skillElement;
        DamageAmount = skill.DamageAmount;
        HitChance = skill.HitChance;
        Knockback = skill.Knockback;
        Stun = skill.Stun;
        skillCooldown = skill.skillCooldown;
        skillChannelDuration = skill.skillChannelDuration;
        skillActiveDuration = skill.skillActiveDuration;
        extras = skill.extras;
    }

    [JsonConstructor]
    public Skill(string name, int id, //string desc,
        int maxrank,
        List<SkillAilment> ailments, SkillType type, 
        SkillStyle style = SkillStyle.None, SkillElement element = SkillElement.None)
    {
        this.skillName = name;
        this.skillID = id;
        //this.skillDesc = desc;
        this.skillRank = 0;
        this.skillMaxRank = maxrank;
        skillAilments = ailments;
        this.skillType = type;
        this.skillStyle = style;
        skillElement = element;
        skillChannelDuration = 0f;
        extras = new List<int>();
    }

    public SkillAilment FindAilment(SkillAilment.AilmentType type)
    {
        return skillAilments.Find(anAilment => anAilment.ailmentType == type);
    }
}
