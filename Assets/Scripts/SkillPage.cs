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
    public static Transform quickSkillsInfo;
    public static Button startBattle;

    public static bool quickSkillsPressed;

    void Start()
    {
        skillPage = gameObject.transform;
        skillPoints = skillPage.FindChild("SP");
        leftButton = skillPage.FindChild("Left Button");
        rightButton = skillPage.FindChild("Right Button");
        closeButton = skillPage.FindChild("Close Button");
        learnedSkillsButton = skillPage.FindChild("Learned Skills Button");
        quickSkillsButton = skillPage.FindChild("Quick Skills Button");
        quickSkillsInfo = skillPage.FindChild("Quick Skill Info");
        pageNum = skillPage.FindChild("Page Num");
        //currentPage = PlayerSkills.skills;
        leftButton.GetComponent<Button>().onClick.AddListener(prevPage);
        rightButton.GetComponent<Button>().onClick.AddListener(nextPage);
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
        closeButton.GetComponent<Button>().onClick.AddListener(() => GameManager.CheckSkillPage());
        quickSkillsButton.GetComponent<Button>().onClick.AddListener(QuickSkillButtonPress);
        quickSkillsButton.gameObject.SetActive(false);
        pageNum.GetComponent<Text>().text = (pageInt + 1).ToString();
        startBattle = skillPage.FindChild("Start Battle").GetComponent<Button>();
        startBattle.onClick.AddListener(StartBattleButtonClick);
    }

    public static void StartBattleButtonClick()
    {
        if (BattleUI.playerGlyph.childCount != 0)
        {
            SkillPage.skillPage.gameObject.SetActive(true);
            skillPage.GetComponent<SkillPage>().StartCoroutine(DamageCalc.StartFullBattle(GameManager.player, Battle.enemy));
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }

    public static void UpdateSkillPoints()
    {
        skillPoints.GetComponent<Text>().text = "SP: " + GameManager.player.skillPoints.ToString();
    }

    public static void InstantLearnedSkillPage()
    {
        GameManager.OpenClosePage("Skill Page");
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
        LearnedSkillButtonPress();
    }

    static void QuickSkillButtonPress()
    {
        quickSkillsPressed = true;
        learnedSkillsButton.gameObject.SetActive(false);
        quickSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        quickSkillsButton.GetComponent<Button>().onClick.AddListener(AfterQuickSkillButonPress);
        quickSkillsButton.GetComponentInChildren<Text>().text = "Finish";
        SoundDatabase.PlaySound(21);
    }

    public static void AfterQuickSkillButonPress()
    {
        quickSkillsPressed = false;
        learnedSkillsButton.gameObject.SetActive(true);
        quickSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        quickSkillsButton.GetComponent<Button>().onClick.AddListener(QuickSkillButtonPress);
        SoundDatabase.PlaySound(32);
        quickSkillsButton.GetComponentInChildren<Text>().text = "Quick Skills";
    }

    static void LearnedSkillButtonPress()
    {
        if (GameManager.inTutorial)
        {
            Tutorial.pressedLearnedSkills = true;
        }
        //
        SoundDatabase.PlaySound(18);
        currentPage = GameManager.player.skills;
        if (!GameManager.inBattle)
        { 
            quickSkillsButton.gameObject.SetActive(true);
        }
        pageInt = 0;
        UpdateSkillPage(pageInt);
        learnedSkillsButton.GetComponent<Button>().onClick.RemoveAllListeners();
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(AfterLearnedSkillButtonPress);
        learnedSkillsButton.GetComponent<Button>().onClick.AddListener(() => SoundDatabase.PlaySound(18));
        learnedSkillsButton.GetComponentInChildren<Text>().text = "Back";
    }

    public static void AfterLearnedSkillButtonPress()
    {
        currentPage = GameManager.player.skillsJob.skills;
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
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
            else
            {
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().enabled = true;
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Button>().interactable = true;
                skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().sprite
                    = skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<SkillHolder>().skill.skillIMG;
            }
        }
        skillPage.FindChild("Page Num").GetComponent<Text>().text = (pageInt + 1).ToString();
        checkPages();
    }
}
