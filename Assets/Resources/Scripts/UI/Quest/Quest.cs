using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Quest {

    public string questName;
    public string questNPC;
    public int questID;
    // Details
    public string[] questGoals;
    public string questReward;
    public string questMemory;

    public bool QuestCompleted { get; set; }

    // Goals each index should be 1 goal
    public int[] questMonsterNeeds;
    public int[] questAmountNeeds;
    public int[] questAmountDids;
    public int[] questObjectiveTypes;

    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public QuestType questType;


    public enum ObjectiveType
    {
        Monster = 0,
        Item = 1
    }

    public enum QuestType
    {
        Slay,
        Delivery,
        Conversation
    }

    [JsonConstructor]
    public Quest(string name, int id, string[] goal, string reward,  string memory, int[] kill, int[] amountneed, int[] objectivetype, QuestType type)
    {
        this.questName = name;
        this.questID = id;
        this.questGoals = goal;
        this.questMemory = memory;
        this.questReward = reward;
        questMonsterNeeds = kill;
        questAmountNeeds = amountneed;
        questObjectiveTypes = objectivetype;
        this.questType = type;
        QuestCompleted = false;
    }

}
