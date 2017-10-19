using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillUpdate : MonoBehaviour {

    static Player player;

	void Start () {
        player = GetComponent<Player>();
	}
	
    public static void UpdateSkills()
    {
        foreach (Transform skillChild in SkillUI.Instance.learnedSkills)
        {
            Skill skill = skillChild.GetComponent<SkillPanelContainer>().skill;
            skill.skillDamage = new Damage();
            switch (skill.skillID)
            {
                case 0:
                    {

                        skill.skillDamage.Amount = 100;
                        skill.skillDamage.Knockback = 7f;
                        skill.skillDamage.Stun = 0.25f;
                        skill.skillMana = 50;
                        skill.FindAilment(SkillAilment.AilmentType.Burn).ailmentChance = 25;
                        break;
                    }
                case 1:
                    {
                        skill.skillMana = 100;
                        skill.skillChannelDuration = 2f;
                        skill.skillActiveDuration = 10f;
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
                 skill.skillDamage.Amount, skill.skillMana, skill.skillDamage.Knockback, skill.skillDamage.Stun, skill.skillCooldown);
            if (skill.skillAilments != null)
                foreach (SkillAilment ailment in skill.skillAilments)
                {
                    ailmentDesc += string.Format("\n{0}: {1}%",
                        ailment.ailmentType, ailment.ailmentChance);
                }
        }
        else if (skill.skillType == Skill.SkillType.Active)
        {
            ailmentDesc += string.Format("Mana Cost: {0}\nCooldown: {1} secs", skill.skillMana, skill.skillCooldown);
        }
        return ailmentDesc;
    }
}
