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
    public static Transform quickSkills;
    //public static GameObject playerCopy;

    void Start()
    {
        battleUI = gameObject.transform;
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
    }

    public static void ResetPlayerStatus()
    {
        for (int i = 0; i < playerStatus.childCount; i += 1)
        {
            if (playerStatus.GetChild(i).GetComponent<StatusHolder>().status.statusID == -1)
            {
                playerStatus.GetChild(i).GetComponent<StatusHolder>().status = new Status();
                playerStatus.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
            }
        }
    }

    public static void ResetEnemyStatus()
    {
        for (int i = 0; i < enemyStatus.childCount; i += 1)
        {
            if (enemyStatus.GetChild(i).GetComponent<StatusHolder>().status.statusID == -1)
            {
                enemyStatus.GetChild(i).GetComponent<StatusHolder>().status = new Status();
                enemyStatus.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
            }
        }
    }

    public static void ResetAllStatus()
    {
        for (int i = 0; i < playerStatus.childCount; i += 1)
        {
            if (playerStatus.GetChild(i).GetComponent<StatusHolder>().status.statusID != -1)
            {
                playerStatus.GetChild(i).GetComponent<StatusHolder>().status = new Status();
                playerStatus.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
            }
        }
        for (int i = 0; i < enemyStatus.childCount; i += 1)
        {
            if (enemyStatus.GetChild(i).GetComponent<StatusHolder>().status.statusID != -1)
            {
                enemyStatus.GetChild(i).GetComponent<StatusHolder>().status = new Status();
                enemyStatus.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
            }
        }
    }

    public static void AddStatus(Stats victim, Status status)
    {
        if (victim.statuses.Count == 6)
        {
            victim.statuses.RemoveAt(0);
            victim.statuses.Add(status);
        }
        else
        {
            victim.statuses.Add(status);
        }
    }

    public static void UpdateAllStatusHolder(Stats victim)
    {
        Transform who;
        if (victim == EnemyHolder.enemy.stats)
        {
            who = enemyStatus;
        }
        else
        {
            who = playerStatus;
        }
        int i = 0;
        foreach(Status status in victim.statuses)
        {
            who.GetChild(i).GetComponent<StatusHolder>().status = status;
            who.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
            i += 1;
         }

    }

    public static void CopyPlayer()
    {
        if (GameManager.OpenClosePage("InventoryEquipment"))
        {
            GameManager.OpenClosePage("InventoryEquipment");
        }
        playerCopy = Instantiate(GameObject.FindGameObjectWithTag("Player Image"), battleUI);
        playerCopy.GetComponent<Image>().SetNativeSize();
        playerCopy.transform.localPosition = new Vector3(-185, 150);
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
        if (who == PlayerStats.stats)
        {
            playerScroll.GetComponentInChildren<Text>().text += string.Format("<size={0}><color={1}>You {2}</color></size>\n", size, color, desc);
        }
        else
        {
            enemyScroll.GetComponentInChildren<Text>().text += string.Format("<size={0}><color={1}>{2} {3}</color></size>\n", size, color, who.mingZi, desc);
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
