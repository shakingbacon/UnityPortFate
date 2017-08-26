using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour {

    public Text questDesc, questName, questNPC, questMemory;

    public void UpdateQuestDesc(Quest quest)
    {
        questName.text = quest.questName;
        questNPC.text = "NPC: " + quest.questNPC;
        questDesc.text = quest.questGoal;
        questMemory.text = quest.questMemory;
    }

}


