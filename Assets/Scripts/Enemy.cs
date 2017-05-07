using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public int enemyID;
    public Sprite enemyIMG;
    public Stats stats = new Stats();
    public List<Skill> skills = new List<Skill>();

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int armor, int resist, int hit, int dodge, int crit, int multi, int exp, int loot)
    {
        stats = new Stats();
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        stats.mingZi = name;
        stats.maxHealth.baseAmount = hp;
        stats.maxMana.baseAmount = mp;
        stats.physAtk.baseAmount = phys;
        stats.magicAtk.baseAmount = mag;
        stats.armor.baseAmount = armor;
        stats.resist.baseAmount = resist;
        stats.hitChance.baseAmount = hit;
        stats.dodgeChance.baseAmount = dodge;
        stats.critChance.baseAmount = crit;
        stats.critMulti.baseAmount = multi;
        stats.experience = exp;
        stats.cash = loot;
        stats.dmgOutput.baseAmount = 100;
        stats.dmgTaken.baseAmount = 100;
        stats.manaComs.baseAmount = 100;
    }

    public Enemy(Enemy enemy)
    {
        stats = new Stats();
        enemyID = enemy.enemyID;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + enemy.stats.mingZi);
        stats.mingZi = enemy.stats.mingZi;
        stats.maxHealth.baseAmount = enemy.stats.maxHealth.baseAmount;
        stats.maxMana.baseAmount = enemy.stats.maxMana.baseAmount;
        stats.physAtk.baseAmount = enemy.stats.physAtk.baseAmount;
        stats.magicAtk.baseAmount = enemy.stats.magicAtk.baseAmount;
        stats.armor.baseAmount = enemy.stats.armor.baseAmount;
        stats.resist.baseAmount = enemy.stats.resist.baseAmount;
        stats.hitChance.baseAmount = enemy.stats.hitChance.baseAmount;
        stats.dodgeChance.baseAmount = enemy.stats.dodgeChance.baseAmount;
        stats.critChance.baseAmount = enemy.stats.critChance.baseAmount;
        stats.critMulti.baseAmount = enemy.stats.critMulti.baseAmount;
        stats.experience = enemy.stats.experience;
        stats.cash = enemy.stats.cash;
        stats.dmgOutput.baseAmount = enemy.stats.dmgOutput.baseAmount;
        stats.dmgTaken.baseAmount = enemy.stats.dmgTaken.baseAmount;
        stats.manaComs.baseAmount = enemy.stats.manaComs.baseAmount;
        skills.Add(new Skill(SkillDatabase.GetSkill(0)));
        stats.SimpleStatUpdate();
        UpdateSkills();
    }

    public Enemy()
    {
        enemyID = -1;
    }

    public void UpdateSkills()
    {
        for (int i = 0; i < skills.Count; i += 1)
        {
            Skill skill = skills[i];
            switch (skill.skillID)
            {
                case 0:
                    {
                        skill.skillDamage = stats.physAtk.totalAmount;
                        break;
                    }
            }
        }
    }
}
