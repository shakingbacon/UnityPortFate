using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Quest {

    public string questName;
    public string questNPC;
    public int questID;

    public string questGoal;
    public string questMemory;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public QuestType questType;
    
    public enum QuestType
    {
        Slay,
        Delivery,
        Conversation
    }

    [JsonConstructor]
    public Quest(string name, int id, string goal, string memory, QuestType type)
    {
        this.questName = name;
        this.questID = id;
        this.questGoal = goal;
        this.questMemory = memory;
        this.questType = type;
    }

}
