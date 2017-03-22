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
    public Stat health = new Stat();
    public Stat maxHealth = new Stat();
    public Stat mana = new Stat();
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
    public int level;
    public int abilityPoints;
    public int skillPoints;
    public int experience;
    public int maxExperience;
    public int cash;
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
    }
}
