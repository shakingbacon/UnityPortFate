using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class JobDatabase : MonoBehaviour {
    public static List<Job> jobs = new List<Job>();

	// Use this for initialization
	void Start () {
        jobs.Add(new Job("", -1));
        jobs.Add(new Job("Mage", 0));
        jobs.Add(new Job("Rouge", 1));
        jobs.Add(new Job("Warrior", 2));
        //jobs.Add(new Job("Freelancer", 3));
    }
	
    public static Job GetJob(int id)
    {
        for (int i = 0; i < jobs.Count; i += 1)
        {
            if (jobs[i].jobID == 0)
            {
                return jobs[i];
            }
        }
        return jobs[0];
    }
    
}
