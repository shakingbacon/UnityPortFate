using UnityEngine;
using System.Collections;

[System.Serializable]

public class Job {
    public string jobName;
    public int jobID;

    public Job()
    {
        jobName = "";
        jobID = -1;
    }

    public Job(Job job)
    {
        jobName = job.jobName;
        jobID = job.jobID;
    }

    public Job(string name, int id)
    {
        jobName = name;
        jobID = id;
    }
}
