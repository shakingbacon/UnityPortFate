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

    private void BuildDatabase()
    {
        Quests = JsonConvert.DeserializeObject<List<Quest>>(Resources.Load<TextAsset>("JSON/Quests").ToString());
        foreach(Quest quest in Quests)
        {
            print(quest.questAskText[0]);
            for (int i = 0; i < quest.questMonsterNeeds.Length; i++)
            {
                quest.questAmountDids[i] = 0;
            }
        }
    }

    public Quest GetQuest(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.questID == id)
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
            case 0: { PlayerUtilities.AddCash(100); break; }
        }
    }



}
