//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Newtonsoft.Json;

//public class QuestDatabase : MonoBehaviour
//{

//    public static QuestDatabase Instance { get; set; }
//    private List<Quest> Quests { get; set; }

//    // Use this for initialization
//    void Awake()
//    {
//        if (Instance != null && Instance != this)
//        {
//            Destroy(gameObject);
//        }
//        else
//        {
//            Instance = this;
//        }
//        BuildDatabase();
//    }

//    public Quest GetQuest(int id)
//    {
//        foreach (Quest quest in Quests)
//        {
//            if (quest.nam == id)
//            {
//                return quest;
//            }
//        }
//        Debug.LogWarning("COULDNT FIND quest WITH ID" + id);
//        return null;
//    }

//    private void BuildDatabase()
//    {
//        Quests = new List<Quest>();
        
//        // 


//        //Quests = JsonConvert.DeserializeObject<List<Quest>>(Resources.Load<TextAsset>("JSON/Quests").ToString());
//    }





//}
