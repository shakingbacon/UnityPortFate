using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{

    // Inventory Equipment
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemEquipped;
    public static event ItemEventHandler OnItemUnequipped;

    public delegate void MoneyEventHandler(int amount);
    public static event MoneyEventHandler OnMoneyAdd;

    public delegate void ItemNoneEventHandler();
    public static event ItemNoneEventHandler OnItemRemovedFromInventory;

    // Player
    public delegate void PlayerHealthEventHandler();
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;
    public static event PlayerHealthEventHandler OnPlayerManaChanged;

    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevelChanged;
    public static event PlayerLevelEventHandler OnPlayerExpChanged;

    // Skill
    public delegate void SkillEventHandler(PlayerSkill skill);
    public static event SkillEventHandler OnSkillLearn;

    public delegate void SkillNoneEventHandler();
    public static event SkillNoneEventHandler OnSkillUse;

    public delegate void SPChanged();
    public static event SPChanged OnSPChange;

    // Quest
    public delegate void QuestEventHandler(Quest quest);
    public static event QuestEventHandler OnQuestAccepted;

    public static void SpChanged()
    {
        OnSPChange();
    }



    public static void ExpChanged()
    {
        OnPlayerExpChanged();
    }

    public static void MoneyAdded(int amount)
    {
        EventNotifier.Instance.MakeEventNotifier(string.Format("Obtained: ({0}) Cash", amount));
        OnMoneyAdd(amount);
    }

    public static void QuestAccepted(Quest quest)
    {
        OnQuestAccepted(quest);
    }

    public static void SkillUsed() { OnSkillUse(); }

    public static void SkillLearned(PlayerSkill skill)
    {
        OnSkillLearn(skill);
    }

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    public static void ItemUnequipped(Item item)
    {
        OnItemUnequipped(item);
    }

    public static void ItemRemovedFromInventory()
    {
        OnItemRemovedFromInventory();
    }

    public static void HealthChanged()
    {
        OnPlayerHealthChanged();
    }

    public static void ManaChanged()
    {
        OnPlayerManaChanged();
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
        PlayerSkillUpdate.UpdateSkills();
    }

    public static void PlayerLevelChanged()
    {
        OnPlayerLevelChanged();
    }
}
