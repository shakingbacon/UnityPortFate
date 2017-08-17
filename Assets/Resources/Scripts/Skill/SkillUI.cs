using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    public RectTransform skillPanel;
    public RectTransform scrollViewContent;
    SkillPanelContainer skillContainer { get; set; }
    bool menuIsActive { get; set; }
    Skill currentSelectedItem { get; set; }

    // Use this for initialization
    void Awake()
    {
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
        SkillPanelContainer emptyItem = Instantiate(skillContainer, scrollViewContent);
        emptyItem.transform.localPosition = new Vector3(1, 1, 1);
        emptyItem.SetSkill(item);
        // emptyItem.transform.SetParent(scrollViewContent);
        scrollViewContent.sizeDelta = new Vector2(scrollViewContent.rect.width, scrollViewContent.rect.height + emptyItem.GetComponent<RectTransform>().rect.height);
        emptyItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}
