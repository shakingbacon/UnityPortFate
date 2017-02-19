using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour {
    public List<Enemy> enemies = new List<Enemy>();
    // Use this for initialization
    void Start () {
        enemies.Add(new Enemy("Alec", 0, 325,130, 70, 70, 20, 40, 95, 5, 5, 50, 12));
        enemies.Add(new Enemy("Sungmin", 1, 425, 500, 50, 90, 25, 25, 95, 5, 4, 50, 14));
        enemies.Add(new Enemy("Kaelan", 2, 450, 110, 70, 100, 40, 10, 95, 5, 4, 60, 16));
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

}
