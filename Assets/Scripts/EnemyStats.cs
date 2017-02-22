using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    EnemyDatabase enemyDatabase;
    public Enemy enemy;

    void Start()
    {
        enemyDatabase = GameObject.FindGameObjectWithTag("Enemy Database").GetComponent<EnemyDatabase>();
    }



   public void GetEnemy(int id)
   {
   Enemy returnEnemy = new Enemy();
   for (int j = 0; j < enemyDatabase.enemies.Count; j += 1)
   {
   if (enemyDatabase.enemies[j].enemyID == id)
   {
   returnEnemy = enemyDatabase.enemies[j];
   break;
   }
   }
   enemy = returnEnemy;
   }
}
