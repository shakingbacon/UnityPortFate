using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterArea : MonoBehaviour {

    public int stepsEncounterMin = 400;
    public int stepsEncounterMax = 600;
    int stepsEncounter = 0;
    public int encounterChance = 30;
    public List<int> enemyList = new List<int>();
    int movement;

    void OnTriggerStay2D()
    {
        if (stepsEncounter == 0)
        {
            stepsEncounter = Random.Range(stepsEncounterMin, stepsEncounterMax+1);
        }
        movement++;
        if (stepsEncounter == movement)
        {
            if (Random.Range(0, 100) < encounterChance)
            {
                Battle.SetupBattle(new Enemy(EnemyDatabase.GetEnemy(enemyList[Random.Range(0, enemyList.Count - 1)])));
                movement = 0;
            }
        }
        if (movement == stepsEncounterMax)
        {
            movement = 0;
            stepsEncounter = 0;
        }
    }
}
