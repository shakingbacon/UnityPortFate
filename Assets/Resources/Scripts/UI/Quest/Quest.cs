using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Quest
{
    public string Name { get; set; }
    public string NPC { get; set; }
    // Talking
    public List<string> AskText { get; set; }
    public List<string> AcceptText { get; set; }
    public List<string> DeclineText { get; set; }
    public List<string> InProgressText { get; set; } 
    public List<string> CompleteText { get; set; }
    // Details
    public string Reward { get; set; }
    public string Memory { get; set; }

    public List<QuestGoal> Goals { get; set; }
    public bool Completed { get; set; }

    public QuestType Type { get; set; }

    public enum QuestType
    {
        Slay,
        Delivery,
        Conversation
    }
    //public string questName;
    //public string questNPC;
    //public int questID;
    //// Talking
    //public string[] questAskText;
    //public string[] questAcceptText;
    //public string[] questDeclineText;
    //public string[] questInProgressText;
    //public string[] questCompletionText;
    //// Details
    //public string[] questDescriptions;
    //public string questReward;
    //public string questMemory;

    //public bool QuestCompleted { get; set; }

    //// Goals each index should be 1 goal
    ////public int[] questMonsterNeeds;
    ////public int[] questAmountNeeds;
    ////public int[] questAmountDids;
    ////public int[] questObjectiveTypes;
    //public List<QuestGoal> questGoals = new List<QuestGoal>();


    //[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    //public QuestType questType;


    //[JsonConstructor]
    public Quest(QuestType type, string name, string npc, List<string> ask, List<string> accept, List<string> decline, List<string> inprog, List<string>complete,
        string reward, string memory, List<QuestGoal> goals)
    {
        Name = name;
        NPC = npc;
        AskText = ask;
        AcceptText = accept;
        DeclineText = decline;
        InProgressText = inprog;
        CompleteText = complete;
        Reward = reward;
        Memory = memory;
        Goals = goals;
        Type = type;

    }


    //public Quest(string name, int id, string[] ask, string[] accept, string[] decline, string[] inprog, string[] complete,
    //    string reward, string memory, int[][] goals, string[] desc, QuestType type) /*int[] kill, int[] amountneed, int[] objectivetype, QuestType type)*/
    //{
    //    this.questName = name;
    //    this.questID = id;

    //    questAskText = ask;
    //    questAcceptText = accept;
    //    questDeclineText = decline;
    //    questInProgressText = inprog;
    //    questCompletionText = complete;

    //    int i = 0;
    //    foreach (int[] gol in goals)
    //    {
    //        QuestGoal goal = new QuestGoal(gol[0], gol[1], gol[2], desc[i]);
    //        this.questGoals.Add(goal);
    //        i++;
    //    }
    //    this.questMemory = memory;
    //    this.questReward = reward;
    //    this.questType = type;
    //    QuestCompleted = false;
    //}

}
