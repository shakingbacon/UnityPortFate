using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public int enemyID;
    public Sprite enemyIMG;
    public Stats stats = new Stats();

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int multi, int exp, int loot)
    {
        stats = new Stats();
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        stats.mingZi = name;
        stats.maxHealth.totalAmount = hp;
        stats.maxMana.totalAmount = mp;
        stats.physAtk.totalAmount = phys;
        stats.magicAtk.totalAmount = mag;
        stats.armor.totalAmount = armor;
        stats.resist.totalAmount = resist;
        stats.hitChance.totalAmount = hit;
        stats.dodgeChance.totalAmount = dodge;
        stats.critChance.totalAmount = crit;
        stats.critMulti.totalAmount = multi;
        stats.experience = exp;
        stats.cash = loot;
    }

    public Enemy(Enemy enemy)
    {
        stats = new Stats();
        enemyID = enemy.enemyID;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + enemy.stats.mingZi);
        stats.mingZi = enemy.stats.mingZi;
        stats.maxHealth.totalAmount = enemy.stats.maxHealth.totalAmount;
        stats.maxMana.totalAmount = enemy.stats.maxMana.totalAmount;
        stats.physAtk.totalAmount = enemy.stats.physAtk.totalAmount;
        stats.magicAtk.totalAmount = enemy.stats.magicAtk.totalAmount;
        stats.armor.totalAmount = enemy.stats.armor.totalAmount;
        stats.resist.totalAmount = enemy.stats.resist.totalAmount;
        stats.hitChance.totalAmount = enemy.stats.hitChance.totalAmount;
        stats.dodgeChance.totalAmount = enemy.stats.dodgeChance.totalAmount;
        stats.critChance.totalAmount = enemy.stats.critChance.totalAmount;
        stats.critMulti.totalAmount = enemy.stats.critMulti.totalAmount;
        stats.experience = enemy.stats.experience;
        stats.cash = enemy.stats.cash;
    }

    public Enemy()
    {
        enemyID = -1;
    }
}
