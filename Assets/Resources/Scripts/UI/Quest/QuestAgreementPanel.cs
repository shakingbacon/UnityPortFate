using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestAgreementPanel : MonoBehaviour {
    public GameObject questAgreementPanel;
    public Text questName, questDetails;
    public Quest CurrentQuest { get; set; }

    public void Accept()
    {
        SoundDatabase.PlaySound(9);
        gameObject.SetActive(false);
        DialogueSystem.Instance.MakeDialouge(DialogueSystem.Instance.CurrentNPC.questAcceptText);
        UIEventHandler.QuestAccepted(CurrentQuest);
    }

    public void Decline()
    {
        SoundDatabase.PlaySound(21);
        gameObject.SetActive(false);
        DialogueSystem.Instance.MakeDialouge(DialogueSystem.Instance.CurrentNPC.questDeclineText);
    }



}
