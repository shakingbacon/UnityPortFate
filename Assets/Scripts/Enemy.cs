using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public int enemyID;
    public Sprite enemyIMG;
    public Stats enemyStats = new Stats();

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int multi, int exp, int loot)
    {
        enemyStats = new Stats();
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        enemyStats.mingZi = name;
        enemyStats.maxHealth.totalAmount = hp;
        enemyStats.maxMana.totalAmount = mp;
        enemyStats.physAtk.totalAmount = phys;
        enemyStats.magicAtk.totalAmount = mag;
        enemyStats.armor.totalAmount = armor;
        enemyStats.resist.totalAmount = resist;
        enemyStats.hitChance.totalAmount = hit;
        enemyStats.dodgeChance.totalAmount = dodge;
        enemyStats.critChance.totalAmount = crit;
        enemyStats.critMulti.totalAmount = multi;
        enemyStats.experience = exp;
        enemyStats.cash = loot;
    }

    public Enemy(Enemy enemy)
    {
        enemyID = enemy.enemyID;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + enemy.enemyStats.mingZi);
        enemyStats.mingZi = enemy.enemyStats.mingZi;
        enemyStats.maxHealth.totalAmount = enemy.enemyStats.maxHealth.totalAmount;
        enemyStats.maxMana.totalAmount = enemy.enemyStats.maxMana.totalAmount;
        enemyStats.physAtk.totalAmount = enemy.enemyStats.physAtk.totalAmount;
        enemyStats.magicAtk.totalAmount = enemy.enemyStats.magicAtk.totalAmount;
        enemyStats.armor.totalAmount = enemy.enemyStats.armor.totalAmount;
        enemyStats.resist.totalAmount = enemy.enemyStats.resist.totalAmount;
        enemyStats.hitChance.totalAmount = enemy.enemyStats.hitChance.totalAmount;
        enemyStats.dodgeChance.totalAmount = enemy.enemyStats.dodgeChance.totalAmount;
        enemyStats.critChance.totalAmount = enemy.enemyStats.critChance.totalAmount;
        enemyStats.critMulti.totalAmount = enemy.enemyStats.critMulti.totalAmount;
        enemyStats.experience = enemy.enemyStats.experience;
        enemyStats.cash = enemy.enemyStats.cash;
    }

    public Enemy()
    {
        enemyID = -1;
    }
}
