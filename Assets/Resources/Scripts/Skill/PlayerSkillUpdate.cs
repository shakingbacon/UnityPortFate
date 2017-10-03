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
            switch (skill.skillID)
            {
                case 0:
                    {
                        skill.skillDamage = 100;
                        skill.skillMana = 50; 
                        skill.FindAilment(SkillAilment.AilmentType.Burn).ailmentChance = 25;
                        break;
                    }
            }
            skill.skillEffDesc = string.Format("Damage: {0}\nMana Cost: {1}", skill.skillDamage, skill.skillMana);
            skill.skillEffDesc += AddAilmentChanceString(skill);
        }
    }

    static string AddAilmentChanceString(Skill skill)
    {
        string ailmentDesc = "";
        foreach (SkillAilment ailment in skill.skillAilments)
        {
            ailmentDesc += string.Format("\n{0}: {1}%", ailment.ailmentType, ailment.ailmentChance);

        }
        return ailmentDesc;
    }
}
