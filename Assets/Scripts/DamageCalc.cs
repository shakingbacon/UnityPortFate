using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageCalc : MonoBehaviour
{
    public static DamageCalc damageCalc;
    static Skill playerUseSkillCopy;
    public static bool enemyCanAttack = true;
    public static bool enemyDead = false;

    void Start()
    {
        damageCalc = gameObject.GetComponent<DamageCalc>();
    }

    public static int BasicDamageReduction(Mortal user, Mortal victim, Skill.SkillType skilltype, int damage)
    {
        int dmg;
        if (skilltype == Skill.SkillType.True)
        {
            dmg = (int)((damage * (user.dmgOutput.totalAmount / 100f)) * (victim.dmgTaken.totalAmount / 100f));
        }
        else if (skilltype == Skill.SkillType.Physical)
        {
            dmg = (int)((damage * (user.dmgOutput.totalAmount / 100f) - victim.armor.totalAmount) * (victim.dmgTaken.totalAmount / 100f));
        }
        else // magical
        {
            dmg = (int)((damage * (user.dmgOutput.totalAmount / 100f) - victim.resist.totalAmount) * (victim.dmgTaken.totalAmount / 100f));
        }
        if (dmg <= 0)
        {
            dmg = 0;
        }
        return dmg;
    }

    public static int DmgModifier(Mortal user, Mortal victim, Skill skill)
    {
        int dmg;
        dmg = BasicDamageReduction(user, victim, skill.skillType, skill.skillDamage);
        Transform who = BattleUI.WhoseStatus(user);
        foreach (Transform status in who)
        {
            if (status.GetComponent<StatusHolder>().skill.skillID != -1)
            {
                Skill statusSkill = status.GetComponent<StatusHolder>().skill;
                switch (statusSkill.skillID)
                {
                    case 7:
                        {
                            if (skill.skillType == Skill.SkillType.Magical)
                            {
                                dmg = (int)(dmg * (statusSkill.skillDamage / 100f));
                                BattleUI.TextAdd(user, 18, string.Format("{0} is charged from {1}", skill.skillName, statusSkill.skillName));
                                BattleUI.RemoveStatus(who, statusSkill.skillID);
                            }
                            break;
                        }
                }
            }
        }
        return dmg;
    }

    public static int HitChanceModifier(Mortal user, Mortal victim, Skill skill)
    {
        int hit = user.hitChance.totalAmount + skill.skillHitChance - victim.dodgeChance.totalAmount;
        return hit;
    }

    public static int CritChanceModifier(Mortal user, Mortal victim, Skill skill)
    {
        int crit = user.critChance.totalAmount + skill.skillCritChance;
        return crit;
    }

    public static void CheckSkillStatusEff(Mortal user, Mortal victim, Skill skill)
    {
        foreach (Skill status in skill.skillStatusEff.statusList)
        {
            if (status.skillHitChance > Random.Range(0, 101))
            {
                switch (status.skillID)
                {
                    case 1000:
                        {
                            BattleUI.TextAdd(victim, 26, "red", string.Format("has been Burned!"));
                            break;
                        }
                    case 1001:
                        {
                            BattleUI.TextAdd(victim, 26, "yellow", string.Format("became Paralyzed!"));
                            break;
                        }
                    case 1006:
                        {
                            BattleUI.TextAdd(victim, 26, "orange", string.Format("became Confused!"));
                            foreach (Skill aSkill in user.GetSkillList())
                            {
                                switch (aSkill.skillID)
                                {
                                    case 37:
                                        {
                                            print("leggo");
                                            victim.dmgTaken.buffedAmount += aSkill.skillHitChance;
                                            victim.SimpleStatUpdate();
                                            print(victim.dmgTaken.totalAmount);
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                }
                BattleUI.AddStatus(victim, status);
            }

        }
        //BattleUI.UpdateAllStatusHolder(victim);
    }

    public static IEnumerator ApplyStatusEff(Mortal user, Mortal victim, Skill status, bool last)
    {
        if (status.skillID != -1)
        {
            switch (status.skillID)
            {
                case 1000:
                    {
                        SoundDatabase.PlaySound(35);
                        int damage = (victim.maxHealth.totalAmount / 10 - Random.Range(0, victim.maxHealth.totalAmount / 100))
                            + Random.Range(0, 10 + victim.maxHealth.totalAmount / 80);
                        victim.health -= damage;
                        BattleUI.TextAdd(victim, 26, "red", string.Format("took {0} burn damage", damage));
                        BattleUI.UpdateEnemySliders();
                        StatusBar.UpdateSliders();
                        yield return new WaitForSeconds(1.1f);
                        break;
                    }
                case 1001:
                    {
                        SoundDatabase.PlaySound(37);
                        BattleUI.TextAdd(victim, 26, "yellow", string.Format("is Paralyzed"));
                        yield return new WaitForSeconds(1.1f);
                        if (Random.Range(0, 101) >= 50)
                        {
                            SoundDatabase.PlaySound(37);
                            BattleUI.TextAdd(victim, 26, "yellow", string.Format("couldn't move!"));
                            if (!last)
                                yield return new WaitForSeconds(1.1f);
                            enemyCanAttack = false;
                        }
                        break;
                    }
                case 1006:
                    {
                        SoundDatabase.PlaySound(46);
                        BattleUI.TextAdd(victim, 26, "orange", string.Format("is Confused"));
                        yield return new WaitForSeconds(1.1f);
                        if (Random.Range(0, 101) >= 50)
                        {
                            int damage = victim.physAtk.totalAmount / 2;
                            victim.health -= damage;
                            BattleUI.TextAdd(victim, 26, "red", string.Format("hurt itself for {0} True Damage", damage));
                            BattleUI.UpdateEnemySliders();
                            StatusBar.UpdateSliders();
                            SoundDatabase.PlaySound(-1);
                            if (!last)
                                yield return new WaitForSeconds(1.1f);
                            enemyCanAttack = false;
                        }
                        break;
                    }
                case 1007:
                    {
                        SoundDatabase.PlaySound(12);
                        int damage = (victim.maxHealth.totalAmount / 6 - Random.Range(0, victim.maxHealth.totalAmount / 100))
                            + Random.Range(0, 10 + victim.maxHealth.totalAmount / 80);
                        victim.health -= damage;
                        BattleUI.TextAdd(victim, 26, "red", string.Format("took {0} curse damage", damage));
                        BattleUI.UpdateEnemySliders();
                        StatusBar.UpdateSliders();
                        yield return new WaitForSeconds(1.1f);
                        break;
                    }
            }
        }
    }

    public static bool IsSkill(Transform holder)
    {
        bool isSkill = false;
        if (holder.GetComponent<StatusHolder>().skill.skillID != -1)
        {
            isSkill = true;
        }
        else
        {
            isSkill = false;
        }
        return isSkill;
    }

    public static void SkillModifier(Mortal user, Mortal victim, Skill skill)
    {
        // passives
        foreach (Skill passive in victim.GetSkillList())
        {
            if (passive.skillType == Skill.SkillType.Passive)
            {
                switch (passive.skillID)
                {
                    case 38:
                        {
                            int reduce = Battle.turnCount * passive.skillHitChance;
                            skill.skillDamage = (int)(skill.skillDamage * (1 - reduce/ 100f));
                            break;
                        }
                    case 40:
                        {
                            skill.skillDamage = (int)(skill.skillDamage * (1 + passive.skillDamage / 100f));
                            break;
                        }
                }
            }
        }
        foreach (Skill passive in user.GetSkillList())
        {
            if (passive.skillType == Skill.SkillType.Passive)
            {
                switch (passive.skillID)
                {
                    case 40:
                        {
                            skill.skillDamage = (int)(skill.skillDamage * (1 + passive.skillDamage / 100f));
                            break;
                        }
                }
            }
        }
        // this is should be used for attacking skills, if an attacking skill would have a cooldown, would need to find it in the player skill list and give it as it would only give the copied skill the cooldown.
        foreach (Transform status in BattleUI.WhoseStatus(user))
        {
            if (IsSkill(status))
            {
                Skill statusSkill = status.GetComponent<StatusHolder>().skill;
                switch (statusSkill.skillID)
                {
                    case 18:
                        {
                            skill.skillDamage += statusSkill.skillDamage;
                            skill.skillStatusEff.AddStatusChance(1, statusSkill.skillHitChance);
                            skill.skillCritChance += statusSkill.skillCritChance;
                            skill.skillManaCost = (int)(skill.skillManaCost * (statusSkill.skillCritMulti / 100f));
                            break;
                        }
                    case 32:
                        {
                            if (skill.skillStatusEff.HasStatus(0))
                            {
                                skill.skillStatusEff.AddPercentStatusChance(0, statusSkill.skillManaCost);
                            }
                            break;
                        }
                    case 33:
                        {
                            if (skill.skillStatusEff.GetStatusChance(6) != 0)
                            {
                                skill.skillDamage += (int)(skill.skillDamage * (skill.skillStatusEff.GetStatusChance(6) / 100f * 8));
                                skill.skillStatusEff.SetStatusChance(6, 0);
                            }
                            break;
                        }
                }
            }
            //else
            //{
            //    Status status = status.GetComponent<StatusHolder>().status;
            //}

        }
        Transform victimStatus = BattleUI.WhoseStatus(victim);
        foreach (Transform status in victimStatus) // if opponent has debuff
        {
            if (IsSkill(status))
            {

            }
            else
            {
                Skill statusSkill = status.GetComponent<StatusHolder>().skill;
                switch (statusSkill.skillID)
                {
                    case 8:
                        {
                            if (skill.skillID == 4)
                            {
                                BattleUI.RemoveStatus(victimStatus, 8);
                                skill.skillDamage = (int)(skill.skillDamage * (1 + user.FindSkill(22).skillHitChance / 100f));
                                BattleUI.TextAdd(user, 17, "yellow", string.Format("dealt more damage from {0}", user.FindSkill(22).skillName));
                            }
                            break;
                        }
                }
            }
        }
    }


    public static void AttackingStatusEffectActivations(Mortal user, Mortal victim, int dmg)
    {
        Transform who = BattleUI.WhoseStatus(user);
        foreach (Transform status in who)
        {
            Skill statusSkill = status.GetComponent<StatusHolder>().skill;
            switch (statusSkill.skillID)
            {
                case 17:
                    {
                        int damageWillTake = (int)(dmg * (statusSkill.skillCritChance / 100f));
                        int reduced = BasicDamageReduction(user, user, Skill.SkillType.True, damageWillTake); // this case where the damage output and taken is the user
                        user.health -= reduced;
                        BattleUI.TextAdd(user, 17, "green", string.Format("took {0} True damage from {1}", reduced, statusSkill.skillName));
                        break;
                    }
            }
        }       
    }

    public static void AttackingPassiveEffectActivations(Mortal user, Mortal victim, Skill skill)
    {
        if (user == Battle.player)
        {
            for (int i = 0; i < user.skills.Count; i += 1)
            {
                foreach (Skill passiveSkill in user.skills[i])
                {
                    if (passiveSkill.skillType == Skill.SkillType.Passive)
                    {
                        switch (passiveSkill.skillID)
                        {
                            case 8:
                                {
                                    if (Random.Range(0, 100) < passiveSkill.skillManaCost)
                                    {
                                        int manaHeal = (int)(skill.skillManaCost * (passiveSkill.skillCritChance / 100f));
                                        user.HealMP(manaHeal);
                                        BattleUI.TextAdd(user, 17, "black", string.Format("gained {0} Mana from {1}", manaHeal, passiveSkill.skillName));
                                    }
                                    break;
                                }
                            case 22:
                                {
                                    if (skill.skillID == 2 && Random.Range(0, 100) < passiveSkill.skillDamage)
                                    {
                                        BattleUI.AddStatus(victim, new Skill(SkillDatabase.GetSkill(1008)));
                                        BattleUI.TextAdd(user, 17, "blue", string.Format("applied Soaked debuff to enemy"));
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < victim.skills.Count; i += 1)
            {
                foreach (Skill passiveSkill in victim.skills[i])
                {
                    if (passiveSkill.skillType == Skill.SkillType.Passive)
                    {
                        switch (passiveSkill.skillID)
                        {
                            case 36:
                                {
                                    if (skill.skillType == Skill.SkillType.Physical && Random.Range(0, 100) < passiveSkill.skillDamage)
                                    {
                                        Skill burn = new Skill(SkillDatabase.GetSkill(1000));
                                        burn.skillDuration = -1;
                                        BattleUI.AddStatus(user, burn);
                                        BattleUI.TextAdd(user, 22, "red", string.Format("has been by Burned Scorched Touch!"));
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }

    public static void FinalCalculationModifier(Mortal user, Mortal victim, Skill.SkillType skilltype, int dmg)
    {
        Transform who = BattleUI.WhoseStatus(victim);
        bool doNormalCalculation = true;
        // defensive damage calculation priorities
        List<Transform> userStatusCount = new List<Transform>();
        foreach (Transform status in who)
        {
            userStatusCount.Add(status);
        }
        // priority 1
        // shield
        if (StatusBar.hasShield)
        {
            if (victim.shield > 0)
            {
                // shield breaks
                if (victim.shield - dmg < 0)
                {
                    int willBeTaking = dmg - victim.shield;
                    victim.health -= willBeTaking;
                    BattleUI.TextAdd(user, 17, "black", string.Format("broke the shield for {0} {1} damage", victim.shield, skilltype));
                    if (userStatusCount.Exists(status => status.GetComponent<StatusHolder>().skill.skillID == 5))
                    {
                        ManaGaurdCalc(user, victim, willBeTaking, skilltype);
                    }
                    else
                    {
                        BattleUI.TextAdd(user, 17, "black", string.Format("deals {0} {1} damage", willBeTaking, skilltype));
                    }
                    StatusBar.LoseShield();
                }
                else
                {
                    victim.shield -= dmg;
                    BattleUI.TextAdd(user, 20, "black", string.Format("dealt {0} damage to shield", dmg));
                    if (victim.shield == 0)
                    {
                        StatusBar.LoseShield();
                    }
                }
                StatusBar.UpdateShield();
                doNormalCalculation = false;
            }
        }
        else if (userStatusCount.Exists(status => status.GetComponent<StatusHolder>().skill.skillID == 5))
        {
            ManaGaurdCalc(user, victim, dmg, skilltype);
            doNormalCalculation = false;
        }
        //foreach (Transform status in who)
        //{
        //    if (status.GetComponent<StatusHolder>().status.statusID != -1)
        //    {
        //        //switch (status.GetComponent<StatusHolder>().status.statusID)
        //        //{
        //        //    case 0:
        //        //        {
        //        //            break;
        //        //        }
        //        //}
        //    }
        //}
        if (doNormalCalculation)
        {
            victim.health -= dmg;
            if (user == Battle.player)
            {
                BattleUI.TextAdd(user, 25, "black", string.Format("deal {0} {1} damage", dmg, skilltype));
            }
            else
            {
                BattleUI.TextAdd(user, 25, "black", string.Format("deals {0} {1} damage", dmg, skilltype));
            }
        }
    }

    public static IEnumerator TurnEndChecker(Mortal user, Mortal victim)
    {
        Transform who = BattleUI.WhoseStatus(user);
        // check the duration end on battle status
        foreach (Transform status in who)
        {
            // duration is over
            if (status.GetComponent<StatusHolder>().turnEnd == Battle.turnCount)
            {
                // lose bonus effects
                yield return new WaitForSeconds(1.1f);
                SoundDatabase.PlaySound(41);
                LoseStatusBonus(user, victim, status.GetComponent<StatusHolder>());
                BattleUI.TextAdd(user, 25, string.Format("<color=red>{0} wore off</color>", status.GetComponent<StatusHolder>().skill.skillName));
                Destroy(status.gameObject);
            }
        }
        // check each skill in learned skill if cooldown is ended
        int i = 0;
        foreach (List<Skill> page in user.skills)
        {
            foreach (Skill aSkill in user.skills[i])
            {
                if (aSkill.skillID != -1)
                {
                    if (Battle.turnCount == aSkill.skillCooldownEnd)
                    {
                        switch (aSkill.skillID)
                        {
                            case 39:
                                {
                                    user.SetHP(0);
                                    break;
                                }
                        }
                        aSkill.skillOnCooldown = false; // removing cooldown in skills
                    }
                }
            }
            i += 1;
        }
    }

    public static void LoseStatusBonus(Mortal user, Mortal victim, StatusHolder statusholder)
    {
        // status
        // skills id
        Skill skill = statusholder.skill;
        switch (skill.skillID)
        {
            case 13:
                {
                    StatusBar.LoseShield();
                    break;
                }
            case 15:
                {
                    user.armor.buffedAmount -= skill.skillCritChance;
                    user.resist.buffedAmount -= skill.skillCritChance;
                    break;
                }
            case 16:
                {
                    user.armor.buffedAmount -= skill.skillCritChance * skill.skillHitChance;
                    user.resist.buffedAmount -= skill.skillCritChance * skill.skillHitChance * 2;
                    break;
                }
            case 17:
                {
                    user.manaComs.buffedAmount -= skill.skillDamage;
                    user.dmgOutput.buffedAmount -= skill.skillHitChance;
                    user.dmgTaken.buffedAmount -= skill.skillHitChance;
                    break;
                }
            case 31:
                {
                    user.armor.buffedAmount -= skill.skillCritChance;
                    user.resist.buffedAmount -= skill.skillCritMulti;
                    break;
                }
            case 34:
                {
                    user.dodgeChance.buffedAmount -= skill.skillDamage;
                    user.critChance.buffedAmount -= skill.skillHitChance;
                    break;
                }
            case 1006:
                {
                    if (victim.GetSkillList().Exists(aSkill => aSkill.skillID == 37))
                    {
                        user.dmgTaken.buffedAmount -= victim.FindSkill(37).skillHitChance;
                    }
                    break;
                }
        }
        user.SimpleStatUpdate();
    }

    public static void LoseAllPlayerStatusEffects()
    {
        foreach (Transform status in BattleUI.playerStatus)
        {
            LoseStatusBonus(GameManager.player, Battle.enemy, status.GetComponent<StatusHolder>());
            Destroy(status.gameObject);
        }
    }

    public static void SkillActive(Mortal user, Mortal victim, Skill skill)
    {
        //Transform who;
        //Transform whoVictim;
        //if (user == Battle.player)
        //{
        //    who = BattleUI.playerStatus;
        //    whoVictim = BattleUI.enemyStatus;
        //}
        //else
        //{
        //    whoVictim = BattleUI.playerStatus;
        //    who = BattleUI.enemyStatus;
        //}
        BattleUI.TextAdd(user, 30, "#000000ff", "used " + skill.skillName);
        user.mana -= skill.skillManaCost;
        // actives that dont add status pic
        List<int> dontAddToStatus = new List<int>(new int[] {6, 16, 17, 43});
        if (!dontAddToStatus.Exists(id => id == skill.skillID))
        {
            BattleUI.AddStatus(user, skill);
        }
        // activate effect at activation of skill
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
                    StatusBar.SetNewShield();
                    BattleUI.TextAdd(user, 30, "orange", string.Format("gained a {0} HP Shield", skill.skillDamage));
                    break;
                }
            case 15:
                {
                    user.armor.buffedAmount += skill.skillCritChance;
                    user.resist.buffedAmount += skill.skillCritChance;
                    user.SimpleStatUpdate();
                    break;
                }
            case 16:
                {
                    skill.skillCritChance = 0;
                    int healAmount = 0;
                    foreach(Transform status in BattleUI.WhoseStatus(user))
                    {
                        skill.skillCritChance += 1;
                    }
                    LoseAllPlayerStatusEffects();
                    healAmount = skill.skillCritChance * skill.skillDamage;
                    user.HealHP(healAmount);
                    user.armor.buffedAmount += skill.skillCritChance * skill.skillHitChance;
                    user.resist.buffedAmount += skill.skillCritChance * skill.skillHitChance * 2;
                    BattleUI.TextAdd(user, 30, "red", string.Format("healed for {0} HP", healAmount));
                    user.SimpleStatUpdate();
                    BattleUI.AddStatus(user, skill); // special case where we need to add the status after effect
                    break;
                }
            case 17:
                {
                    BattleUI.AddStatus(victim, skill);
                    victim.manaComs.buffedAmount += skill.skillDamage;
                    victim.dmgOutput.buffedAmount += skill.skillHitChance;
                    victim.dmgTaken.buffedAmount += skill.skillHitChance;
                    victim.SimpleStatUpdate();
                    break;
                }
            case 31:
                {
                    int healAmount = 0;
                    // Stored values are here
                    skill.skillCritChance = (int)(victim.physAtk.totalAmount * (skill.skillDamage / 100f));
                    skill.skillCritMulti = (int)(victim.magicAtk.totalAmount * (skill.skillDamage / 100f));
                    user.armor.buffedAmount += skill.skillCritChance;
                    user.resist.buffedAmount += skill.skillCritMulti;
                    healAmount = (int)(victim.health * (skill.skillHitChance / 100f));
                    user.HealHP(healAmount);
                    BattleUI.TextAdd(user, 30, "red", string.Format("healed for {0} HP", healAmount));
                    user.SimpleStatUpdate();
                    break;
                }
            case 34:
                {
                    user.dodgeChance.buffedAmount += skill.skillDamage;
                    user.critChance.buffedAmount += skill.skillHitChance;
                    break;
                }

        }
        SoundDatabase.PlaySound(skill.skillSoundID);
        BattleUI.UpdateEnemySliders();
        StatusBar.UpdateSliders();
    }

    public static void VictimModifier(Mortal user, Mortal victim)
    {
        foreach (Skill skill in user.GetSkillList())
        {
            switch (skill.skillID)
            {
                case 37:
                    {
                        foreach (Skill status in BattleUI.WhoseStatus(victim))
                        {
                            if (status.skillID == 1006)
                            {
                                victim.dmgTaken.buffedAmount += skill.skillHitChance;
                                break;
                            }
                        }
                        break;
                    }
            }
        }
    }

    public static void SkillAttack(Mortal user, Mortal victim, Skill skill)
    {
        
        SkillModifier(user, victim, skill);
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
            // Apply Status effects ex. Burn
            CheckSkillStatusEff(user, victim, skill);
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
            ////// Damage Calculation
            FinalCalculationModifier(user, victim, skill.skillType, damage);
            AttackingStatusEffectActivations(user, victim, damage);
            AttackingPassiveEffectActivations(user, victim, skill);
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


    public static IEnumerator StartBattle(Mortal player, Mortal enemy, Skill playeruseskill) // once we know what skill the player wants to use, we can start a battle.
    {
        BattleUI.battling.gameObject.SetActive(true);
        BattleUI.NextTurn();
        BattleUI.ResetScrollsPosition();
        // disable all images as we need the skill page to be active
        SkillPageImagesOn(false);
        // disable all buttons (basically cant do anything
        GameManager.InvisibleWallOn(true);
        // reset text
        BattleUI.TextReset();
        //////////////////
        // battle
        // speed calculation goes here
        playerUseSkillCopy = new Skill(playeruseskill);
        print(playerUseSkillCopy.skillID);

        // run
        if (playeruseskill.skillID == 43)
        {
            print("LOL");
            yield return RunAway(player);
        }
        if (GameManager.inBattle)
        {
            Mortal firstAttacker = player;
            Mortal secondAttacker = enemy;
            if (playerUseSkillCopy.skillType == Skill.SkillType.Active)
            {
                SkillActive(firstAttacker, secondAttacker, playeruseskill);
            }
            else
            {
                SkillAttack(firstAttacker, secondAttacker, playerUseSkillCopy);
            }
            yield return new WaitForSeconds(1.1f);
            // checking if dead after first move
            if (enemy.IsDead())
            {
                yield return EnemyDeadAfter(player, enemy);
            }
            else
            {
                // apply status effects after first attack
                yield return AfterAttackPassiveEffects(firstAttacker, secondAttacker);
                yield return AfterAttackStatusEffectApply(firstAttacker, secondAttacker, playerUseSkillCopy);
                // enemy attack (second attack, will be changing)
                if (enemy.IsDead())
                {
                    yield return EnemyDeadAfter(player, enemy);
                }
                else
                {
                    if (enemyCanAttack)
                    {
                        enemy.SimpleStatUpdate();
                        SkillAttack(secondAttacker, firstAttacker, enemy.skills[0][Random.Range(0, enemy.skills.Count)]);
                        DeathTriggers(firstAttacker);
                        yield return CheckPlayerDeath(player);
                        if (!player.IsDead())
                        {
                            yield return AfterAttackStatusEffectApply(secondAttacker, firstAttacker, playerUseSkillCopy);
                            // end turn effects
                            yield return EndTurnStatusEffects(BattleUI.playerStatus, player, enemy);
                        }
                    }
                    if (enemy.IsDead())
                    {
                        yield return EnemyDeadAfter(player, enemy);
                    }
                    else
                    {
                        yield return EndTurnStatusEffects(BattleUI.enemyStatus, player, enemy);
                    }
                }
                yield return TurnEndChecker(player, enemy);
                yield return TurnEndChecker(enemy, player);
            }
            // return to normals
            SkillPageImagesOn(true);
            GameManager.InvisibleWallOn(false);
            if (SkillPage.skillPage.gameObject.activeInHierarchy)
            {
                GameManager.OpenClosePage("Skill Page");
            }
            enemyCanAttack = true;
            enemyDead = false;
            BattleUI.battling.gameObject.SetActive(false);
            // update after effects
            player.SimpleStatUpdate();
            GameManager.player.FullUpdate();
            Battle.enemy.UpdateSkills();
        }
    }

    static void DeathTriggers(Mortal user)
    {
        if (user.IsDead())
        {
            foreach(Skill skill in user.GetSkillList())
            {
                switch (skill.skillID)
                {
                    case 39:
                        {
                            if (skill.skillManaCost != 1)
                            {
                                SoundDatabase.PlaySound(55);
                                BattleUI.TextAdd(user, 25, "red", string.Format("are brought back to life from {0}!", skill.skillName));
                                BattleUI.AddStatus(user, skill);
                                skill.skillCooldownEnd = skill.skillDuration + Battle.turnCount;
                                user.SetHP(skill.skillDamage);
                                skill.skillManaCost = 1;
                            }
                            break;
                        }
                }
            }
        }
    }

    static IEnumerator RunAway(Mortal user)
    {
        int chance = 30;
        if (Random.Range(0,101) <= chance)
        {
            SoundDatabase.PlaySound(23);
            BattleUI.TextAdd(user, 25, "green", string.Format("successfully ran away!"));
            yield return new WaitForSeconds(1.1f);
            Battle.EndBattle();
        }
        else
        {
            SoundDatabase.PlaySound(33);
            BattleUI.TextAdd(user, 25, "red", string.Format("failed to ran away!"));
            yield return new WaitForSeconds(1.1f);
        }
    }

    static IEnumerator CheckPlayerDeath(Mortal player)
    {
        if (player.IsDead())
        {
            BattleUI.TextAdd(player, 25, "red", string.Format("died!"));
            yield return new WaitForSeconds(1.1f);
            SoundDatabase.PlayMusic(13, false);
            GameManager.OpenClosePage("Death Screen");
        }
    }

    static IEnumerator AfterAttackPassiveEffects(Mortal user, Mortal victim)
    {
        foreach (Skill skill in user.GetSkillList())
        {
            if (skill.skillType == Skill.SkillType.Passive)
            {
                switch (skill.skillID)
                {
                    case 38:
                        {
                            int heal = Battle.turnCount * skill.skillDamage;
                            user.HealHP(heal);
                            SoundDatabase.PlaySound(14);
                            BattleUI.TextAdd(user, 25, "green", string.Format("healed {0} HP from {1}", heal, skill.skillName));
                            StatusBar.UpdateSliders();
                            yield return new WaitForSeconds(1.1f);
                            break;
                        }
                }
                if (victim.IsDead())
                {
                    break;
                }
            }
        }
    }

    static IEnumerator AfterAttackStatusEffectApply(Mortal user, Mortal victim, Skill playeruseskill)
    {
        Transform whoStatus = BattleUI.WhoseStatus(victim);
        foreach (Transform status in whoStatus)
        {
            bool lastStatus = false;
            if (status == whoStatus.GetChild(whoStatus.childCount - 1))
            {
                lastStatus = true;
            }
            yield return ApplyStatusEff(user, victim, status.GetComponent<StatusHolder>().skill, lastStatus);
            if (victim.IsDead())
            {
                break;
            }
        }
    }

    static IEnumerator EndTurnStatusEffects(Transform who, Mortal player, Mortal enemy)
    {
        List<int> endTurnSkillIDs = new List<int>(new int[] {15});
        foreach (Transform status in who)
        {
            Skill statusSkill = status.GetComponent<StatusHolder>().skill;
            if (endTurnSkillIDs.Exists(id => id == statusSkill.skillID))
            {
                if (statusSkill.skillID != -1)
                {
                    switch (statusSkill.skillID)
                    {
                        case 15:
                            {
                                if (Random.Range(0, 101) <= statusSkill.skillHitChance)
                                {
                                    yield return new WaitForSeconds(1.1f);
                                    SoundDatabase.PlaySound(38);
                                    enemy.health -= statusSkill.skillDamage;
                                    BattleUI.TextAdd(enemy, 17, "red", string.Format("took {0} {1} damage from exploded Volcano Shield", statusSkill.skillDamage, statusSkill.skillType));
                                    CheckSkillStatusEff(player, enemy, statusSkill);
                                }
                                break;
                            }
                    }
                }
                BattleUI.UpdateEnemySliders();
            }
        }
    }

    static IEnumerator EnemyDeadAfter(Mortal player, Mortal enemy)
    {
        if (!GameManager.inTutorial)
        {
            BattleUI.TextAdd(enemy, 25, "black", string.Format("has been defeated!"));
            yield return new WaitForSeconds(1.1f);
            LoseAllPlayerStatusEffects();
            VictoryScreen.AddDetails(string.Format("You defeated {0}!", enemy.mingZi));
            VictoryScreen.AddDetails(string.Format("Cash: +{0}", enemy.cash));
            VictoryScreen.AddDetails(string.Format("EXP: +{0}", enemy.experience));
            ActivatePassiveEffectsEnemyDead(player);
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
                player.LevelUp();
                GameManager.player.FullUpdate();
                player.HealFullHP();
                player.HealFullMP();
                StatPage.SetCurrentStats();
                StatPage.UpdateText();
            }
            GameManager.InvisibleWallOn(false);
            VictoryScreen.OpenCloseVictoryScreen();
        }
        else
        {
            BattleUI.TextAdd(enemy, 25, "black", string.Format("has been defeated!"));
            BattleUI.battling.gameObject.SetActive(false);
            yield return new WaitForSeconds(1.1f);
            SkillPageImagesOn(true);
            GameManager.InvisibleWallOn(false);
            Battle.EndBattle();
            Tutorial.battleDesc.gameObject.transform.parent.gameObject.SetActive(false);
            Tutorial.gotIt.gameObject.transform.parent.gameObject.SetActive(true);
            SoundDatabase.PlayMusic(0);
        }
    }


    static void ActivatePassiveEffectsEnemyDead(Mortal player)
    {
        for (int i = 0; i < player.skills.Count; i += 1)
        {
            foreach (Skill skill in player.skills[i])
            {
                if (skill.skillType == Skill.SkillType.Passive)
                {
                    switch (skill.skillID)
                    {
                        case 8:
                            {
                                if (Random.Range(0,100) <= skill.skillDamage)
                                {
                                    int manaHeal = (int)(player.maxMana.totalAmount * (skill.skillHitChance / 100f));
                                    player.HealMP(manaHeal);
                                    VictoryScreen.AddDetails(string.Format("Gained {0} Mana from {1}", manaHeal, skill.skillName));
                                }
                                break;
                            }
                    }
                }
            }
        }
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

    static void ManaGaurdCalc(Mortal user, Mortal victim, int dmg, Skill.SkillType skilltype)
    {
        if (victim.mana - dmg < 0)
        {
            BattleUI.TextAdd(user, 17, "black", string.Format("deals {0} {1} damage to your Mana", victim.mana, skilltype));
            victim.health -= dmg - victim.mana;
            victim.mana = 0;
            BattleUI.TextAdd(user, 20, "black", string.Format("deals {0} {1} damage", dmg - victim.mana, skilltype));
        }
        else
        {
            victim.mana -= dmg;
            BattleUI.TextAdd(user, 17, "black", string.Format("deals {0} {1} damage to your Mana", dmg, skilltype));
        }
    }

}