using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour {

    void OnTriggerEnter2D()
    {
        Battle.SetupBattle(new Enemy(EnemyDatabase.enemies[Random.Range(0, 4)]));
    }
}
