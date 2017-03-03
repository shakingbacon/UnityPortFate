using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public int enemyID;
    public Sprite enemyIMG;
    //public string enemyDesc;
    public List<Stat> stats = new List<Stat>();

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int multi, int exp, int loot)
    {
        stats.Add(new Stat("HP", 4, hp));
        stats.Add(new Stat("MP", 6, mp));
        stats.Add(new Stat("Phys Atk", 8, phys));
        stats.Add(new Stat("Magic Atk", 9, mag));
        stats.Add(new Stat("Armor", 10, armor));
        stats.Add(new Stat("Resist", 11, resist));
        stats.Add(new Stat("Hit Rate", 12, hit));
        stats.Add(new Stat("Dodge Rate", 13, dodge));
        stats.Add(new Stat("Crit Rate", 14, crit));
        stats.Add(new Stat("Crit Multiplier", 15, multi));
        //stats.Add(new Stat("LV", 16, 1));
        stats.Add(new Stat("EXP", 19, exp));
        stats.Add(new Stat("Cash", 21, loot));
        /////////////
        enemyName = name;
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        //enemyDesc = desc;
    }

    public Enemy()
    {
        enemyID = -1;
    }
}
