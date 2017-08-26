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
}
