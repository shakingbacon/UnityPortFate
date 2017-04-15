using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats {
    public string mingZi;
    public Job job = new Job();
    public Stat strength = new Stat();
    public Stat intelligence = new Stat();
    public Stat agility = new Stat();
    public Stat luck = new Stat();
    public int health = 0;
    public Stat maxHealth = new Stat();
    public int mana = 0;
    public Stat maxMana = new Stat();
    public Stat physAtk = new Stat();
    public Stat magicAtk = new Stat();
    public Stat manaComs = new Stat();
    public Stat dmgOutput = new Stat();
    public Stat dmgTaken = new Stat();
    public Stat armor = new Stat();
    public Stat resist = new Stat();
    public Stat hitChance = new Stat();
    public Stat dodgeChance = new Stat();
    public Stat critChance = new Stat();
    public Stat critMulti = new Stat();
    public int level = 0;
    public int abilityPoints = 0;
    public int skillPoints = 0;
    public int experience = 0;
    public int maxExperience = 0;
    public int cash = 0;
    public List<Stat> statsList = new List<Stat>();

    public Stats()
    {
        job = new Job();
        strength = new Stat();
        intelligence = new Stat();
        agility = new Stat();
        luck = new Stat();
        health = 0;
        maxHealth = new Stat();
        mana = 0;
        maxMana = new Stat();
        physAtk = new Stat();
        magicAtk = new Stat();
        manaComs = new Stat();
        dmgOutput = new Stat();
        dmgTaken = new Stat();
        armor = new Stat();
        resist = new Stat();
        hitChance = new Stat();
        dodgeChance = new Stat();
        critChance = new Stat();
        critMulti = new Stat();
        level = 0;
        abilityPoints = 0;
        skillPoints = 0;
        experience = 0;
        maxExperience = 0;
        cash = 0;
        statsList.Add(strength);
        statsList.Add(intelligence);
        statsList.Add(agility);
        statsList.Add(luck);
        statsList.Add(maxHealth);
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
    }

    public void SimpleStatUpdate()
    {
        for (int i = 0; i < statsList.Count; i += 1)// need to update all stats so id doesnt matter
        {
            { 
                statsList[i].totalAmount = statsList[i].baseAmount + statsList[i].buffedAmount;
            }
        }
    }

    public void HealFullHP()
    {
        health = maxHealth.totalAmount;
    }

    public void HealFullMP()
    {
        mana = maxMana.totalAmount;
    }

}
