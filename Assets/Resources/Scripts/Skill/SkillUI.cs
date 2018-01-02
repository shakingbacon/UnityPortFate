using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public static SkillUI Instance;
    public RectTransform skillPanel;
    public RectTransform learnedSkills;
    public Text spPanel;

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
        spPanel = skillPanel.FindChild("SP Panel").FindChild("Amount").GetComponent<Text>();
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

    public void SetSPText(string amount)
    {
        spPanel.text = amount;
    }

    public void SkillAdded(PlayerSkill item)
    {
        SkillPanelContainer emptyItem = Instantiate(skillContainer, learnedSkills);
        emptyItem.transform.localPosition = new Vector3(1, 1, 1);
        emptyItem.SetSkill(item);
        // emptyItem.transform.SetParent(scrollViewContent);
        learnedSkills.sizeDelta = new Vector2(learnedSkills.rect.width, learnedSkills.rect.height + emptyItem.GetComponent<RectTransform>().rect.height);
        emptyItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
