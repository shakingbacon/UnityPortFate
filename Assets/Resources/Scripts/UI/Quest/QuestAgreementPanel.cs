using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestAgreementPanel : MonoBehaviour {
    public GameObject questAgreementPanel;
    public Text questName, questDetails, questRewards;
    public Quest CurrentQuest { get; set; }

    public void Accept()
    {
        SoundDatabase.PlaySound(9);
        Destroy(gameObject);
        DialogueSystem.Instance.MakeDialouge(QuestDatabase.Instance.GetQuest(DialogueSystem.Instance.CurrentDialogue.optionID).AcceptText);
        DialogueSystem.Instance.ShowQuest = false;
        UIEventHandler.QuestAccepted(CurrentQuest);
        EventNotifier.Instance.MakeEventNotifier(string.Format("Quest Accepted: {0}", CurrentQuest.Name));
    }

    public void Decline()
    {
        SoundDatabase.PlaySound(21);
        Destroy(gameObject);
        DialogueSystem.Instance.ShowQuest = false;
        DialogueSystem.Instance.MakeDialouge(QuestDatabase.Instance.GetQuest(DialogueSystem.Instance.CurrentDialogue.optionID).DeclineText);
    }



}
