using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUIContainer : MonoBehaviour {

    public Quest quest;
    public Image questIcon;
    public Text questName;

    public void SetQuest(Quest quest)
    {
        this.quest = quest;
        questName.text = quest.questName;
    }

    public void UpdateClick()
    {
        PlayerQuestController.Instance.questPanel.CurrentQuest = quest;
        PlayerQuestController.Instance.UpdateQuestPanelDesc(quest);
    }
	
}
