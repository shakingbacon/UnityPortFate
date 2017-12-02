using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class QuestDatabase : MonoBehaviour {

    public static QuestDatabase Instance { get; set; }
    private List<Quest> Quests { get; set; }

    // Use this for initialization
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        BuildDatabase();
    }

    public Quest GetQuest(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }
        Debug.LogWarning("COULDNT FIND quest WITH ID" + id);
        return null;
    }

    public void GiveQuestReward(int id)
    {
        switch (id)
        {
            case 0: { UIEventHandler.MoneyAdded(100); break; }
        }
    }

    private void BuildDatabase()
    {
        Quests = new List<Quest>();
        Quests.Add(new Quest("Slay the Gators", "Clean Booga", 0,
        new List<string>()
        {
            "Hey, I need you to kill those Gators.", "There should be a lot on the right side.", "Compelete this quest and I'll reward you."
        },
        new List<string>()
        {
            "Alright then, let me teach you some basics.", "Press the I key to open your inventory. You can equip items from here.",
            "You should equip the weapon in your inventory.", "While holding a weapon, press the X key to perform a basic attack", "Tap repeatedly to combo!"
        },
        new List<string>()
        {
            "You are a fucking retard.", "Do you not want to progress in this game?"
        },
        new List<string>()
        {
            "Go kill the Gators then come back to me."
        },
        new List<string>()
        {
            "Nice job!", "Here's your reward"
        },
        "100 Gold",
        "Clean Booga wants me to slay the Gators around here.",
        new List<QuestGoal>()
        {
            new QuestGoal(0, 0, 5, "Slay 5 Gators")
        }, 
        Quest.QuestType.Slay));
        // 


        //Quests = JsonConvert.DeserializeObject<List<Quest>>(Resources.Load<TextAsset>("JSON/Quests").ToString());
    }





}
