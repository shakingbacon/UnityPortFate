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
        if (DialogueSystem.Instance.CurrentNPC == null || !DialogueSystem.Instance.dialoguePanel.activeInHierarchy)
        {
            DialogueSystem.Instance.CurrentNPC = npcInfo;
            DialogueSystem.Instance.ShowDialogueOptions(npcInfo);
        }
    }
}
