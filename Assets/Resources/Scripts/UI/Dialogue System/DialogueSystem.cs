using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;

    public NPC CurrentNPC { get; set; }
    public Quest CurrentQuest { get; set; }


    //public string npcName;
    public List<string> dialogueLines = new List<string>();
    public bool canContinueDialouge = true;

    Text dialogueText, nameText;
    public GameObject optionSelectPanel, continueArrow;
    DialogueSystemOptionObject dialogueSystemOptionObjectPrefab;
    DialogueSystemOptionSelectController optionController;

    int dialogueIndex;
    public bool ShowQuest { get; set; } // show a quest at last dialouge
    //int questID;

	void Start()
    {
        continueArrow = dialoguePanel.transform.FindChild("Continue").gameObject;
        dialogueSystemOptionObjectPrefab = Resources.Load<DialogueSystemOptionObject>("Prefabs/UI/Dialogue Panel/Option Select");
        optionSelectPanel = dialoguePanel.transform.FindChild("Option Selection Panel").gameObject;
        dialogueText = dialoguePanel.transform.FindChild("Dialogue Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("NPC Name").GetComponentInChildren<Text>();
        dialoguePanel.SetActive(false);
        Instance = dialoguePanel.GetComponent<DialogueSystem>();
        optionController = GetComponent<DialogueSystemOptionSelectController>();
    }

    void Update()
    {
        if (continueArrow.activeInHierarchy && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Z)))
        {
            ContinueDialogue();
        }
    }

    public void ShowDialogueOptions(NPC npc)
    {
        PlayerMovement.cantMove = true;
        continueArrow.SetActive(false);
        DestroyAllOptions();
        CurrentNPC = npc;
        dialoguePanel.SetActive(true);
        dialogueText.gameObject.SetActive(false);
        optionSelectPanel.SetActive(true);

        foreach(Quest quest in npc.Quests)
        {
            DialogueSystemOptionObject optionObject = Instantiate(dialogueSystemOptionObjectPrefab, optionSelectPanel.transform);
            optionObject.UpdateText(quest);
            
        }
        //foreach (DialogueOption option in npc.dialogueOptions)
        //{
        //    DialogueSystemOptionObject optionObject = Instantiate(dialogueSystemOptionObjectPrefab, optionSelectPanel.transform);
        //    optionObject.option = option;
        //    optionObject.transform.localScale = new Vector3(1, 1, 1);
        //    optionObject.UpdateText();
        //}
        // talk dialogue option
        DialogueSystemOptionObject talkDialogue = Instantiate(dialogueSystemOptionObjectPrefab, optionSelectPanel.transform);
        talkDialogue.SetAsTalkOption();
        talkDialogue.transform.localScale = new Vector3(1, 1, 1);
        // exit dialogue option
        DialogueSystemOptionObject exitDialogue = Instantiate(dialogueSystemOptionObjectPrefab, optionSelectPanel.transform);
        exitDialogue.SetAsExitOption();
        exitDialogue.transform.localScale = new Vector3(1, 1, 1);
        optionController.StartOptionSelect();
    }

    public void DestroyAllOptions()
    {
        foreach (Transform child in optionSelectPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void MakeDialouge(List<string> lines, bool giveQuest = false)
    {
        continueArrow.SetActive(true);
        ShowQuest = giveQuest;
        canContinueDialouge = true;
        SetDialouge(lines);
        CreateDialogue();
    }

    void SetDialouge(List<string> lines)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Count);
        dialogueLines.AddRange(lines);
    }

    void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = CurrentNPC.Name;
        dialoguePanel.SetActive(true);
        optionSelectPanel.SetActive(false);
        dialogueText.gameObject.SetActive(true);
    }

    public void StartDialouge()
    {
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
                if (ShowQuest && dialogueLines.Count - 1 == dialogueIndex)
                {
                    PlayerQuestController.Instance.CreateQuestAgreement(CurrentQuest);
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
