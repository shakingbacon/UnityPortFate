using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSkills : MonoBehaviour {

    public static QuickSkills quickSkills;
    public Transform quickSkillPrefab;
    public static Transform quickSkillGameObject;
    //public static List<Skill> quickSkills = new List<Skill>();
    public static int selectedQuickSkillsCount;

    void Start()
    {
        quickSkillGameObject = gameObject.transform;
        quickSkills = quickSkillGameObject.GetComponent<QuickSkills>();
    }

    public static void AddQuickSkill(Skill skill)
    {
        Transform newSkill = Instantiate(quickSkills.quickSkillPrefab, quickSkillGameObject);
        newSkill.transform.localScale = new Vector3(1,1,1);
        newSkill.GetComponent<SkillHolder>().skill = skill;
        newSkill.GetComponent<Button>().interactable = true;
        newSkill.GetComponent<Image>().sprite
            = newSkill.GetComponent<SkillHolder>().skill.skillIMG;
    }

    public static void ResetQuickSkills()
    {
        foreach (Transform skill in quickSkillGameObject)
        {
            Destroy(skill.gameObject);
        }
    }

    public static void MoveToBattleUI()
    {
        if (quickSkillGameObject.childCount != 0)
        {
            while (quickSkillGameObject.childCount != 0)
            {
                quickSkillGameObject.GetChild(0).SetParent(BattleUI.quickSkills);
            }
        }
        //quickSkillGameObject.DetachChildren();
        //quickSkillGameObject.SetParent(SkillPage.skillPage);


    }
    public static void MoveToSkillPage()
    {
        if (BattleUI.quickSkills.childCount != 0)
        {
            while (BattleUI.quickSkills.childCount != 0)
            {
                BattleUI.quickSkills.GetChild(0).SetParent(quickSkillGameObject);
            }
        }
    }

}
