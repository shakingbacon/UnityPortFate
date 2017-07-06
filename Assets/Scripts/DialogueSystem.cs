using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;
    public static List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    public int dialogueIndex;

	void Awake()
    {
        continueButton = dialoguePanel.transform.FindChild("Continue").GetComponent<Button>();
        continueButton.onClick.AddListener(ContinueDialogue);
        dialogueText = dialoguePanel.transform.FindChild("Dialogue Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.FindChild("NPC Name").GetComponentInChildren<Text>();
        dialoguePanel.SetActive(false);
        Instance = dialoguePanel.GetComponent<DialogueSystem>();
	}
    
    public void AddNewDialogue(string[] lines, string npcname)
    {
        SoundDatabase.PlaySound(18);
        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        npcName = npcname;
        dialogueLines.AddRange(lines);
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        SoundDatabase.PlaySound(34);
        if (dialogueIndex < dialogueLines.Count - 1 || dialogueLines.Count == 1)
        {
            dialogueIndex += 1;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            npcName = "";
        }
    }
}
