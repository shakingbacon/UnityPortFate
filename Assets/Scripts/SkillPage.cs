using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillPage : MonoBehaviour {
    public static Transform skillPage;
    public static Transform skillPoints;
    public static Transform leftButton;
    public static Transform rightButton;
    public static Transform pageNum;
    public static Transform closeButton;
    public static Transform learnedSkillsButton;
    public static int pageInt;
    public static List<List<Skill>> currentPage;

    void Awake()
    {
        skillPage = gameObject.transform;
        skillPoints = skillPage.FindChild("SP");
        leftButton = skillPage.FindChild("Left Button");
        rightButton = skillPage.FindChild("Right Button");
        closeButton = skillPage.FindChild("Close Button");
        learnedSkillsButton = skillPage.FindChild("Learned Skills Button");
        pageNum = skillPage.FindChild("Page Num");
        currentPage = PlayerSkills.skills;
        UpdateSkillPage(0);
        leftButton.GetComponent<Button>().onClick.AddListener(prevPage);
        rightButton.GetComponent<Button>().onClick.AddListener(nextPage);
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
        closeButton.GetComponent<Button>().onClick.AddListener(() => GameManager.OpenClosePage("Skill Page"));
        pageNum.GetComponent<Text>().text = (pageInt + 1).ToString();

    }
    
    public static void InstantLearnedSkillPage()
    {
        GameManager.OpenClosePage("Skill Page");
        LearnedSkillButtonPress();
    }

    static void LearnedSkillButtonPress()
    {
        currentPage = PlayerSkills.learnedSkills;
        pageInt = 0;
        UpdateSkillPage(pageInt);
        skillPage.FindChild("Learned Skills Button").GetComponent<Button>().onClick.RemoveAllListeners();
        skillPage.FindChild("Learned Skills Button").GetComponent<Button>().onClick.AddListener(AfterLearnedSkillButtonPress);
        skillPage.FindChild("Learned Skills Button").GetComponentInChildren<Text>().text = "Back";
    }

    static void AfterLearnedSkillButtonPress()
    {
        currentPage = PlayerSkills.skills;
        pageInt = 0;
        UpdateSkillPage(pageInt);
        skillPage.FindChild("Learned Skills Button").GetComponent<Button>().onClick.RemoveAllListeners();
        skillPage.FindChild("Learned Skills Button").GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
        skillPage.FindChild("Learned Skills Button").GetComponentInChildren<Text>().text = "Learned Skills";
    }
    void prevPage()
    {
        pageInt -= 1;
        skillPage.FindChild("Page Num").GetComponent<Text>().text = (pageInt + 1).ToString();
        UpdateSkillPage(pageInt);
        checkPages();
    }

    void nextPage()
    {
        pageInt += 1;
        skillPage.FindChild("Page Num").GetComponent<Text>().text = (pageInt + 1).ToString();
        UpdateSkillPage(pageInt);
        checkPages();
    }
    static void checkPages()
    {
        if (pageInt == 0)
        {
            skillPage.FindChild("Left Button").GetComponent<Button>().interactable = false;
        }
        else
        {
            skillPage.FindChild("Left Button").GetComponent<Button>().interactable = true;
        }
        if (pageInt + 1 < currentPage.Count)
        {
            skillPage.FindChild("Right Button").GetComponent<Button>().interactable = true;
        }
        else
        {
            skillPage.FindChild("Right Button").GetComponent<Button>().interactable = false;
        }
    }

    public static void UpdateSkillPage(int pageInt)
    {
        for (int i = 0; i < skillPage.FindChild("Skills").transform.childCount; i += 1)
        {
            skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<SkillHolder>().skill
                = currentPage[pageInt][i];
            if (currentPage[pageInt][i].skillID == -1)
            {
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Button>().interactable = false;
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("unity_builtin_extra/UISprite");
            }
            else
            {
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Button>().interactable = true;
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().sprite
                    = skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<SkillHolder>().skill.skillIMG;
            }
        }
        checkPages();
    }
}
