using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour {
    public static List<Enemy> enemies = new List<Enemy>();
    // Use this for initialization
    void Start () {
        enemies.Add(new Enemy("Alec", 0, 350, 130, 60, 70, 20, 40, 95, 5, 5, 225, 12, 60));
        enemies.Add(new Enemy("Sungmin", 1, 450, 500, 50, 90, 25, 25, 95, 5, 4, 225, 14, 60));
        enemies.Add(new Enemy("Kaelan", 2, 475, 110, 60, 100, 40, 10, 95, 5, 4, 225, 16, 70));
        enemies.Add(new Enemy("Gator", 3, 275, 100, 85123, 100, 40, 10, 95, 5, 4, 225, 22, 50));
        enemies.Add(new Enemy("Weak Gator", 4, 100, 50, 30, 0, 10, 10, 200, 5, 4, 225, 0, 0));
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
        //enemies.Add(new Enemy());
    }

    public static Enemy GetEnemy(int id)
    {
        Enemy returnEnemy = new Enemy();
        for (int j = 0; j < enemies.Count; j += 1)
        {
            if (enemies[j].enemyID == id)
            {
                returnEnemy = enemies[j];
                return returnEnemy;
            }
        }
        return returnEnemy;
    }

}
