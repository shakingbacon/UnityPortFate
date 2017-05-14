using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusEffects {
    public List<Status> statusList = new List<Status>();

    public StatusEffects()
    {
        statusList = new List<Status>();
    }

    public StatusEffects(StatusEffects copy)
    {
        foreach (Status status in copy.statusList)
        {
            statusList.Add(status);
        }
    }

    public void AddNewStatus(int id)
    {
        statusList.Add(new Status(StatusDatabase.GetStatus(id)));
    }

    public void AddNewStatusAndSet(int id, int chance)
    {
        AddNewStatus(id);
        SetStatusChance(id, chance);
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
