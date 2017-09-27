using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    public GameObject monster;
    public bool respawn;
    public float spawnDelay;
    private float currentTime;
    private bool spawning;



	// Use this for initialization
	void Start () {
        Spawn();
        currentTime = spawnDelay;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Spawn();
            }
        }
	}

    public void Respawn()
    {
        spawning = true;
        currentTime = spawnDelay;
    }

    public void Spawn()
    {
        GameObject instance = Instantiate(monster, transform.position, Quaternion.identity);
        instance.transform.SetParent(CurrentMap.Instance.enemies);
        Enemy enemy = instance.GetComponentInChildren<Enemy>();
        enemy.Spawner = this;
        spawning = false;
    }
}
