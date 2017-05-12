using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {
    public static GameObject playerCopy;
    public static Transform battleUI;
    public static Button run;
    public static Button skills;
    public static Slider enemyHP;
    public static Slider enemyMP;
    public static Transform playerStatus;
    public static Transform enemyStatus;
    public static Transform playerScroll;
    public static Transform enemyScroll;
    public static Text turn;
    public static Text enemyName;
    public static Text quickSkillNotifier;
    public static Text quickSkillDesc;
    public static Text battling;
    public static Transform quickSkills;
    public Transform statusHolderPrefab;

    void Start()
    {
        battleUI = gameObject.transform;
        battling = battleUI.FindChild("Battling").GetComponent<Text>();
        playerScroll = battleUI.FindChild("Player Text Scroll");
        enemyScroll = battleUI.FindChild("Enemy Text Scroll");
        //playerCopy = battleUI.FindChild("Player Copy").gameObject;
        enemyHP = battleUI.FindChild("Enemy Box").FindChild("Enemy HP").GetComponent<Slider>();
        enemyMP = battleUI.FindChild("Enemy Box").FindChild("Enemy MP").GetComponent<Slider>();
        skills = battleUI.FindChild("Player Box").FindChild("Skills").GetComponent<Button>();
        run = battleUI.FindChild("Player Box").FindChild("Run").GetComponent<Button>();
        quickSkills = battleUI.FindChild("Player Box").FindChild("Quick Skills");
        playerStatus = battleUI.FindChild("Player Status");
        enemyStatus = battleUI.FindChild("Enemy Status");
        enemyName = battleUI.FindChild("Enemy Box").FindChild("Enemy Name").GetComponent<Text>();
        turn = battleUI.FindChild("Player Box").FindChild("Turn").GetComponent<Text>();
        quickSkillNotifier = battleUI.FindChild("Player Box").FindChild("Quick Skills Notifier").GetComponent<Text>();
        quickSkillDesc = battleUI.FindChild("Player Box").FindChild("Quick Skills Desc").GetComponent<Text>();
        skills.onClick.AddListener(SkillPage.InstantLearnedSkillPage);

        run.onClick.AddListener(Battle.EndBattle);
        //GameManager.OpenClosePage("InventoryEquipment");
    }
    public static void RemoveStatus(Transform who, int id)
    {
        foreach (Transform status in who)
        {
            if (status.GetComponent<StatusHolder>().status.statusID == id)
            {
                Destroy(status.gameObject);
            }
        }
    }
    public static void RemoveActive(Transform who, int id)
    {
        foreach (Transform skill in who)
        {
            if (skill.GetComponent<StatusHolder>().skill.skillID == id)
            {
                Destroy(skill.gameObject);
}
        }
    }
      

    public static void ResetPlayerStatus()
    {
        foreach (Transform status in playerStatus)
        {
            status.GetComponent<StatusHolder>().skill.skillOnCooldown = false;
            Destroy(status.gameObject);
        }
    }

    public static void ResetEnemyStatus()
    {
        foreach (Transform status in enemyStatus)
        {
            status.GetComponent<StatusHolder>().skill.skillOnCooldown = false;
            Destroy(status.gameObject);
        }
    }

    public static void ResetAllStatus()
    {
        ResetPlayerStatus();
        foreach (List<Skill> page in PlayerSkills.learnedSkills)
        {
            foreach (Skill skill in page)
            {
                skill.skillOnCooldown = false;
            }
        }
        ResetEnemyStatus();
    }

    public static void AddStatus(Stats user, Status status)
    {
        Transform who;
        if (user == PlayerStats.stats)
        {
            who = playerStatus;
        }
        else
        {
            who = enemyStatus;
        }
        Transform newStatus = Instantiate(battleUI.GetComponent<BattleUI>().statusHolderPrefab, who);
        newStatus.transform.localScale = new Vector3(1, 1, 1);
        newStatus.GetComponent<StatusHolder>().status = status;
        newStatus.GetComponent<StatusHolder>().UpdateStatus();
    }
    public static void AddStatus(Stats user, Skill skill)
    {
        Transform who;
        if (user == PlayerStats.stats)
        {
            who = playerStatus;
        }
        else
        {
            who = enemyStatus;
        }
        Transform newStatus = Instantiate(battleUI.GetComponent<BattleUI>().statusHolderPrefab, who);
        newStatus.transform.localScale = new Vector3(1, 1, 1);
        newStatus.GetComponent<StatusHolder>().skill = skill;
        newStatus.GetComponent<StatusHolder>().turnEnd = Battle.turnCount + skill.skillDuration;
        AddCooldown(skill);
        newStatus.GetComponent<StatusHolder>().UpdateStatus();
    }

    public static void AddCooldown(Skill skill)
    {
        skill.skillCooldownEnd = Battle.turnCount + skill.skillCooldown;
        skill.skillOnCooldown = true;
    }

    //public static void UpdateAllStatusHolder(Stats victim)
    //{
    //    Transform who;
    //    if (victim == EnemyHolder.enemy.stats)
    //    {
    //        who = enemyStatus;
    //    }
    //    else
    //    {
    //        who = playerStatus;
    //    }
    //    int i = 0;
    //    foreach(Status status in victim.statuses)
    //    {
    //        who.GetChild(i).GetComponent<StatusHolder>().status = status;
    //        who.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
    //        i += 1;
    //     }

    //}

    public static void MovePlayer(Transform parent)
    {
        if (GameManager.OpenClosePage("InventoryEquipment"))
        {
            GameManager.OpenClosePage("InventoryEquipment");
        }
        PlayerImage.playerImageGameObject.transform.SetParent(parent);
        if (GameManager.inBattle)
        {
            PlayerImage.playerImageGameObject.GetComponent<Image>().SetNativeSize();
            PlayerImage.playerImageGameObject.transform.localPosition = new Vector3(0, 0);
        }
        else
        {
            PlayerImage.playerImageGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(298,276);
            PlayerImage.playerImageGameObject.transform.localPosition = new Vector3(0, 0);
        }
        GameManager.OpenClosePage("InventoryEquipment");
    }

    public static void NextTurn()
    {
        Battle.turnCount += 1;
        turn.text = "Turn: " + Battle.turnCount.ToString();
    }

    public static void TextReset()
    {
        playerScroll.GetComponentInChildren<Text>().text = "\n";
        enemyScroll.GetComponentInChildren<Text>().text = "\n";
    }

    public static void TextAdd(Stats who, int size, string color, string desc)
    {
        Transform whoScroll;
        if (who == PlayerStats.stats)
        {
            whoScroll = playerScroll;
            playerScroll.GetComponentInChildren<Text>().text += string.Format("<size={0}><color={1}>You {2}</color></size>\n", size, color, desc);
        }
        else
        {
            whoScroll = enemyScroll;
            enemyScroll.GetComponentInChildren<Text>().text += string.Format("<size={0}><color={1}>{2} {3}</color></size>\n", size, color, who.mingZi, desc);

        }
        ScrollBump(whoScroll);
    }

    public static void TextAdd(Stats who, int size, string desc)
    {
        Transform whoScroll;
        if (who == PlayerStats.stats)
        {
            whoScroll = playerScroll;
        }
        else
        {
            whoScroll = enemyScroll;
        }
        whoScroll.GetComponentInChildren<Text>().text += string.Format("<size={0}><color=black>{1}</color></size>\n", size, desc);
        ScrollBump(whoScroll);
    }

    public static void ScrollBump(Transform whoScroll)
    {
        int lol = 0;
        for (int i = 0; i < enemyScroll.GetComponentInChildren<Text>().text.Length; i++)
        {
            if (enemyScroll.GetComponentInChildren<Text>().text[i] == '\n')
            {
                lol += 1;
            }
        }
        if (lol >= 6)
        {
            enemyScroll.GetComponentInChildren<Scrollbar>().value = 1 - lol * 0.045f;
        }
    }

    public static void ResetScrollsPosition()
    {
        playerScroll.GetComponentInChildren<Scrollbar>().value = 1;
        enemyScroll.GetComponentInChildren<Scrollbar>().value = 1;
    }

    public static void UpdateEnemySliders()
    {
        SliderUtilities.UpdateSliderFillWithText(enemyHP, EnemyHolder.enemy.stats.health, EnemyHolder.enemy.stats.maxHealth.totalAmount, "HP: ", "Enemy HP Text");
        SliderUtilities.UpdateSliderFillWithText(enemyMP, EnemyHolder.enemy.stats.mana, EnemyHolder.enemy.stats.maxMana.totalAmount, "MP: ", "Enemy MP Text");
    }
}
