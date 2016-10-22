using UnityEngine;
using System.Collections;

[System.Serializable]

public class Job {
    public string jobName;
    public int jobID;

    
    public Job(string name, int id)
    {
        jobName = name;
        jobID = id;

    }
}
