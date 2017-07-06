using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public string npcName;
    [Multiline]
    public string[] dialogueText;

	void OnTriggerEnter2D()
    {
        if (DialogueSystem.Instance.npcName != npcName)
        {
            DialogueSystem.Instance.AddNewDialogue(dialogueText, npcName);
        }
    }
}
