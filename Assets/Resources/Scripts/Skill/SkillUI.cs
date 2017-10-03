using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    public static SkillUI Instance;
    public RectTransform skillPanel;
    public RectTransform learnedSkills;

    SkillPanelContainer skillContainer { get; set; }
    bool menuIsActive { get; set; }
    Skill currentSelectedItem { get; set; }

    // Use this for initialization
    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        skillContainer = Resources.Load<SkillPanelContainer>("Prefabs/UI/Panel_Skills/SkillContainer");
        skillPanel.gameObject.SetActive(false);
        UIEventHandler.OnSkillLearn += SkillAdded;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            menuIsActive = !menuIsActive;
            skillPanel.gameObject.SetActive(menuIsActive);
        }
    }

    public void SkillAdded(Skill item)
    {
        SkillPanelContainer emptyItem = Instantiate(skillContainer, learnedSkills);
        emptyItem.transform.localPosition = new Vector3(1, 1, 1);
        emptyItem.SetSkill(item);
        // emptyItem.transform.SetParent(scrollViewContent);
        learnedSkills.sizeDelta = new Vector2(learnedSkills.rect.width, learnedSkills.rect.height + emptyItem.GetComponent<RectTransform>().rect.height);
        emptyItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
