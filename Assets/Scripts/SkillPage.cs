using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillPage : MonoBehaviour {

    SkillDatabase skillDatabase;
    void Start()
    {
        skillDatabase = GameObject.FindGameObjectWithTag("Skill Database").GetComponent<SkillDatabase>();
        for (int i = 0; i < gameObject.transform.childCount; i += 1)
        {
            gameObject.transform.GetChild(i).GetComponent<SkillHolder>().skill = skillDatabase.mageSkills[i];
            if (skillDatabase.mageSkills[i].skillID == -1)
            {
                gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = gameObject.transform.GetChild(i).GetComponent<SkillHolder>().skill.skillIMG;
            }
        }
    }
}
