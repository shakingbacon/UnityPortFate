using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class NPCInfo {

    public string npcName;
    public int npcID;
    public int npcQuestID;

    public string[] defaultText;
    public string[] questAskText;
    public string[] questAcceptText;
    public string[] questDeclineText;
    public string[] questInProgressText;
    public string[] questCompletionText; 

    [JsonConstructor]
    public NPCInfo(string name, int npcid, int questid, string[] defualt, string[] ask, string[] accept, string[] decline, string[] inprog, string[] complete)
    {
        npcName = name;
        npcID = npcid;
        npcQuestID = questid;
        defaultText = defualt;
        questAskText = ask;
        questAcceptText = accept;
        questDeclineText = decline;
        questInProgressText = inprog;
        questCompletionText = complete;
    }

}
