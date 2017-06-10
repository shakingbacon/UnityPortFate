using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mortal
{
    public int enemyID;
    public Sprite enemyIMG;

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int ar, int re, int hit, int dodge, int crit, int exp, int loot)
    {
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        mingZi = name;
        maxHealth.baseAmount = hp;
        maxMana.baseAmount = mp;
        physAtk.baseAmount = phys;
        magicAtk.baseAmount = mag;
        armor.baseAmount = ar;
        resist.baseAmount = re;
        hitChance.baseAmount = hit;
        dodgeChance.baseAmount = dodge;
        critChance.baseAmount = crit;
        critMulti.baseAmount = 225;
        experience = exp;
        cash = loot;
        dmgOutput.baseAmount = 100;
        dmgTaken.baseAmount = 100;
        manaComs.baseAmount = 100;
    }

    public Enemy(string name, int id, int hp, int mp, int phys, int mag, int ar, int re, int hit, int dodge, int crit, int multi, int exp, int loot)
    {
        enemyID = id;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + name);
        mingZi = name;
        maxHealth.baseAmount = hp;
        maxMana.baseAmount = mp;
        physAtk.baseAmount = phys;
        magicAtk.baseAmount = mag;
        armor.baseAmount = ar;
        resist.baseAmount = re;
        hitChance.baseAmount = hit;
        dodgeChance.baseAmount = dodge;
        critChance.baseAmount = crit;
        critMulti.baseAmount = multi;
        experience = exp;
        cash = loot;
        dmgOutput.baseAmount = 100;
        dmgTaken.baseAmount = 100;
        manaComs.baseAmount = 100;
    }

    public Enemy(Enemy enemy)
    {
        enemyID = enemy.enemyID;
        enemyIMG = Resources.Load<Sprite>("Enemy Icons/" + enemy.mingZi);
        mingZi = enemy.mingZi;
        maxHealth.baseAmount = enemy.maxHealth.baseAmount;
        maxMana.baseAmount = enemy.maxMana.baseAmount;
        physAtk.baseAmount = enemy.physAtk.baseAmount;
        magicAtk.baseAmount = enemy.magicAtk.baseAmount;
        armor.baseAmount = enemy.armor.baseAmount;
        resist.baseAmount = enemy.resist.baseAmount;
        hitChance.baseAmount = enemy.hitChance.baseAmount;
        dodgeChance.baseAmount = enemy.dodgeChance.baseAmount;
        critChance.baseAmount = enemy.critChance.baseAmount;
        critMulti.baseAmount = enemy.critMulti.baseAmount;
        experience = enemy.experience;
        cash = enemy.cash;
        dmgOutput.baseAmount = enemy.dmgOutput.baseAmount;
        dmgTaken.baseAmount = enemy.dmgTaken.baseAmount;
        manaComs.baseAmount = enemy.manaComs.baseAmount;
        MakeNewBlankPage(1, 1);
        LearnSkill(new Skill(SkillDatabase.GetSkill(0)));
        SimpleStatUpdate();
        UpdateSkills();
    }

    public Enemy()
    {
        enemyID = -1;
    }

    public void UpdateSkills()
    {
        for (int k = 0; k < skills.Count; k += 1)
            for (int i = 0; i < skills.Count; i += 1)
        {
            Skill skill = skills[k][i];
            switch (skill.skillID)
            {
                case 0:
                    {
                        skill.skillDamage = physAtk.totalAmount;
                        break;
                    }
            }
        }
    }
}
