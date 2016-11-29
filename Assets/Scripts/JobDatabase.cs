using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class JobDatabase : MonoBehaviour {
    public List<Job> jobs = new List<Job>();

	// Use this for initialization
	void Start () {
        jobs.Add(new Job("Mage", 0));
        jobs.Add(new Job("Rouge", 1));
        jobs.Add(new Job("Warrior", 2));
        //jobs.Add(new Job("Freelancer", 3));
    }
	
    
}
