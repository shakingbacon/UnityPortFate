using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable {
    public string npcName;
    [Multiline]
    public string[] dialogueText;

    public override void Interact()
    {
        if (DialogueSystem.Instance.npcName != npcName)
        {
            DialogueSystem.Instance.AddNewDialogue(dialogueText, npcName);
        }
    }
}
