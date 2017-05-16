using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffects {
    public List<Skill> statusList = new List<Skill>();
    
    public StatusEffects()
    {
        statusList = new List<Skill>();
    }

    public StatusEffects(StatusEffects copy)
    {
        foreach (Skill status in copy.statusList)
        {
            statusList.Add(status);
        }
    }

    public void ResetAll()
    {
        statusList = new List<Skill>();
    }

    public void AddNewStatus(int id)
    {
        statusList.Add(new Skill(SkillDatabase.GetSkill(id)));
    }

    public void AddNewStatusAndSet(int id, int chance)
    {
        AddNewStatus(id);
        SetStatusChance(id, chance);
    }

    public Skill GetStatus(int id) 
    {
        return statusList.Find(anID => anID.skillID == id);
    }

    public void SetStatusChance(int id, int chance)
    {
        GetStatus(id).skillHitChance = chance;
    }

    public int GetStatusChance(int id)
    {
        return GetStatus(id).skillHitChance;
    }

    public void AddStatusChance(int id, int chance)
    {
        GetStatus(id).skillHitChance += chance;
    }

    public void AddPercentStatusChance(int id, int percent)
    {
        GetStatus(id).skillHitChance = (int)(GetStatus(id).skillHitChance * (1f + (percent / 100f)));
    }

}
