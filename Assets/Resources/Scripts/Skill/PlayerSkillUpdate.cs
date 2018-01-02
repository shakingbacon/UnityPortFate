using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillUpdate : MonoBehaviour
{

    static Player player;

    void Start()
    {
        player = GetComponent<Player>();
        OnSkillChanged += UpdateSkills;
    }
    public delegate void SkillChange();
    public static event SkillChange OnSkillChanged;

    public static void SkillChanged()
    {
        OnSkillChanged();
    }

    public static void UpdateSkills()
    {

        foreach (Skill skill in PlayerSkillController.Instance.Skills)
        {
            skill.skillAilments.Clear();
            skill.extras.Clear();
            switch (skill.skillID)
            {
                case 0:
                    {

                        skill.DamageAmount = 100;
                        skill.Knockback = 7f;
                        skill.Stun = 0.25f;
                        skill.skillMana = 50;
                        skill.skillCooldown = 3f;
                        skill.skillAilments.Add(new SkillAilment(SkillAilment.AilmentType.Burn, 25));
                        skill.skillDesc = "Shoot in a straight line a small ball of fire, dealing Magical Fire damage. Has a chance to burn";
                        break;
                    }
                case 1:
                    {
                        skill.skillMana = 100;
                        skill.skillChannelDuration = 2f;
                        skill.skillActiveDuration = 10f;
                        skill.skillCooldown = 20;
                        skill.extras.Add((int)(skill.skillCooldown * 1.6)); // channel damage reduction
                        skill.skillDesc = string.Format("Channel for {0} seconds to amplify your next Magical damaging skill for {1} seconds. During the channel, you take {2} reduced damage.",
                            skill.skillChannelDuration, skill.skillActiveDuration, skill.extras[0]);
                        break;
                    }
                case 2:
                    {
                        skill.skillMana = 25;
                        skill.skillChannelDuration = 2f;
                        skill.skillActiveDuration = 300f;
                        skill.skillCooldown = 300;
                        skill.skillDesc = string.Format("Channel for {0} seconds to take damage from your Mana before your Health for {1} seconds.",
                                                    skill.skillChannelDuration, skill.skillActiveDuration);
                        break;
                    }
                case 3:
                    {
                        skill.extras.Add((15 + 50 * (skill.skillRank + 1)) * (skill.skillRank + 1));
                        skill.skillDesc = string.Format("Rank this skill to obtain +{0} Mana permanently.",
                            skill.extras[0]);
                        break;
                    }
                case 4:
                    {

                        skill.skillMana = 75;
                        skill.skillChannelDuration = 4f;
                        skill.skillCooldown = 30f;
                        skill.extras.Add(10 + (5 * skill.skillRank + 1)); // base
                        skill.extras.Add(35 + (7 * skill.skillRank + 1)); // missing health
                        skill.skillDesc = string.Format("Channel for {0} seconds to restore {1}% of Max HP + {2}% of missing HP.", skill.skillChannelDuration, skill.extras[0], skill.extras[1]);
                        break;
                    }
            }
            skill.skillEffDesc = AddEffDescString(skill);
        }
    }

    static string AddEffDescString(Skill skill)
    {
        string ailmentDesc = "";
        if (skill.skillType == Skill.SkillType.Physical || skill.skillType == Skill.SkillType.Magical)
        {
            ailmentDesc += string.Format("Damage: {0}\nMana Cost: {1}\nKnockback: {2}\nStun: {3} secs\nCooldown: {4} secs",
                 skill.DamageAmount, skill.skillMana, skill.Knockback, skill.Stun, skill.skillCooldown);
            if (skill.skillAilments != null)
                foreach (SkillAilment ailment in skill.skillAilments)
                {
                    ailmentDesc += string.Format("\n{0}: {1}%",
                        ailment.ailmentType, ailment.ailmentChance);
                }
        }
        else if (skill.skillType == Skill.SkillType.Active || skill.skillType == Skill.SkillType.Utility)
        {
            ailmentDesc += string.Format("Mana Cost: {0}\nCooldown: {1} secs", skill.skillMana, skill.skillCooldown);
        }
        return ailmentDesc;
    }
}
