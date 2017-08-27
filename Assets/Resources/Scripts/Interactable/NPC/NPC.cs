using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {

    NPCInfo npcInfo;
    public int npcID;

    void Start()
    {
        npcInfo = NPCInfoDatabase.Instance.GetNPCInfo(npcID);
        interactString = "Talk";
    }

    //public override void EnterInteractionArea(Collider2D player)
    //{
    //}

    public override void LeftInteractionArea(Collider2D player)
    {
        base.LeftInteractionArea(player);
        DialogueSystem.Instance.CurrentNPC = null;
    }

    public override void Interact()
    {
        if (DialogueSystem.Instance.CurrentNPC == null /*|| DialogueSystem.Instance.CurrentNPC.npcName != npcName */|| !DialogueSystem.Instance.dialoguePanel.activeInHierarchy)
        {
            //if (PlayerQuestController.Instance.HasCompletedQuest(npcInfo.npcQuestID))
            //{
            //    DialogueSystem.Instance.AddNewNPC(npcInfo, npcInfo.defaultText);
            //}
            //
            if (PlayerQuestController.Instance.HasQuestInProgress(npcInfo.npcQuestID))
            {
                Quest npcQuest = PlayerQuestController.Instance.inProgressQuests.Find(aQuest => aQuest.questID == npcInfo.npcQuestID);
                if (npcQuest.QuestCompleted)
                {
                    DialogueSystem.Instance.AddNewNPC(npcInfo, npcInfo.questCompletionText, false);
                    QuestDatabase.Instance.GiveQuestReward(npcInfo.npcQuestID);
                    PlayerQuestController.Instance.QuestCompleted(npcInfo.npcQuestID);
                }
                else
                    DialogueSystem.Instance.AddNewNPC(npcInfo, npcInfo.questInProgressText, false);
            }
            else if (npcInfo.npcQuestID != -1 && !PlayerQuestController.Instance.HasQuestCompleted(npcInfo.npcQuestID))
            {
                DialogueSystem.Instance.AddNewNPC(npcInfo, npcInfo.questAskText, true);
            }
            else
            {
                DialogueSystem.Instance.AddNewNPC(npcInfo, npcInfo.defaultText, false);
            }
        }
    }
}
