using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemOptionObject : MonoBehaviour
{
    public Text optionText;
    public Button optionButton;

    public void UpdateText(Quest quest)
    {
        optionText.text = quest.Name;
        optionButton.onClick.AddListener(() => QuestTalk(quest));
        optionButton.onClick.AddListener(() => SoundDatabase.PlaySound(21));
    }

    void QuestTalk(Quest quest)
    {
        
        DialogueSystem.Instance.CurrentQuest = quest;
        if (PlayerQuestController.Instance.HasQuestInProgress(optionText.text))
        {
            Quest playerQuest = PlayerQuestController.Instance.inProgressQuests.Find(aQuest => aQuest.Name == optionText.text);
            if (playerQuest.Completed)
            {
                DialogueSystem.Instance.MakeDialouge(playerQuest.CompleteText);
                PlayerQuestController.Instance.QuestCompleted(quest.Name);
                //QuestDatabase.Instance.GiveQuestReward(option.optionID);
            }
            else
                DialogueSystem.Instance.MakeDialouge(playerQuest.InProgressText);
        }
        else if (!PlayerQuestController.Instance.HasQuestCompleted(quest.Name))
        {
            //print(DialogueSystem.Instance.CurrentDialogue.optionID);
            DialogueSystem.Instance.MakeDialouge(quest.AskText, true);
        }
        else
        {
            DialogueSystem.Instance.MakeDialouge(quest.CompleteText);
        }
    }

    public void SetAsTalkOption()
    {
        optionText.text = "Talk";
        optionButton.onClick.AddListener(() => DialogueSystem.Instance.MakeDialouge(DialogueSystem.Instance.CurrentNPC.TalkText));
        optionButton.onClick.AddListener(() => SoundDatabase.PlaySound(21));
    }

    public void SetAsExitOption()
    {
        optionText.text = "Close";
        optionButton.onClick.AddListener(() => DialogueSystem.Instance.dialoguePanel.SetActive(false));
        optionButton.onClick.AddListener(() => PlayerMovement.cantMove = false);
        optionButton.onClick.AddListener(() => SoundDatabase.PlaySound(21));
    }







}