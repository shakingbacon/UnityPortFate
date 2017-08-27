using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestController : MonoBehaviour
{

    public static PlayerQuestController Instance { get; set; }
    public QuestPanel questPanel;
    public QuestUI questUI;

    public QuestAgreementPanel questAgreementPanelPrefab;

    public List<Quest> completedQuests = new List<Quest>();
    public List<Quest> inProgressQuests = new List<Quest>();

    void Start()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        CombatEvents.OnEnemyDeath += CheckQuestNeedThisKill;
    }


    public void CreateQuestAgreement(int id)
    {
        QuestAgreementPanel agreementPanel = Instantiate(questAgreementPanelPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);
        agreementPanel.CurrentQuest = QuestDatabase.Instance.GetQuest(id);
        agreementPanel.questName.text = agreementPanel.CurrentQuest.questName;
        // 
        agreementPanel.questDetails.text = "";
        foreach (string goal in agreementPanel.CurrentQuest.questGoals)
        {
            //print(goal);
            agreementPanel.questDetails.text += goal + "\n";
        }
        agreementPanel.questRewards.text = agreementPanel.CurrentQuest.questReward;
        agreementPanel.transform.localPosition = new Vector3(0, 60, 0);
        agreementPanel.transform.localScale = new Vector3(1, 1, 1);
    }

    public void QuestCompleted(int id)
    {
        Quest quest = inProgressQuests.Find(aQuest => aQuest.questID == id);
        foreach (Quest asd in inProgressQuests) { print(asd.questName); }
        inProgressQuests.Remove(quest);
        completedQuests.Add(quest);
        foreach (Transform child in questPanel.inProgressContent.transform)
        {
            if (child.GetComponent<QuestUIContainer>().quest.questID == id)
            {
                child.SetParent(questPanel.completedContent.transform);
                break;
            }
        }
    }

    public bool HasQuestCompleted(int id)
    {
        return completedQuests.Exists(aQuest => aQuest.questID == id);
    }

    public bool HasQuestInProgress(int id)
    {
        return inProgressQuests.Exists(aQuest => aQuest.questID == id);
    }

    //public bool HasCompletedQuest(int id)
    //{
    //    return completedQuests.Exists(anID => anID == id);
    //}

    public void UpdateQuestPanelDesc(Quest quest)
    {
        questPanel.UpdateQuestDesc(quest);
    }

    // Quest Handler

    public void CheckQuestNeedThisKill(IEnemy enemy)
    {
        foreach (Quest quest in inProgressQuests)
        {
            print(quest.questName);
            int i = 0;
            for (; i < quest.questObjectiveTypes.Length; i++)
            {
                if ((Quest.ObjectiveType)quest.questObjectiveTypes[i] == Quest.ObjectiveType.Monster)
                {
                    quest.questAmountDids[i] += 1;
                    UpdateQuestPanelDesc(questPanel.CurrentQuest);
                }
            }
            IsQuestCompleted(quest);
        }
    }
    
    public void IsQuestCompleted(Quest quest)
    {
        int i = 0;
        for (;i < quest.questAmountNeeds.Length; i++)
        {
            if (quest.questAmountNeeds[i] > quest.questAmountDids[i])
            {
                quest.QuestCompleted = false;
                return;
            }
        }
        quest.QuestCompleted = true;
        return;
    }

}
