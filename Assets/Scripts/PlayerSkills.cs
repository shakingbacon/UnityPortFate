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
        switch (PlayerStats.stats.job.jobID)
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
            Stats stats = PlayerStats.stats;
            switch (skill.skillID)
            {
                    case 0:
                        {
                            skill.skillDamage = stats.physAtk.totalAmount;
                            skill.skillEffDesc = "Attack, dealing physical damage";
                            break;
                        }
                    case 1:
                        {
                            skill.skillDamage = (int)(80 + (stats.magicAtk.totalAmount / 1.8) * (1.8 * (1 + skill.skillRank)));
                            skill.skillManaCost = 0;//(int)(50 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 35);
                            skill.skillStatusEff.burn.statusChance = (int)(115 + 3 * skill.skillRank + stats.magicAtk.totalAmount / (25 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = "Chance to inflict Burn: " + skill.skillStatusEff.burn.statusChance.ToString() + "%";
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
                            skill.skillCritChance = (int)(100 + 4 * skill.skillRank);
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
                            skill.skillDamage = 1;//(int)(115 + (stats.magicAtk.totalAmount / 1.7) * (1.9 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(60 + skill.skillDamage / (14 - skill.skillRank) + skill.skillRank * 55);
                            skill.skillStatusEff.paralyze.statusChance = (int)(120 + 3 * skill.skillRank + stats.magicAtk.totalAmount/(25 + stats.magicAtk.totalAmount/4));
                            skill.skillCritChance = (int)(14 + 4 * skill.skillRank);
                            skill.skillEffDesc = "Chance to Paralyze: " + skill.skillStatusEff.paralyze.statusChance + "%\nCrit Chance: +" + skill.skillCritChance + "%";
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 5:
                        {
                            skill.skillManaCost = 0;//(int)(75 * skill.skillRank + (stats.mana * 0.195) / (skill.skillRank + 1));
                            skill.skillCooldown = 10;
                            skill.skillDuration = 6 + 1 * skill.skillRank;
                            skill.skillEffDesc = string.Format("For {0} turns, when recieving damage from an enemy, your Current Mana takes damage instead of your HP. When no MP is available, damage is applied normally.",
                                skill.skillDuration) + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 3 + skill.skillRank * 4;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 6:
                        {
                            skill.skillDamage = (int)(200 + skill.skillRank * 75.5 + stats.maxHealth.totalAmount / (8 - skill.skillRank) + stats.magicAtk.totalAmount * 0.75 / stats.maxHealth.totalAmount);
                            skill.skillManaCost = (int)(60 + stats.magicAtk.totalAmount * 0.6 * (1 - skill.skillRank / 20));
                            skill.skillCooldown = 3;
                            skill.skillEffDesc = string.Format("Restore HP: +{0}\nCooldown: {1} Turns", skill.skillDamage, skill.skillCooldown);
                            int req = 3 + skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 7:
                        {
                            skill.skillDamage = (215 + (skill.skillRank - 1) * 15);
                            skill.skillCooldown = 5;
                            skill.skillDuration = 3;
                            skill.skillEffDesc = string.Format("After using this skill, within {0} turns, the next Magical Damage Skill you cast will deal {1}% of its damage.", skill.skillDuration, skill.skillDamage)
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
                            int req = 4 + skill.skillRank * 3;
                            Skill skillreq = FindSkill(30);
                            skill.skillRequire = skillreq.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", skillreq.skillName, req);
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
                            skill.skillDuration = 3;
                            skill.skillEffDesc = string.Format("For {0} turns, create a damage blocking shield. Shields always takes damage first.\nShield: {1}, Cooldown: {2} Turns",
                                skill.skillDuration, skill.skillDamage, skill.skillCooldown);
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
                            skill.skillStatusEff.burn.statusChance = (int)(17 + skill.skillRank * 10 + stats.magicAtk.totalAmount * 0.1 / (1 + skill.skillRank));
                            skill.skillCooldown = 5;
                            skill.skillDuration = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, gain Armor/Resist: +{1}.", skill.skillDuration, skill.skillCritChance) + 
                               string.Format("At the end of each turn, there's a {0}% chance where the shield explodes, dealing {1} Phyical Damage with Burn chance: {2}%.", skill.skillHitChance, skill.skillDamage, skill.skillStatusEff.burn.statusChance)
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
                            skill.skillDuration = 3;
                            skill.skillEffDesc = string.Format("Remove all status effects from yourself.\nFor each status effect removed, recover {0} HP, and for {3} turns, gain bonus {1} Armor and {2} Resist.",
                                skill.skillDamage, skill.skillHitChance, skill.skillHitChance*2, skill.skillDuration)
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
                            skill.skillDuration = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, the enemy's mana cost of any skill increases by {1}% but the enemy's damage inceases by {2}%. Also, whenever the enemy uses a skill, the enemy takes {3}% of the mana cost as Physical Damage.",
                                skill.skillDuration, skill.skillDamage, skill.skillHitChance, skill.skillCritChance)
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
                            skill.skillDuration = 4;
                            skill.skillEffDesc = string.Format("For {0} turns, damaging skills gain {1} damage, chance to Paralyze +{2}%, Critical Chance: +{3}%, but lose mana {4}% of the used skill's mana cost.",
                                skill.skillDuration, skill.skillDamage, skill.skillHitChance, skill.skillCritChance, skill.skillCritMulti)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(4);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 19:
                        {
                            skill.skillDamage = (75 + (175 * skill.skillRank) * (FindSkill(1).skillRank + FindSkill(2).skillRank + FindSkill(3).skillRank + FindSkill(4).skillRank))*(stats.mana/ (stats.maxMana.totalAmount + 1));
                            skill.skillManaCost = stats.mana;
                            skill.skillStatusEff.burn.statusChance = 3 * (skill.skillRank) + FindSkill(1).skillStatusEff.burn.statusChance;
                            skill.skillStatusEff.paralyze.statusChance = 3 * skill.skillRank + FindSkill(4).skillStatusEff.paralyze.statusChance;
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
                            skill.skillDamage = 14 + 9 * skill.skillRank;
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
                    case 24:
                        {
                            skill.skillDamage = stats.magicAtk.totalAmount;
                            skill.skillEffDesc = "Attack, dealing magical damage";
                            break;
                        }
                    case 25:
                        {
                            skill.skillDamage = (int)(15 + (stats.magicAtk.totalAmount / 2.2) * (2.1 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(50 + skill.skillDamage / (19 - skill.skillRank) + skill.skillRank * 55);
                            skill.skillStatusEff.burn.statusChance = (int)(19 + 5 * skill.skillRank + stats.magicAtk.totalAmount / (35 + stats.magicAtk.totalAmount) / 4);
                            skill.skillStatusEff.blind.statusChance = (int)(14 + 7 * skill.skillRank + stats.magicAtk.totalAmount / (35 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = string.Format("Chance to Burn: {0}%\n Chance to Blind: {1}%", skill.skillStatusEff.burn.statusChance, skill.skillStatusEff.blind.statusChance);
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 26:
                        {
                            skill.skillDamage = (int)(75 + (stats.magicAtk.totalAmount / 2) * (2.25 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(100 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 25);
                            skill.skillStatusEff.confuse.statusChance = (int)(24 + 4 * skill.skillRank + stats.magicAtk.totalAmount / (23 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = string.Format("Chance to Confuse: {0}%", skill.skillStatusEff.confuse.statusChance);
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 27: // need to add effect
                        {
                            skill.skillDamage = (int)(100 + (stats.magicAtk.totalAmount / 2) * (2.4 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(70 + skill.skillDamage / (15 - skill.skillRank) + skill.skillRank * 40);
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 28:
                        {
                            skill.skillDamage = (int)(25 + (stats.magicAtk.totalAmount / 2.7) * (1.2 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(100 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 80);
                            skill.skillStatusEff.blind.statusChance = (int)(36 + 4 * skill.skillRank + stats.magicAtk.totalAmount / (19 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = string.Format("Chance to Blind: {0}%", skill.skillStatusEff.blind.statusChance);
                            break;
                        }
                    case 29:
                        {
                            skill.skillDamage = (int)(75 + (stats.magicAtk.totalAmount / 2.5) * (2.1 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(50 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 40);
                            skill.skillStatusEff.cripple.statusChance = (int)(17 + 8 * skill.skillRank + stats.magicAtk.totalAmount / (28 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = string.Format("Chance to Cripple: {0}%", skill.skillStatusEff.cripple.statusChance);
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 30:
                        {
                            skill.skillDamage = (int)(50 + (stats.magicAtk.totalAmount / 1.8) * (2.9 * (1 + skill.skillRank)));
                            skill.skillManaCost = (int)(80 + skill.skillDamage / (17 - skill.skillRank) + skill.skillRank * 40);
                            skill.skillStatusEff.curse.statusChance = (int)(20 + 6 * skill.skillRank + stats.magicAtk.totalAmount / (24 + stats.magicAtk.totalAmount) / 4);
                            skill.skillEffDesc = string.Format("Chance to Curse: {0}%", skill.skillStatusEff.curse.statusChance);
                            int req = skill.skillRank * 3;
                            skill.skillRequire = stats.level >= req;
                            skill.skillRequireDesc = string.Format("Level: {0}", req);
                            break;
                        }
                    case 31:
                        {

                            skill.skillManaCost = 200 + 75 * skill.skillRank;
                            skill.skillDamage = 40 + 15 * skill.skillRank;
                            skill.skillHitChance = 20 + 10 * skill.skillRank;
                            skill.skillEffDesc = string.Format("Gain {0}% of the enemy's Physical Attack and Magical Attack as Armor/Resist respectively. Also, gain {1}% of the enemy's Current HP\n", skill.skillDamage, skill.skillHitChance);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(29);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 32:
                        {
                            skill.skillManaCost = 50 + 100 * skill.skillRank;
                            skill.skillDuration = 5;
                            skill.skillCooldown = 6;
                            skill.skillEffDesc = string.Format("For {0} turns, the chance of being burned raises by {1}%", skill.skillDuration, skill.skillManaCost)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(25);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 33:
                        {
                            skill.skillManaCost = 100 + 75 * skill.skillRank;
                            skill.skillDuration = 4;
                            skill.skillCooldown = 6;
                            skill.skillEffDesc = string.Format("For {0} turns, any attack that has the chance to inflict Confuse has its damage increased by its chance to Confuse, but the chance to Confuse becomes 0%\n", skill.skillDuration);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(26);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 34:
                        {
                            skill.skillManaCost = 125 + 75 * skill.skillRank;
                            skill.skillDamage = 15 + 10 * skill.skillRank;
                            skill.skillHitChance = 10 + 5 * skill.skillRank;
                            skill.skillDuration = 5;
                            skill.skillCooldown = 8;
                            skill.skillEffDesc = string.Format("For {0} turns:\n+{1}% Dodge Chance\n+{2}% Critical Chance",skill.skillDuration, skill.skillDamage, skill.skillHitChance)
                                + string.Format("\nCooldown: {0} Turns", skill.skillCooldown); ;
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(30);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 35:
                        {
                            skill.skillDamage = 5 + 5 * skill.skillRank;
                            skill.skillHitChance = 100 + 175 * skill.skillRank;
                            skill.skillCritChance = 8 + 4 * skill.skillRank;
                            skill.skillEffDesc = string.Format("+{0}% Dodge Chance\n+{1} Max MP, -{2}% Mana Comsumption", skill.skillDamage, skill.skillHitChance, skill.skillCritChance);
                            int req = 4 + skill.skillRank * 3;
                            Skill reqSkill = FindSkill(29);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 36:
                        {
                            skill.skillDamage = 6 + 6 * skill.skillMaxRank;
                            skill.skillEffDesc = string.Format("Being attacked has a {0}% chance to burn the attacker.\n", skill.skillDamage);
                            int req = 4 + skill.skillRank * 3;
                            Skill reqSkill = FindSkill(25);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 37:
                        {
                            skill.skillDamage = 9 + 4 * skill.skillRank;
                            skill.skillHitChance = 10 + 5 * skill.skillRank;
                            skill.skillEffDesc = string.Format("You are immune to Confuse. Attacks with the chance to Confuse is increased +{0}%. If the enemy is confused, enemy's Damage Taken +{1}%.\n", skill.skillDamage, skill.skillHitChance);
                            int req = 4 + skill.skillRank * 3;
                            Skill reqSkill = FindSkill(26);
                            skill.skillRequire = reqSkill.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} - Rank: {1}", reqSkill.skillName, req);
                            break;
                        }
                    case 38:
                        {
                            skill.skillDamage = (3 + (2 + stats.level/3 * skill.skillRank)) * skill.skillRank;
                            skill.skillHitChance = (5 + (1 + stats.level / 4 * skill.skillRank)) * skill.skillRank;
                            skill.skillEffDesc = string.Format("During battle, at the end of your turn, gain {0} HP multiplied by the turn count. Also, any damage taken is reduced by {1} multiplied by the turn count.\n", skill.skillDamage, skill.skillHitChance);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(29);
                            Skill reqSkill2 = FindSkill(25);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 39:
                        {
                            skill.skillDamage = 150 + 100 * skill.skillRank;
                            skill.skillDuration = 2 + skill.skillRank;
                            skill.skillEffDesc = string.Format("During battle, if your HP is 0 or lower, don't die and set HP equal to {0}. If you don't defeat the enemy within {1} turns, reduce HP to 0 and die normally.\n", skill.skillDamage, skill.skillDuration);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(25);
                            Skill reqSkill2 = FindSkill(30);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 40:
                        {
                            skill.skillDamage = 25 + 10 * skill.skillRank;
                            skill.skillEffDesc = string.Format("Any damage is multiplied by {0}% (including enemy).\n", skill.skillDamage);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(26);
                            Skill reqSkill2 = FindSkill(29);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 41:
                        {
                            skill.skillDamage = 5 + 5 * skill.skillRank;
                            skill.skillHitChance = 20 + 10 * skill.skillRank;
                            skill.skillEffDesc = string.Format("+{0}% Dodge Chance\nAny damage dealing %HP damage is increased by {1}%.\n", skill.skillDamage, skill.skillHitChance);
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(30);
                            Skill reqSkill2 = FindSkill(26);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 42:
                        {
                            skill.skillEffDesc = string.Format("Water skills damage increased");
                            int req = 2 + skill.skillRank * 4;
                            Skill reqSkill = FindSkill(26);
                            Skill reqSkill2 = FindSkill(2);
                            skill.skillRequire = reqSkill.skillRank >= req && reqSkill2.skillRank >= req;
                            skill.skillRequireDesc = string.Format("{0} AND {1} - Rank: {2}", reqSkill.skillName, reqSkill2.skillName, req);
                            break;
                        }
                    case 43:
                        {
                            break;
                        }
                    case 44:
                        {
                            break;
                        }
                }
                skill.skillRequire = true;
                skill.skillManaCost = (int)(skill.skillManaCost * (PlayerStats.stats.manaComs.totalAmount/100f));
        }
    }

}
