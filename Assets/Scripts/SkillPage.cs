using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillPage : MonoBehaviour {

    SkillDatabase skillDatabase;
    public int pageNum;
    public List<List<Skill>> currentPage;

    void Start()
    {
        skillDatabase = GameObject.FindGameObjectWithTag("Skill Database").GetComponent<SkillDatabase>();
        currentPage = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>().skills;
        UpdateSkillPage(0);
        gameObject.transform.FindChild("Left Button").GetComponent<Button>().onClick.AddListener(prevPage);
        gameObject.transform.FindChild("Right Button").GetComponent<Button>().onClick.AddListener(nextPage);
        gameObject.transform.FindChild("Learned Skills Button").GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
    }

    void Update()
    {
        gameObject.transform.FindChild("SP").GetComponent<Text>().text = "SP: " +
            StatUtilities.FindStatTotal(GameObject.FindGameObjectWithTag("Player Stats").GetComponent<PlayerStats>().stats, 18);
        gameObject.transform.FindChild("Page Num").GetComponent<Text>().text = (pageNum + 1).ToString();
        if (pageNum == 0)
        {
            gameObject.transform.FindChild("Left Button").GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.transform.FindChild("Left Button").GetComponent<Button>().interactable = true;
        }
        if (pageNum + 1 < currentPage.Count)
        {
            gameObject.transform.FindChild("Right Button").GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.transform.FindChild("Right Button").GetComponent<Button>().interactable = false;
        }
    }

    
    void LearnedSkillButtonPress()
    {
        currentPage = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>().learnedSkills;
        pageNum = 0;
        UpdateSkillPage(pageNum);
        gameObject.transform.FindChild("Learned Skills Button").GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.transform.FindChild("Learned Skills Button").GetComponent<Button>().onClick.AddListener(AfterLearnedSkillButtonPress);
        gameObject.transform.FindChild("Learned Skills Button").GetComponentInChildren<Text>().text = "Back";
    }

    void AfterLearnedSkillButtonPress()
    {
        currentPage = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>().skills;
        pageNum = 0;
        UpdateSkillPage(pageNum);
        gameObject.transform.FindChild("Learned Skills Button").GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.transform.FindChild("Learned Skills Button").GetComponent<Button>().onClick.AddListener(LearnedSkillButtonPress);
        gameObject.transform.FindChild("Learned Skills Button").GetComponentInChildren<Text>().text = "Learned Skills";
    }
    void prevPage()
    {
        pageNum -= 1;
        UpdateSkillPage(pageNum);
    }

    void nextPage()
    {
        pageNum += 1;
        UpdateSkillPage(pageNum);
    }
   // 

    void UpdateSkillPage(int pagenum)
    {
        for (int i = 0; i < gameObject.transform.FindChild("Skills").transform.childCount; i += 1)
        {
            gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<SkillHolder>().skill
                = currentPage[pagenum][i];
            if (currentPage[pagenum][i].skillID == -1)
            {
                gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<Button>().interactable = false;
                gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("unity_builtin_extra/UISprite");
            }
            else
            {
                gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<Button>().interactable = true;
                gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().sprite
                    = gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<SkillHolder>().skill.skillIMG;
            }
        }
    }
}
