using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy {
    public string enemyName;
    public int enemyID;
    public Sprite enemyIMG;
    //public string enemyDesc;
    public int enemyHP;
    public int enemyMP;
    public int enemyPhys;
    public int enemyMagic;
    public int enemyArmor;
    public int enemyResist;
    public int enemyHit;
    public int enemyDodge;
    public int enemyCrit;
    public int enemyCritMulti;
    public int enemyLoot;
    public int enemyEXP;

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int loot, int exp)
    {
        enemyName = name;
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        //enemyDesc = desc;
        enemyHP = hp;
        enemyMP = mp;
        enemyPhys = phys;
        enemyMagic = mag;
        enemyArmor = armor;
        enemyResist = resist;
        enemyHit = hit;
        enemyDodge = dodge;
        enemyCrit = crit;
        enemyCritMulti = 225;
        enemyLoot = loot;
        enemyEXP = exp;
    }

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int multi, int loot, int exp)
    {
        enemyName = name;
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        //enemyDesc = desc;
        enemyHP = hp;
        enemyMP = mp;
        enemyPhys = phys;
        enemyMagic = mag;
        enemyArmor = armor;
        enemyResist = resist;
        enemyHit = hit;
        enemyDodge = dodge;
        enemyCrit = crit;
        enemyCritMulti = multi;
                enemyLoot = loot;
        enemyEXP = exp;
    }

    public Enemy()
    {
        enemyID = -1;
    }

}
