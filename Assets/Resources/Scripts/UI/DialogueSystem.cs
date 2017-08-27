using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    public NPCInfo CurrentNPC { get; set; }
    //public string npcName;
    public List<string> dialogueLines = new List<string>();
    public bool canContinueDialouge = true;

    Text dialogueText, nameText;
    int dialogueIndex;
    public bool ShowQuest { get; set; } // show a quest at last dialouge
    //int questID;

	void Awake()
    {
        dialogueText = dialoguePanel.transform.FindChild("Dialogue Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("NPC Name").GetComponentInChildren<Text>();
        dialoguePanel.SetActive(false);
        Instance = dialoguePanel.GetComponent<DialogueSystem>();
	}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ContinueDialogue();
        }
    }

    public void AddNewNPC(NPCInfo npc, string[] lines, bool showquest)
    {
        SoundDatabase.PlaySound(18);
        ShowQuest = showquest;
        CurrentNPC = npc;
        MakeDialouge(lines);
    }

    public void MakeDialouge(string[] lines)
    {
        PlayerMovement.cantMove = true;
        canContinueDialouge = true;
        SetDialouge(lines);
        CreateDialogue();
    }

    void SetDialouge(string[] lines)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
    }

    void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = CurrentNPC.npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (canContinueDialouge)
        {
            SoundDatabase.PlaySound(34);
            if (dialogueIndex < dialogueLines.Count - 1)
            {
                dialogueIndex += 1;
                string text = dialogueLines[dialogueIndex];
                dialogueText.text = text;
                if (ShowQuest && dialogueLines.Count - 1 == dialogueIndex && CurrentNPC.npcQuestID != -1)
                {
                    PlayerQuestController.Instance.CreateQuestAgreement(CurrentNPC.npcQuestID);
                    canContinueDialouge = false;
                }
            }
            else
            {
                PlayerMovement.cantMove = false;
                dialoguePanel.SetActive(false);
            }
        }
    }
}
