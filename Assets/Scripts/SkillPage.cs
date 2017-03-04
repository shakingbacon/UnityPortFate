using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillPage : MonoBehaviour {

    SkillDatabase skillDatabase;
    public int pageNum;

    void Start()
    {
        skillDatabase = GameObject.FindGameObjectWithTag("Skill Database").GetComponent<SkillDatabase>();
        UpdateSkillPage(0);
        gameObject.transform.FindChild("Left Button").GetComponent<Button>().onClick.AddListener(prevPage);
        gameObject.transform.FindChild("Right Button").GetComponent<Button>().onClick.AddListener(nextPage);
    }

    void Update()
    {
        gameObject.transform.FindChild("Page Num").GetComponent<Text>().text = (pageNum + 1).ToString();
        if (pageNum == 0)
        {
            gameObject.transform.FindChild("Left Button").GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.transform.FindChild("Left Button").GetComponent<Button>().interactable = true;
        }
        if (pageNum + 1 < GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>().skills.Count)
        {
            gameObject.transform.FindChild("Right Button").GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.transform.FindChild("Right Button").GetComponent<Button>().interactable = false;
        }
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


    void UpdateSkillPage(int pagenum)
    {
        for (int i = 0; i < gameObject.transform.FindChild("Skills").transform.childCount; i += 1)
        {
            gameObject.transform.FindChild("Skills").transform.GetChild(i).GetComponent<SkillHolder>().skill
                = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>().skills[pagenum][i];
            if (skillDatabase.mageSkills[pagenum][i].skillID == -1)
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
