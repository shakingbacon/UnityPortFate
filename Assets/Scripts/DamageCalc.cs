using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCalc : MonoBehaviour
{
    public static DamageCalc damageCalc;
    public static bool enemyCanAttack = true;
    public static bool enemyDead = false;

    void Start()
    {
        damageCalc = gameObject.GetComponent<DamageCalc>();
    }

    public static int DmgModifier(Stats user, Stats victim, Skill skill)
    {
        int dmg;
        if (skill.skillType == Skill.SkillType.Physical)
        {
            dmg = (int)((skill.skillDamage * (user.dmgOutput.totalAmount/100f) - victim.armor.totalAmount) * (victim.dmgTaken.totalAmount / 100f));
        }
        else
        {
            dmg = (int)((skill.skillDamage * (user.dmgOutput.totalAmount/100f) - victim.resist.totalAmount) * (victim.dmgTaken.totalAmount / 100f));
        }
        Transform who;
        if (user == PlayerStats.stats)
        {
            who = BattleUI.playerStatus;
        }
        else
        {
            who = BattleUI.enemyStatus;
        }
        foreach (Transform status in who)
        {
            //if (status.GetComponent<StatusHolder>().status.statusID != -1)
            //{
            //    switch (status.GetComponent<StatusHolder>().status.statusID)
            //    {
            //    }
            //}
            if (status.GetComponent<StatusHolder>().skill.skillID != -1)
            {
                Skill statusSkill = status.GetComponent<StatusHolder>().skill;
                switch (statusSkill.skillID)
                {
                    case 7:
                        {
                            if (skill.skillType == Skill.SkillType.Magical)
                            {
                                BattleUI.RemoveActive(who, statusSkill.skillID);
                                dmg = (int)(dmg * (statusSkill.skillDamage / 100f));
                            }
                            break;
                        }
                }
            }
        }
        return dmg;
    }

    public static int HitChanceModifier(Stats user, Stats victim, Skill skill)
    {
        int hit = user.hitChance.totalAmount + skill.skillHitChance - victim.dodgeChance.totalAmount;
        return hit;
    }

    public static int CritChanceModifier(Stats user, Stats victim, Skill skill)
    {
        int crit = user.critChance.totalAmount + skill.skillCritChance;
        return crit;
    }

    public static void CheckSkillStatusEff(Stats victim, Skill skill)
    {
        foreach (Status status in skill.skillStatusEff.statusEffList)
        {
            if (status.statusChance > Random.Range(0, 101))
            {
                BattleUI.AddStatus(victim == PlayerStats.stats, status);
            }
        }
        //BattleUI.UpdateAllStatusHolder(victim);
    }

    public static bool ApplyStatusEff(Stats user, Stats victim, Status status)
    {
        if (status.statusID != -1)
        {
            switch (status.statusID)
            {
                case 0:
                    {
                        SoundDatabase.PlaySound(35);
                        int damage = (victim.maxHealth.totalAmount / 10 - Random.Range(0, victim.maxHealth.totalAmount / 100))
                            + Random.Range(0, 10 + victim.maxHealth.totalAmount / 80);
                        victim.health -= damage;
                        BattleUI.TextAdd(victim, 26, "red", string.Format("took {0} burn damage", damage));
                        break;
                    }
                case 1:
                    {
                        SoundDatabase.PlaySound(37);
                        BattleUI.TextAdd(victim, 26, "yellow", string.Format("is Paralyzed"));
                        if (Random.Range(0,101) >= 50)
                        {
                            BattleUI.TextAdd(victim, 26, "yellow", string.Format("couldn't move!"));
                            enemyCanAttack = false;
                        }
                        break;
                    }
            }
            BattleUI.UpdateEnemySliders();
            StatusBar.UpdateSliders();
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void FinalCalculationModifier(Stats user, Stats victim, Skill skill, int dmg)
    {
        Transform who;
        bool doHealthDamage = true;
        // attacking status effects
        if (user == PlayerStats.stats)
        {
            who = BattleUI.playerStatus;
        }
        else
        {
            who = BattleUI.enemyStatus;
        }
        //foreach (Transform status in who)
        //{
        //    //if (status.GetComponent<StatusHolder>().status.statusID != -1)
        //    //{
        //    //    switch (status.GetComponent<StatusHolder>().status.statusID)
        //    //    {
        //    //    }
        //    //}
        //    //if (status.GetComponent<StatusHolder>().skill.skillID != -1)
        //    //{
        //    //    Skill statusSkill = status.GetComponent<StatusHolder>().skill;
        //    //    switch (statusSkill.skillID)
        //    //    {
        //    //    }
        //    //}
        //}
        ////
        // defending status effects
        if (victim == PlayerStats.stats)
        {
            who = BattleUI.playerStatus;
        }
        else
        {
            who = BattleUI.enemyStatus;     
        }
        int priorityStop;
        foreach (Transform status in who)
        {
            if (status.GetComponent<StatusHolder>().status.statusID != -1)
            {
                //switch (status.GetComponent<StatusHolder>().status.statusID)
                //{
                //    case 0:
                //        {
                //            break;
                //        }
                //}
            }
            bool priorityCancel = false;
            if (status.GetComponent<StatusHolder>().skill.skillID != -1)
            {
                //// PRIORITY 1 ####
                // shield
                if (victim.shield > 0)
                {
                    if (victim.shield - dmg < 0)
                    {
                        // shield breaks
                        victim.health -= dmg - victim.GetLatesetShieldAmount();
                        BattleUI.TextAdd(user, 20, "black", string.Format("shieled {0} damage", dmg));
                        BattleUI.TextAdd(user, 20, "black", string.Format("deals {0} {1} damage", dmg - victim.mana, skill.skillType));
                        StatusBar.NoShield();
                    }
                    else
                    {
                        victim.shield -= dmg;
                        BattleUI.TextAdd(user, 20, "black", string.Format("shieled {0} damage", dmg));
                    }
                    StatusBar.UpdateShield();
                    doHealthDamage = false;
                    priorityCancel = true;
                }
                //switch (status.GetComponent<StatusHolder>().skill.skillID)
                //{
  
                //}
                // PRIORITY 2
                if (!priorityCancel)
                {
                    switch (status.GetComponent<StatusHolder>().skill.skillID)
                    {
                        // mana gaurd
                        // some priorities should go here
                        case 5:
                            {
                                if (victim.mana - dmg < 0)
                                {
                                    BattleUI.TextAdd(user, 20, "black", string.Format("deals {0} {1} damage to your Mana", victim.mana, skill.skillType));
                                    victim.health -= dmg - victim.mana;
                                    victim.mana = 0;
                                    BattleUI.TextAdd(user, 20, "black", string.Format("deals {0} {1} damage", dmg - victim.mana, skill.skillType));
                                }
                                else
                                {
                                    victim.mana -= dmg;
                                    BattleUI.TextAdd(user, 20, "black", string.Format("deals {0} {1} damage to your Mana", dmg, skill.skillType));
                                }
                                doHealthDamage = false;
                                break;
                            }
                    }
                }
            }
        }
        if (doHealthDamage)
        {
            victim.health -= dmg;
            if (user == PlayerStats.stats)
            {
                BattleUI.TextAdd(user, 25, "black", string.Format("deal {0} {1} damage", dmg, skill.skillType));
            }
            else
            {
                BattleUI.TextAdd(user, 25, "black", string.Format("deals {0} {1} damage", dmg, skill.skillType));
            }
        }
    }

    public static void TurnEndChecker(Stats victim, Skill skill)
    {
        Transform who;
        if (victim == PlayerStats.stats)
        {
            who = BattleUI.playerStatus;
        }
        else
        {
            who = BattleUI.enemyStatus;
        }
        foreach (Transform status in who)
        {
            if (status.GetComponent<StatusHolder>().turnEnd == Battle.turnCount)
            {
                Destroy(status.gameObject); // removing status in battle
            }
        }
        int i = 0;
        foreach (List<Skill> page in PlayerSkills.learnedSkills)
        {
            foreach (Skill aSkill in PlayerSkills.learnedSkills[i])
            {
                if (aSkill.skillID != -1)
                {
                    if (Battle.turnCount == aSkill.skillCooldownEnd)
                    {
                        aSkill.skillOnCooldown = false; // removing cooldown in skills
                    }
                }
            }
            i += 1;
        }
    }

    public static void SkillActive(Stats user, Skill skill)
    {
        BattleUI.TextAdd(user, 30, "#000000ff", "used " + skill.skillName);
        user.mana -= skill.skillManaCost;
        // actives that dont add status pic
        List<int> dontAdd = new List<int>(new int[] {6, 13});
        if (!dontAdd.Exists(id => id == skill.skillID))
        {
            BattleUI.AddStatus(true, skill);
        }
        // activate effect at start
        switch (skill.skillID)
        {
            case 6: // resotre
                {
                    user.HealHP(skill.skillDamage);
                    BattleUI.TextAdd(user, 30, "red", string.Format("healed for {0} HP", skill.skillDamage));
                    BattleUI.AddCooldown(skill);
                    break;
                }
            case 13:
                {
                    user.shield += skill.skillDamage;
                    StatusBar.SetShield();
                    BattleUI.TextAdd(user, 30, "black", string.Format("gained a {0} HP Shield", skill.skillDamage));
                    break;
                }

        }
        SoundDatabase.PlaySound(skill.skillSoundID);
        BattleUI.UpdateEnemySliders();
        StatusBar.UpdateSliders();
    }

    public static void SkillAttack(Stats user, Stats victim, Skill skill)
    {
        // Mana Cost
        BattleUI.TextAdd(user, 30, "#000000ff", "used " + skill.skillName);
        user.mana -= skill.skillManaCost;
        // Hit Chance
        int hitChance = HitChanceModifier(user, victim, skill);
        bool ifHit = hitChance >= Random.Range(0, 101);
        if (ifHit)
        {
            ////// Damage
            int damage = DmgModifier(user, victim, skill);
            // On Hit Effects
            CheckSkillStatusEff(victim, skill);
            // Crit Chance
            int critChance = CritChanceModifier(user, victim, skill);
            //// Check if Crit
            bool didCrit = critChance >= Random.Range(0, 101);
            if (didCrit)
            {
                SoundDatabase.PlaySound(11);
                BattleUI.TextAdd(user, 30, "cyan", "critically striked!");
                //// Crit Multiplier
                int bonus = (user.critMulti.totalAmount + skill.skillCritMulti);
                float calcBonus = bonus / 100f;
                float putBonus = damage * calcBonus;
                damage = (int)(putBonus);
            }
            // if damage less than 0, damage = 0 so no heal
            if (damage < 0)
            {
                damage = 0;
            }
            // bonus
            else
            {
                damage += Random.Range(0, 11 + user.luck.totalAmount * 2);
            }
            ////// Damage Calculation
            FinalCalculationModifier(user, victim, skill, damage);
            // End
            SoundDatabase.PlaySound(skill.skillSoundID);
            //user.SimpleStatUpdate();
        }
        else // missed
        {
            BattleUI.TextAdd(user, 30, "blue", "missed!");
            SoundDatabase.PlaySound(0);
        }
        BattleUI.UpdateEnemySliders();
        StatusBar.UpdateSliders();
        // Crit Chance
        //bool ifHit = StatUtilities.
    }
    public static IEnumerator StartBattle(Stats player, Stats enemy, Skill playeruseskill) // once we know what skill the player wants to use, we can start a battle.
    {
        // speed calculation goes here
        //
        BattleUI.NextTurn();
        BattleUI.ResetScrollsPosition();
        // disable all images as we need the skill page to be active
        SkillPageImagesOn(false);
        // disable all buttons (basically cant do anything
        GameManager.InvisibleWallOn(true);
        // reset text
        BattleUI.TextReset();
        // battle
        if (playeruseskill.skillType == Skill.SkillType.Active)
        {
            SkillActive(player, playeruseskill);

        }
        else
        {
            SkillAttack(player, enemy, playeruseskill);
        }
        yield return new WaitForSeconds(1.1f);
        // checking if dead after first move
        if (enemy.health <= 0)
        {
            enemyDead = true;
        }
        else
        {
            // apply status effects
            foreach (Transform status in BattleUI.enemyStatus)
            {
                if (ApplyStatusEff(player, enemy, status.GetComponent<StatusHolder>().status))
                {
                    yield return new WaitForSeconds(1.1f);
                }
                if (enemy.health <= 0)
                {
                    enemyDead = true;
                    break;
                }
            }
        }
        if (enemyDead)
        {
            BattleUI.TextAdd(enemy, 25, "black", string.Format("has been defeated!"));
            yield return new WaitForSeconds(1.1f);
            VictoryScreen.victoryScreen.FindChild("Text").GetComponent<Text>().text
                = string.Format("You defeated {0}!\nGained: {1} Cash, {2} EXP\nKeep exploring the dungeon?", enemy.mingZi, enemy.cash, enemy.experience);
            player.cash += enemy.cash;
            InvEq.UpdateCashText();
            player.experience += enemy.experience;
            StatusBar.UpdateSliders();
            if (player.experience >= player.maxExperience)
            {
                GameManager.OpenClosePage("Invisible Wall");
                GameManager.OpenClosePage("Level Up Screen");
                StatPage.OpenCloseCelebration(true);
                SoundDatabase.bgmSource.Pause();
                SoundDatabase.PlaySound(36);
                yield return new WaitForSeconds(1.75f);
                StatPage.OpenCloseCelebration(false);
                PlayerStats.LevelUp();
                StatPage.SetCurrentStats();
                StatPage.UpdateText();
            }
            GameManager.InvisibleWallOn(false);
            VictoryScreen.OpenCloseVictoryScreen();
            //Battle.EndBattle();
        }
        else
        {
            // enemy attack
            if (enemyCanAttack)
            {
                SkillAttack(enemy, player, EnemyHolder.enemy.skills[Random.Range(0, EnemyHolder.enemy.skills.Count)]);
            }
            //if (player.statuses.Count != 0)
            //{
            //    yield return new WaitForSeconds(1.1f);
            //}
            // check if player died
            //foreach (Transform status in BattleUI.playerStatus)
            //{
            //    if (ApplyStatusEff(enemy, player, status.GetComponent<StatusHolder>().status)) // if it is a status not an active
            //    {
            //        yield return new WaitForSeconds(1.1f);
            //    }
            //}
            TurnEndChecker(player, playeruseskill);
            TurnEndChecker(enemy, playeruseskill);
        }
        SkillPageImagesOn(true);
        // return to normals
        GameManager.InvisibleWallOn(false);
        if (SkillPage.skillPage.gameObject.activeInHierarchy)
        {
            GameManager.OpenClosePage("Skill Page");
        }
        enemyCanAttack = true;
        enemyDead = false;
    }

    static void SkillPageImagesOn(bool yes)
    {
        for (int i = 0; i < SkillPage.skillPage.FindChild("Skills").transform.childCount; i += 1)
        {
            SkillPage.skillPage.FindChild("Skills").transform.GetChild(i).GetComponent<Image>().enabled = yes;
        }
        SkillPage.skillPage.GetComponent<Image>().enabled = yes;
        SkillPage.learnedSkillsButton.gameObject.SetActive(yes);
        //SkillPage.skillPoints.gameObject.SetActive(yes);
        SkillPage.closeButton.gameObject.SetActive(yes);
        SkillPage.leftButton.gameObject.SetActive(yes);
        SkillPage.rightButton.gameObject.SetActive(yes);
        SkillPage.pageNum.gameObject.SetActive(yes);
    }

}