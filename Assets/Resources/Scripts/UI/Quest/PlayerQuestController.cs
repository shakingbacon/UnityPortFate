using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestController : MonoBehaviour
{

    public static PlayerQuestController Instance { get; set; }
    public QuestPanel questPanel;
    public QuestUI questUI;

    public QuestAgreementPanel questAgreementPanelPrefab;

    List<int> completedQuests = new List<int>();

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        questAgreementPanelPrefab = Resources.Load<QuestAgreementPanel>("Prefabs/UI/Quest/Panel_QuestAgreement");
    }


    public void CreateQuestAgreement(int id)
    {
        QuestAgreementPanel agreementPanel = Instantiate(questAgreementPanelPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        agreementPanel.CurrentQuest = QuestDatabase.Instance.GetQuest(id);
        agreementPanel.questName.text = agreementPanel.CurrentQuest.questName;
        agreementPanel.questDetails.text = agreementPanel.CurrentQuest.questGoal;
        agreementPanel.transform.localPosition = new Vector3(0, 60, 0);
        agreementPanel.transform.localScale = new Vector3(1, 1, 1);
    }

    public bool HasQuest(int id)
    {
        foreach (Transform child in questUI.questScrollContent.transform)
        {
            Quest quest = child.GetComponent<QuestUIContainer>().quest;
            if (quest.questID == id)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasCompletedQuest(int id)
    {
        return completedQuests.Exists(anID => anID == id);
    }

    public void UpdateQuestPanelDesc(Quest quest)
    {
        questPanel.UpdateQuestDesc(quest);
    }
}
