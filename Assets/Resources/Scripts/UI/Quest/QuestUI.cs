using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour {

    public RectTransform questPanel;
    public RectTransform questScrollContent;

    QuestUIContainer questContainer;
    bool menuIsActive { get; set; }
    Quest currentSelectedQuest;

    void Start()
    {
        questContainer = Resources.Load<QuestUIContainer>("Prefabs/UI/Quest/Quest Container");
        UIEventHandler.OnQuestAccepted += QuestAdd;
        questPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            menuIsActive = !menuIsActive;
            questPanel.gameObject.SetActive(menuIsActive);
        }
    }

    public void QuestAdd(Quest quest)
    {
        PlayerQuestController.Instance.inProgressQuests.Add(quest);
        QuestUIContainer emptyItem = Instantiate(questContainer, questScrollContent);
        emptyItem.transform.localPosition = new Vector3(1, 1, 1);
        emptyItem.SetQuest(quest);
        // emptyItem.transform.SetParent(scrollViewContent);
        questScrollContent.sizeDelta = new Vector2(questScrollContent.rect.width, questScrollContent.rect.height + questContainer.GetComponent<RectTransform>().rect.height); // height of container
        emptyItem.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    public void QusetRemoved()
    {
        questScrollContent.sizeDelta = new Vector2(questScrollContent.rect.width, questScrollContent.rect.height - questContainer.GetComponent<RectTransform>().rect.height);
    }

    public void OpenCloseQuestPanel()
    {
        menuIsActive = !menuIsActive;
        questPanel.gameObject.SetActive(menuIsActive);
    }
}
