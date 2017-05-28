using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase : MonoBehaviour {
    public static List<Enemy> enemies = new List<Enemy>();
    // Use this for initialization
    void Start () {
        // hp, mp, atk, matk, arm, res, hit, dodge, crit, exp ,loot
        enemies.Add(new Enemy("Alec", 0,
            350, 130, 60, 70, 20, 40, 95, 5, 5, 225, 15, 60));
        enemies.Add(new Enemy("Sungmin", 1, 
            450, 500, 50, 90, 25, 25, 95, 5, 4, 225, 14, 65));
        enemies.Add(new Enemy("Kaelan", 2,
            475, 110, 60, 100, 40, 10, 95, 5, 4, 225, 16, 75));
        enemies.Add(new Enemy("Gator", 3,
            275, 100, 84, 100, 40, 10, 95, 5, 4, 225, 22, 50));
        enemies.Add(new Enemy("Weak Gator", 4,
            100, 50, 30, 0, 10, 10, 200, 5, 4, 225, 8, 25));
        enemies.Add(new Enemy("火鸟", 5,
            1000, 600, 220, 150, 60, 70, 80, 8, 8, 200, 100));
        enemies.Add(new Enemy("Aneal", 6,
            900, 200, 180, 70, 50, 40, 95, 5, 5, 90, 28));
        enemies.Add(new Enemy("Avery", 7,
            1400, 50, 140, 30, 20, 20, 95, 5, 5, 150, 19));
        enemies.Add(new Enemy("Ryan", 8,
            600, 10, 300, 11, -70, -70, 110, 40, 20, 100, 55));
        enemies.Add(new Enemy("Tina", 9,
            800, 600, 40, 275, 30, 60, 100, 4, 4, 100, 30));
        enemies.Add(new Enemy("Clean Booga", 10,
            2250, 500, 325, 225, 70, 70, 85, 8, 8, 300, 150));
        enemies.Add(new Enemy("Alicky", 10, 
            1700, 500, 375, 375, 80, 100, 90, 5, 5, 125, 100));
        enemies.Add(new Enemy("Sunger Munger", 11,
            1900, 1000, 140, 425, 80, 150, 92, 5, 5, 135, 125));
        enemies.Add(new Enemy("Brownitron", 12,
            2400, 400, 180, 125, 110, 200, 87, 5, 4, 150, 150));
        enemies.Add(new Enemy("Jihoon", 13,
            1000, 7, 250, 10, -100, -100, 80, 90, 0, 175, 125));
        enemies.Add(new Enemy("Yoonho", 14,
            1500, 2000, 70, 400, 135, 160, 85, 10, 6, 200, 100));
        enemies.Add(new Enemy("Minji", 15,
            2050, 650, 400, 200, 125, 175, 95, 7, 7, 250, 200));
        enemies.Add(new Enemy("Clara", 16,
            1500, 300, 500, 278, 95, 125, 85, 11, 11, 200, 250));
        enemies.Add(new Enemy("Greasy Avery", 17,
            3250, 500, 275, 100, 70, 90, 95, 5, 5, 300, 225));
        enemies.Add(new Enemy("Michael", 18,
            1750, 600, 225, 125, 175, 125, 80, 10, 10, 200, 250));
        enemies.Add(new Enemy("Clavery", 19,
            3750, 400, 375, 300, 120, 120, 75, 17, 16, 500, 500));
        enemies.Add(new Enemy("La Lucha Libre", 20,
            3000, 0, 800, 10, -300, -300, 150, 60, 75, 400, 150));
        enemies.Add(new Enemy("Dyonghae", 21,
            6800, 4000, 400, 1200, 400, 750, 95, 5, 5, 200, 300));
        enemies.Add(new Enemy("Greasy Booga", 22,
            7600, 1200, 800, 600, 400, 400, 85, 20, 20, 500, 300));
        enemies.Add(new Enemy("Flower Minji", 23,
            7000, 1500, 550, 500, 475, 325, 90, 10, 10, 450, 450));
        enemies.Add(new Enemy("Booga's Cat", 24,
            4000, 800, 1000, 750, 0, 0, 125, 65, 30, 1750, 1000));
        enemies.Add(new Enemy("King Booga", 25,
            19369, 8000, 1350, 1000, 700, 1000, 100, 20, 20, 2000, 2500));


    }

    //public static void AddStats()
    //{
    //    for (int k = 0; k < enemies.Count; k += 1)
    //    {
    //        Enemy e = enemies[k];
    //        switch (e.enemyID)
    //        {
    //            case 0:
    //                {
    //                    e.maxHealth.baseAmount = 350; e.maxMana.baseAmount = 130; e.physAtk.baseAmount = 60; e.magicAtk.baseAmount = 70;
    //                    e.armor.baseAmount = 20; e.resist.baseAmount = 40; e.hitChance.baseAmount = 95; e.critChance.baseAmount = 5;
    //e.experience = 15; e.cash = 60; break;}
    //        }
    //    }

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
