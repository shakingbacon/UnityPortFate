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
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
        //statsList.Add(strength);
    }

    public static int FindStatTotal(Stat stat)
    {
        return stat.totalAmount;
    }


}
