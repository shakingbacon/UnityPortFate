using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SkillDatabase : MonoBehaviour {

    public static SkillDatabase Instance { get; set; }
    private List<Skill> Skills { get; set; }

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
        Skills = JsonConvert.DeserializeObject<List<Skill>>(Resources.Load<TextAsset>("JSON/Skills").ToString());
    }

    public Skill GetSkill(string skillName)
    {
        foreach (Skill skill in Skills)
        {
            if (skill.skillName == skillName)
            {
                return skill;
            }
        }
        Debug.LogWarning("COULDNT FIND ITEM: " + skillName);
        return null;
    }

    public Skill GetSkill(int id)
    {
        foreach (Skill skill in Skills)
        {
            if (skill.skillID == id)
            {
                return skill;
            }
        }
        Debug.LogWarning("COULDNT FIND ITEM WITH ID" + id);
        return null;
    }
}
