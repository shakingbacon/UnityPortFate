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
    public static Transform quickSkillsButton;
    public static List<Skill> quickSkills = new List<Skill>();
    public static bool quickSkillsPressed;

    void Awake()
    {
        skillPage = gameObject.transform;
        skillPoints = skillPage.FindChild("SP");
        leftButton = skillPage.FindChild("Left Button");
        rightButton = skillPage.FindChild("Right Button");
        closeButton = skillPage.FindChild("Close Button");
        learnedSkillsButton = skillPage.FindChild("Learned Skills Button");
        quickSkillsButton = skillPage.FindChild("Quick Skills Button");
        pageNum = skillPage.FindChild("Page Num");
        currentPage = PlayerSkills.skills;
        UpdateSkillPage(0);
        leftButton.GetComponent<Button>().onClick.AddListener(prevPage);
        rightButton.GetComponent<Button>().onClick.AddListener(nextPage);
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
        closeButton.GetComponent<Button>().onClick.AddListener(() => GameManager.OpenClosePage("Skill Page"));
        quickSkillsButton.GetComponent<Button>().onClick.AddListener(QuickSkillButtonPress);
        quickSkillsButton.gameObject.SetActive(false);
        for(int i = 0; i < 8; i++)
        quickSkills.Add(new Skill());
        pageNum.GetComponent<Text>().text = (pageInt + 1).ToString();

    }
    
    public static void UpdateSkillPoints()
    {
        skillPoints.GetComponent<Text>().text = "SP: " + PlayerStats.stats.skillPoints.ToString();
    }

    public static void InstantLearnedSkillPage()
    {
        GameManager.OpenClosePage("Skill Page");
        LearnedSkillButtonPress();
    }

    static void QuickSkillButtonPress()
    {
        quickSkills = new List<Skill>();
        quickSkillsPressed = true;
        learnedSkillsButton.gameObject.SetActive(false);
        quickSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        quickSkillsButton.GetComponent<Button>().onClick.AddListener(AfterQuickSkillButonPress);
        quickSkillsButton.GetComponentInChildren<Text>().text = "Finish";
        SoundDatabase.PlaySound(21);
    }

    public static void AfterQuickSkillButonPress()
    {
        while (quickSkills.Count != 8)
        {
            quickSkills.Add(new Skill());
        }
        quickSkillsPressed = false;
        learnedSkillsButton.gameObject.SetActive(true);
        quickSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        quickSkillsButton.GetComponent<Button>().onClick.AddListener(QuickSkillButtonPress);
        SoundDatabase.PlaySound(32);
        quickSkillsButton.GetComponentInChildren<Text>().text = "Quick Skills";
    }

    static void LearnedSkillButtonPress()
    {
        SoundDatabase.PlaySound(18);
        currentPage = PlayerSkills.learnedSkills;
        if (!GameManager.inBattle)
        { 
            quickSkillsButton.gameObject.SetActive(true);
        }
        pageInt = 0;
        UpdateSkillPage(pageInt);
        learnedSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(AfterLearnedSkillButtonPress);
        learnedSkillsButton.GetComponentInChildren<Text>().text = "Back";
    }

    public static void AfterLearnedSkillButtonPress()
    {
        SoundDatabase.PlaySound(18);
        currentPage = PlayerSkills.skills;
        pageInt = 0;
        UpdateSkillPage(pageInt);
        learnedSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
        learnedSkillsButton.GetComponentInChildren<Text>().text = "Learned Skills";
        quickSkillsButton.gameObject.SetActive(false);
    }
    void prevPage()
    {
        SoundDatabase.PlaySound(18);
        pageInt -= 1;
        skillPage.FindChild("Page Num").GetComponent<Text>().text = (pageInt + 1).ToString();
        UpdateSkillPage(pageInt);
        checkPages();
    }

    void nextPage()
    {
        SoundDatabase.PlaySound(18);
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
    
    public static void UpdateQuickSkills()
    {
        int i = 0;
        foreach(Transform skill in BattleUI.quickSkills)
        {
            skill.GetComponent<SkillHolder>().skill = quickSkills[i];
            if (quickSkills[i].skillID == -1)
            {
                BattleUI.quickSkills.GetChild(i).GetComponent<Button>().interactable = false;
                BattleUI.quickSkills.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("unity_builtin_extra/UISprite");
            }
            else
            {
                BattleUI.quickSkills.GetChild(i).GetComponent<Button>().interactable = true;
                BattleUI.quickSkills.GetChild(i).GetComponent<Image>().sprite
                    = BattleUI.quickSkills.GetChild(i).GetComponent<SkillHolder>().skill.skillIMG;
            }
            i += 1;
        }
    }
}
