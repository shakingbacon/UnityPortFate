using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Interactable {

    public string Name { get; set; }
    public List<Quest> Quests { get; set; }

    // The default text to talk with an npc
    public List<string> TalkText { get; set; }

    // public Shop Shop { get; set; }

    protected virtual void Start()
    {
        interactString = "Talk";
        GiveLife();
    }

    public override void LeftInteractionArea(Collider2D player)
    {
        base.LeftInteractionArea(player);
        DialogueSystem.Instance.CurrentNPC = null;
    }

    public override void Interact()
    {
        if (DialogueSystem.Instance.CurrentNPC == null || !DialogueSystem.Instance.dialoguePanel.activeInHierarchy)
        {
            DialogueSystem.Instance.CurrentNPC = this;
            DialogueSystem.Instance.ShowDialogueOptions(this);
        }
    }


    public virtual void GiveLife()
    {
        Quests = new List<Quest>();
        TalkText = new List<string>();
    }
}
