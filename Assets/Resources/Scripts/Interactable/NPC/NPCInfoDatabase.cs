using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class NPCInfoDatabase : MonoBehaviour {

    public static NPCInfoDatabase Instance { get; set; }
    private List<NPCInfo> NPCInfos { get; set; }

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
        NPCInfos = JsonConvert.DeserializeObject<List<NPCInfo>>(Resources.Load<TextAsset>("JSON/NPCInfos").ToString());
    }

    public NPCInfo GetNPCInfo(int id)
    {
        foreach (NPCInfo info in NPCInfos)
        {
            if (info.npcID == id)
            {
                return info;
            }
        }
        Debug.LogWarning("COULDNT FIND npcinfo WITH ID" + id);
        return null;
    }
}
