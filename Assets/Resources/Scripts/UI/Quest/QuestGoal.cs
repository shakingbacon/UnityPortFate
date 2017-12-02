using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;



public class QuestGoal
{
    public ObjectiveType Type { get; set; }
    public int ID { get; set; }
    public int AmountNeed { get; set; }
    public int AmountDid { get; set; }
    public string Description { get; set; }

    public enum ObjectiveType
    {
        Monster,
        Item
    }

    public QuestGoal(int type, int id, int need, string desc)
    {
        Type = (ObjectiveType)type;
        ID = id;
        AmountNeed = need;
        AmountDid = 0;
        Description = desc;
    }

}
