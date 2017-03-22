using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {
    public static List<List<Skill>> skills = new List<List<Skill>>();
    public static List<List<Skill>> learnedSkills = new List<List<Skill>>();

    void Start()
    {
        // learned skills page has 3 pages should be good
        AddPage(learnedSkills, 3);
        AddSkillSlots(learnedSkills, 40);
        // Basically a copy of the database page list but all skills are new not referenced
        switch (PlayerStats.playerStats.job.jobID)
        {
            case 0:
                {
                    AddPage(skills, SkillDatabase.mageSkills.Count);
                    for (int i = 0; i < SkillDatabase.mageSkills.Count; i += 1)
                    {
                        for (int k = 0; k < SkillDatabase.mageSkills[i].Count; k += 1)
                            skills[i].Add((new Skill(SkillDatabase.mageSkills[i][k])));
                    }
                    break;
                }
        }
        FindSkill(0).skillRank += 1; // Basic attack rank always 1
        FindSkill(24).skillRank += 1; // Basic attack rank always 1
        learnedSkills[0][0] = FindSkill(0);
        learnedSkills[0][1] = FindSkill(24);
        SkillUpdate();
    }

    private void AddSkillSlots(List<List<Skill>> page, int skillnum)
    {
        for (int j = 0; j < page.Count; j += 1)
        {
            while (page[j].Count < skillnum)// 40 skills in a page
            {
                page[j].Add(new Skill());
            }
        }
    }

    private void AddPage(List<List<Skill>> page, int pages)
    {
        for (int i = 0; i < pages; i += 1)
        {
            page.Add(new List<Skill>());
        }
    }

    public static Skill FindSkill(int id)
    {
        Skill skill = new Skill();
        for (int k = 0; k < skills.Count; k += 1)
            for (int i = 0; i < skills[k].Count; i += 1)
            {
                if (skills[k][i].skillID == id)
                {
                    skill = skills[k][i];
                }
            }
        return skill;
    }


    // all skill updates
    public static void SkillUpdate()
    {
        for (int k = 0; k < skills.Count; k += 1)
        for (int i = 0; i < skills[k].Count; i += 1)
        {
            Skill skill = skills[k][i];
            Stats stats = PlayerStats.playerStats;
            switch (skill.skillID)
            {
                    
                    case 0:
                        {
                            skill.skillDamage = stats.physAtk.totalAmount;
                            break;
                        }
                    case 1:
                        {
                            skill.skillDamage = (int)(80 + (PlayerStats.playerStats.magicAtk.totalAmount / 1.8) * (1.8 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(50 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 35);
                            skill.skillStatusEff.burnChance = (int)(15 + 3 * skill.skillRank + stats.magicAtk.totalAmount / (25 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = "Chance to inflict Burn: " + skill.skillStatusEff.burnChance.ToString() + "%";
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                   case 2:
                        {
                            skill.skillDamage = (int)(95 + (stats.magicAtk.totalAmount) / 1.7 * (1.85 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(45 + skill.skillDamage / (20 - skill.skillRank + skill.skillRank * 25));
                            skill.skillHitChance = (int)(20 + 4.5 * skill.skillRank);
                            skill.skillEffDesc = "Hit Chance: +" + skill.skillHitChance+"%";
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 3:
                        {
                            skill.skillDamage = (int)(95 + (stats.magicAtk.totalAmount / 1.7) * (1.85 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(45 + skill.skillDamage / (20 - skill.skillRank) + skill.skillRank * 25);
                            skill.skillCritChance = (int)(26 + 4 * skill.skillRank);
                            skill.skillHitChance = (int)(-20 + 4.5 * skill.skillRank);
                            skill.skillCritMulti = (int)(10 + 5 * skill.skillRank);
                            skill.skillEffDesc = "Crit Chance: +" + skill.skillCritChance + "%, " +
                                "Crit Multi: +" + skill.skillCritMulti + "%\n" + "Hit Chance: " + skill.skillHitChance + "%";
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 4:
                        {
                            skill.skillDamage = (int)(115 + (stats.magicAtk.totalAmount / 1.7) * (1.9 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(60 + skill.skillDamage / (14 - skill.skillRank) + skill.skillRank * 55);
                            skill.skillStatusEff.paraChance = (int)(20 + 3 * skill.skillRank + stats.magicAtk.totalAmount/(25 + stats.magicAtk.totalAmount/4));
                            skill.skillCritChance = (int)(14 + 4 * skill.skillRank);
                            skill.skillEffDesc = "Chance to Paralyze: +" + skill.skillStatusEff.paraChance + "%\nCrit Chance: +" + skill.skillCritChance + "%";
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 5:
                        {
                            skill.skillManaCost = (int)(75 * skill.skillRank + (stats.mana.totalAmount * 0.195) / (skill.skillRank + 1));
                            skill.skillCooldown = 6;
                            skill.skillTurnEnd = 6 + 1 * skill.skillRank;
                            skill.skillEffDesc = string.Format("For {0} turns, when recieving damage from an enemy, your Current Mana takes damage instead of your HP. When no MP is available, damage is applied normally.",
                                skill.skillTurnEnd) + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = skill.skillRank * 4;
                            skill.skillRequire = stats.level >= 3 + req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 6:
                        {
                            skill.skillDamage = (int)(200 + skill.skillRank * 75.5 + stats.maxHealth.totalAmount / (8 - skill.skillRank) + stats.magicAtk.totalAmount * 0.75 / stats.maxHealth.totalAmount);
                            skill.skillManaCost = (int)(60 + stats.magicAtk.totalAmount * 0.6 * (1 - skill.skillRank / 20));
                            skill.skillCooldown = 3;
                            skill.skillEffDesc = string.Format("Restore HP: +{0}\nCooldown: {1} Turns", skill.skillDamage, skill.skillCooldown);
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= 3 + req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 7:
                        {
                            skill.skillDamage = (215 + (skill.skillRank - 1) * 15);
                            skill.skillCooldown = 5;
                            skill.skillTurnEnd = 3;
                            skill.skillEffDesc = string.Format("After using this skill, within {0} turns, the next Magical Damage Skill you cast will deal {1}% of its damage.", skill.skillTurnEnd, skill.skillDamage)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 5 + skill.skillRank * 6;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 8:
                        {
                            skill.skillDamage = 19 + stats.level / 5 + 6 * skill.skillRank;
                            skill.skillManaCost = 8 + stats.level / 3 + 4 * skill.skillRank;
                            skill.skillHitChance = 30 + 3 * skill.skillRank;
                            skill.skillCritChance = 35 + 4 * skill.skillRank;
                            skill.skillEffDesc = string.Format("Whenever you defeat an enemy, you have a {0}% chance to gain {1}% of your Maximum MP as MP. Also, whenever you cast a Damaging Skill, you have a {2}% chance to gain {3}% of its Mana Cost as MP\n",
                                skill.skillDamage, skill.skillHitChance, skill.skillManaCost, skill.skillCritChance);
                            int req = 5 + skill.skillRank * 5;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 9:
                        {
                            skill.skillDamage = (320 + 245 * skill.skillRank) * (1 + skill.skillRank / 65);
                            skill.skillEffDesc = "Whenever you Rank Up this skill, gain a set amount of Max MP permanantly.\n" + string.Format("Gain Max MP: +{0}", skill.skillDamage);
                            int req = skill.skillRank * 5;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 10:
                        {
                            skill.skillDamage = 6;
                            skill.skillEffDesc = string.Format("While wielding a Staff or a Wand,\nLuck/Hit/Crit: +{0}. Next rank: +{1}", skill.skillDamage * skill.skillRank, skill.skillDamage * (1 + skill.skillRank));
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 11:
                        {
                            skill.skillDamage = stats.maxMana.totalAmount / 40;
                            // Mana cost is amount gained
                            skill.skillEffDesc = string.Format("When this skill is ranked up, gain {0} Armor/Resist instantly. This skill is based off your Current Max MP.\nAmount Gained: {1} Armor/Resist", skill.skillDamage, skill.skillManaCost);
                            int req = 10 + skill.skillRank * 8;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 12:
                        {
                            skill.skillDamage = (stats.strength.totalAmount * 2 + stats.maxHealth.totalAmount) * 3;
                            skill.skillEffDesc = string.Format("Permamantly set your Str and HP to 1 to increase your Max MP by {0}.\nThis skill is based off your current Strength and max HP.\n", skill.skillDamage);
                            int req = 10;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 13:
                        {
                            skill.skillDamage = (int)(75 + skill.skillRank * 6 + stats.magicAtk.totalAmount * (1.5 + 0.8 * skill.skillRank) * (1 + skill.skillRank / 5));
                            skill.skillManaCost = (int)(60 + skill.skillRank * 50 + stats.magicAtk.totalAmount * 0.25);
                            skill.skillCooldown = 5;
                            skill.skillTurnEnd = 3;
                            skill.skillEffDesc = string.Format("For {0} turns, create a damage blocking shield. Shields always takes damage first.\nShield: {1}, Cooldown: {2} Turns",
                                skill.skillTurnEnd, skill.skillDamage, skill.skillCooldown);
                            int req = 7 + skill.skillRank * 7;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 14:
                        {
                            skill.skillDamage = 10 + 5 * skill.skillRank;
                            skill.skillEffDesc = string.Format("By {0}%, decrease the mana cost, increase the damage, and increase bonuses of Inferno, Tsunami, Tornado, Thunderstorm, and Elemental Burst.\n", skill.skillDamage);
                            int req = 2 + skill.skillRank * 4;
                            skill.skillRequire = false;
                            if ((FindSkill(1).skillRank >= req && FindSkill(2).skillRank >= req) || (FindSkill(1).skillRank >= req && FindSkill(3).skillRank >= req) ||
                                (FindSkill(1).skillRank >= req && FindSkill(4).skillRank >= req) || (FindSkill(2).skillRank >= req && FindSkill(3).skillRank >= req) ||
                                (FindSkill(2).skillRank >= req && FindSkill(4).skillRank >= req) || (FindSkill(3).skillRank >= req && FindSkill(4).skillRank >= req))
                            {
                                skill.skillRequire = true;
                            }
                            skill.skillRequireDesc = string.Format("2 of Inferno, Tsunami, Tornado, OR Thunderstorm - Rank: {0}", req);
                            break;
                        }
                    case 15:
                        {
                            skill.skillDamage = (int)(25 + skill.skillRank * 90 + stats.magicAtk.totalAmount*0.666 / (8 - skill.skillRank));
                            skill.skillManaCost = (int)(150 + skill.skillRank * 60 + stats.magicAtk.totalAmount * 1.3 * (1 + skill.skillRank));
                            skill.skillHitChance = (int)(22 + skill.skillRank * 6 + stats.magicAtk.totalAmount * 0.1 / (1 + skill.skillRank)); // explosion chance;
                            skill.skillCritChance = 75 + 50 * skill.skillRank; // armor/res bonus
                            skill.skillStatusEff.burnChance = (int)(17 + skill.skillRank * 10 + stats.magicAtk.totalAmount * 0.1 / (1 + skill.skillRank));
                            skill.skillCooldown = 5;
                            skill.skillTurnEnd = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, gain Armor/Resist: +{1}.", skill.skillTurnEnd, skill.skillCritChance) + 
                               string.Format("At the end of each turn, there's a {0}% chance where the shield explodes, dealing {1} Phyical Damage with Burn chance: {2}%.", skill.skillHitChance, skill.skillDamage, skill.skillStatusEff.burnChance)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(1);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 16:
                        {
                            skill.skillDamage = (int)(25 + 75 * skill.skillRank + stats.maxHealth.totalAmount * 0.15);
                            skill.skillManaCost = 150 + 125 * skill.skillRank;
                            skill.skillHitChance = (int)(skill.skillDamage * 0.2);
                            skill.skillCooldown = 6;
                            skill.skillTurnEnd = 3;
                            skill.skillEffDesc = string.Format("Remove all status effects from yourself.\nFor each status effect removed, recover {0} HP, and for {3} turns, gain bonus {1} Armor and {2} Resist.",
                                skill.skillDamage, skill.skillHitChance, skill.skillHitChance*2, skill.skillTurnEnd)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(2);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 17:
                        {
                            skill.skillDamage = 25 + 15 * skill.skillRank;
                            skill.skillManaCost = 175 + 150 * skill.skillRank;
                            skill.skillHitChance = 8 + 4 * skill.skillRank;
                            skill.skillCritChance = 60 + 10 * skill.skillRank;
                            skill.skillCooldown = 7;
                            skill.skillTurnEnd = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, the enemy's mana cost of any skill increases by {1}% but the enemy's damage inceases by {2}%. Also, whenever the enemy uses a skill, the enemy takes {3}% mana cost.",
                                skill.skillTurnEnd, skill.skillDamage, skill.skillHitChance, skill.skillCritChance)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(3);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 18:
                        {
                            skill.skillDamage = 25 + 25 * skill.skillRank;
                            skill.skillManaCost = 100 + 300 * skill.skillRank;
                            skill.skillHitChance = 2 + 8 * skill.skillRank;
                            skill.skillCritChance = 5 + 3 * skill.skillRank;
                            skill.skillCritMulti = 10 + 10 * skill.skillRank;
                            skill.skillCooldown = 6;
                            skill.skillTurnEnd = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, damaging skills gain {1} damage, chance to Paralyze +{2}%, Critical Chance: +{3}%, but lose mana {4}% of the used skill's mana cost.",
                                skill.skillTurnEnd, skill.skillDamage, skill.skillHitChance, skill.skillCritChance, skill.skillCritMulti)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(4);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 19:
                        {
                            skill.skillDamage = (75 + (175 * skill.skillRank) * (FindSkill(1).skillRank + FindSkill(2).skillRank + FindSkill(3).skillRank + FindSkill(4).skillRank))*(stats.mana.totalAmount/ (stats.maxMana.totalAmount + 1));
                            skill.skillManaCost = stats.mana.totalAmount;
                            skill.skillStatusEff.burnChance = 3 * (skill.skillRank) + FindSkill(1).skillStatusEff.burnChance;
                            skill.skillStatusEff.paraChance = 3 * skill.skillRank + FindSkill(4).skillStatusEff.paraChance;
                            skill.skillHitChance = 3 + (skill.skillRank) + FindSkill(2).skillHitChance + FindSkill(3).skillHitChance;
                            skill.skillCritChance = FindSkill(3).skillCritChance + FindSkill(4).skillCritChance;
                            skill.skillCritMulti = FindSkill(3).skillCritMulti;
                            skill.skillEffDesc = string.Format("Consume all your current Mana to deal massive damage. This skill deals more damage based on the rank of each Elemental damaging skill.\n");
                            int req = 3 + skill.skillRank * 3;
                            skill.skillRequire = false;
                            if ((FindSkill(1).skillRank >= req && FindSkill(2).skillRank >= req) || (FindSkill(1).skillRank >= req && FindSkill(3).skillRank >= req) ||
                                (FindSkill(1).skillRank >= req && FindSkill(4).skillRank >= req) || (FindSkill(2).skillRank >= req && FindSkill(3).skillRank >= req) ||
                                (FindSkill(2).skillRank >= req && FindSkill(4).skillRank >= req) || (FindSkill(3).skillRank >= req && FindSkill(4).skillRank >= req))
                            {
                                skill.skillRequire = true;
                            }
                            skill.skillRequireDesc = string.Format("2 of Inferno, Tsunami, Tornado, OR Thunderstorm - Rank: {0}", req);
                            break;
                        }
                    case 20:
                        {
                            skill.skillDamage = 9 + 7 * skill.skillRank;
                            skill.skillEffDesc = string.Format("Luck: +{0}",skill.skillDamage);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(2);
                            Skill reqSkill2 = FindSkill(3);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 21:
                        {
                            skill.skillDamage = (stats.maxHealth.totalAmount/4 - 100 - 100*skill.skillMaxRank);
                            skill.skillHitChance = -15 - 55 * skill.skillRank;
                            skill.skillCritChance = 25 + 85 * skill.skillRank;
                            skill.skillEffDesc = string.Format("Max HP: {0}\nArmor/Resist: {1}\nGain: {2} Phys/Magic Attack\n", skill.skillDamage, skill.skillHitChance, skill.skillCritChance);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(3);
                            Skill reqSkill2 = FindSkill(1);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 22:
                        {
                            skill.skillDamage = 25 + 15 * skill.skillRank;
                            skill.skillHitChance = 15 + 25 * skill.skillRank;
                            skill.skillEffDesc = string.Format("When using a Water damaging skill, {0}% chance to apply a debuff. This debuff does nothing, but using an Electric damaging skill consumes this debuff, dealing {1}% more damage.\n",
                                skill.skillDamage, skill.skillHitChance);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(2);
                            Skill reqSkill2 = FindSkill(4);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 23:
                        {
                            skill.skillEffDesc = string.Format("Fire damaging skills obtain Crit Chance, and Chance to Paralyze bonuses, Electric damaging skills obtain Chance to Burn bonus.\n");
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(1);
                            Skill reqSkill2 = FindSkill(4);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
            }
        }
    }



}
