using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour {

    public Text questDesc, questName, questNPC, questMemory, questRewards;
    public Quest CurrentQuest { get; set; }

    public Button inProgressButton, completedButton;
    public GameObject inProgressScroll, completedScroll, inProgressContent, completedContent;

    bool showingInprogressScroll = true;

    void Start()
    {
        questNPC.text = "";
        questName.text = "";
        questDesc.text = "";
        questMemory.text = "";
        questRewards.text = "";
        inProgressScroll.SetActive(true);
        completedScroll.SetActive(false);
    }

    public void UpdateQuestDesc(Quest quest)
    {
        if (quest != null)
        {
            questDesc.text = "";
            questName.text = quest.questName;
            questNPC.text = "NPC: " + quest.questNPC;
            int i = 0;
            foreach (string goal in quest.questGoals)
            {
                questDesc.text += goal + "\n";
                if ((Quest.ObjectiveType)quest.questObjectiveTypes[i] == Quest.ObjectiveType.Monster)
                {
                    questDesc.text += string.Format("{0} / {1}\n", quest.questAmountDids[i], quest.questAmountNeeds[i]);
                }
                i++;
            }
            questRewards.text = quest.questReward;
            questMemory.text = quest.questMemory;
        }
    }

    public void inProgressButtonClick()
    {
        if (!showingInprogressScroll)
        {
            SoundDatabase.PlaySound(18);
            showingInprogressScroll = !showingInprogressScroll;
            inProgressScroll.SetActive(true);
            completedScroll.SetActive(false);
        }
    }

    public void completedButtonClick()
    {
        if (showingInprogressScroll)
        {
            SoundDatabase.PlaySound(18);
            completedScroll.SetActive(true);
            inProgressScroll.SetActive(false);
            showingInprogressScroll = !showingInprogressScroll;
        }
    }

}


