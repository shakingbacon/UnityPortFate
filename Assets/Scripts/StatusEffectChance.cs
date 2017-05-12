using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffects {
    public List<Status> statusList = new List<Status>();
    
    public StatusEffects()
    {
        statusList.Add(new Status("Burn", 0));
        statusList.Add(new Status("Paralyze", 1));
        statusList.Add(new Status("Bleed", 2));
        statusList.Add(new Status("Poison", 3));
        statusList.Add(new Status("Cripple", 4));
        statusList.Add(new Status("Blind", 5));
        statusList.Add(new Status("Confuse", 6));
        statusList.Add(new Status("Curse", 7));
    }

    public StatusEffects(StatusEffects copy)
    {
        statusList.Add(new Status("Burn", 0));
        statusList.Add(new Status("Paralyze", 1));
        statusList.Add(new Status("Bleed", 2));
        statusList.Add(new Status("Poison", 3));
        statusList.Add(new Status("Cripple", 4));
        statusList.Add(new Status("Blind", 5));
        statusList.Add(new Status("Confuse", 6));
        statusList.Add(new Status("Curse", 7));
        foreach (Status status in statusList)
        {
            SetStatusChance(status.statusID, copy.GetStatusChance(status.statusID));
        }
    }

    public Status GetStatus(int id) 
    {
        return statusList.Find(anID => anID.statusID == id);
    }

    public void SetStatusChance(int id, int chance)
    {
        GetStatus(id).statusChance = chance;
    }

    public int GetStatusChance(int id)
    {
        return GetStatus(id).statusChance;
    }

    public void AddStatusChance(int id, int chance)
    {
        GetStatus(id).statusChance += chance;
    }

    public void AddPercentStatusChance(int id, int percent)
    {
        GetStatus(id).statusChance = (int)(GetStatus(id).statusChance * (1f + (percent / 100f)));
    }

}
