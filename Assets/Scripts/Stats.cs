using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {
    public string mingZi;
    public Job job;
    public Stat strength;
    public Stat intelligence;
    public Stat agility;
    public Stat luck;
    public Stat health;
    public Stat maxHealth;
    public Stat mana;
    public Stat maxMana;
    public Stat physAtk;
    public Stat magicAtk;
    public Stat manaComs;
    public Stat dmgOutput;
    public Stat dmgTaken;
    public Stat armor;
    public Stat resist;
    public Stat hitChance;
    public Stat dodgeChance;
    public Stat critChance;
    public Stat critMulti;
    public Stat level;
    public Stat abilityPoints;
    public Stat skillPoints;
    public Stat experience;
    public Stat maxExperience;
    public Stat cash;
    public List<Stat> statsList = new List<Stat>();

    void Start()
    {
        statsList.Add(strength);
        statsList.Add(intelligence);
        statsList.Add(agility);
        statsList.Add(luck);
        statsList.Add(health);
        statsList.Add(maxHealth);
        statsList.Add(mana);
        statsList.Add(maxMana);
        statsList.Add(physAtk);
        statsList.Add(magicAtk);
        statsList.Add(manaComs);
        statsList.Add(dmgOutput);
        statsList.Add(dmgTaken);
        statsList.Add(armor);
        statsList.Add(resist);
        statsList.Add(hitChance);
        statsList.Add(dodgeChance);
        statsList.Add(critChance);
        statsList.Add(critMulti);
        statsList.Add(level);
        statsList.Add(abilityPoints);
        statsList.Add(skillPoints);
        statsList.Add(experience);
        statsList.Add(maxExperience);
        statsList.Add(cash);
    }

    public static int GetStatTotal(Stat stat)
    {
        return stat.totalAmount;
    }

}
