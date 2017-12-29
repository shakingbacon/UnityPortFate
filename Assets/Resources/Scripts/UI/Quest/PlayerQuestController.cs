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
        agreementPanel.questName.text = agreementPanel.CurrentQuest.Name;
        // 
        agreementPanel.questDetails.text = "";
        foreach (QuestGoal goal in agreementPanel.CurrentQuest.Goals)
        {
            //print(goal);
            agreementPanel.questDetails.text += goal.Description + "\n";
        }
        agreementPanel.questRewards.text = agreementPanel.CurrentQuest.Reward;
        agreementPanel.transform.localPosition = new Vector3(0, 60, 0);
        agreementPanel.transform.localScale = new Vector3(1, 1, 1);
    }

    public void QuestCompleted(int id)
    {
        Quest quest = inProgressQuests.Find(aQuest => aQuest.ID == id);
        //foreach (Quest asd in inProgressQuests) { print(asd.Name); }
        inProgressQuests.Remove(quest);
        completedQuests.Add(quest);
        foreach (Transform child in questPanel.inProgressContent.transform)
        {
            if (child.GetComponent<QuestUIContainer>().quest.ID == id)
            {
                child.SetParent(questPanel.completedContent.transform);
                break;
            }
        }
        EventNotifier.Instance.MakeEventNotifier(string.Format("Quest Completed: {0}", quest.Name));
    }

    public bool HasQuestCompleted(int id)
    {
        return completedQuests.Exists(aQuest => aQuest.ID == id);
    }

    public bool HasQuestInProgress(int id)
    {
        return inProgressQuests.Exists(aQuest => aQuest.ID == id);
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

    public void CheckQuestNeedThisKill(Enemy enemy)
    {
        foreach (Quest quest in inProgressQuests)
        {
            foreach(QuestGoal goal in quest.Goals)
            {
                if (goal.Type == QuestGoal.ObjectiveType.Monster)
                {
                    if (enemy.ID == goal.ID)
                    {
                        goal.AmountDid++;
                        UpdateQuestPanelDesc(questPanel.CurrentQuest);
                        IsQuestCompleted(quest);
                    }
                }
            }

            //for (; i < quest.questObjectiveTypes.Length; i++)
            //{
            //    if ((Quest.ObjectiveType)quest.questObjectiveTypes[i] == Quest.ObjectiveType.Monster)
            //    {
            //        quest.questAmountDids[i] += 1;
            //        UpdateQuestPanelDesc(questPanel.CurrentQuest);
            //    }
            //}
        }
    }
    
    public void IsQuestCompleted(Quest quest)
    {
        foreach(QuestGoal goal in quest.Goals)
        {
            if (goal.AmountDid < goal.AmountNeed)
            {
                quest.Completed = false;
                return;
            }
        }
        quest.Completed = true;
    }

}
