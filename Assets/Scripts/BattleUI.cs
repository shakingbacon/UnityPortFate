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
    public static Image enemySprite;
    public static Transform playerGlyph;
    public static Transform startBattle;
    public Transform statusHolderPrefab;
    public Transform glyphHolderPrefab;

    void Start()
    {
        battleUI = gameObject.transform;
        startBattle = battleUI.FindChild("Player Box").FindChild("Start Battle");
        startBattle.GetComponent<Button>().onClick.AddListener(SkillPage.StartBattleButtonClick);
        enemySprite = gameObject.transform.FindChild("Enemy").GetComponent<Image>();
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
        //run.onClick.AddListener(() => StartCoroutine(DamageCalc.StartBattle(GameManager.player, Battle.enemy, new Skill(SkillDatabase.GetSkill(43)))));
        playerGlyph = battleUI.FindChild("Player Glyph");
        //GameManager.OpenClosePage("InventoryEquipment");
    }

    public static void AddBattleGlyph(Glyph glyph)
    {
        Transform newGlyph = Instantiate(battleUI.GetComponent<BattleUI>().glyphHolderPrefab, playerGlyph);
        GameObject newSkill = new GameObject("Glyph Skill pic");
        newSkill.transform.SetParent(playerGlyph);
        newSkill.AddComponent<Image>();
        newSkill.transform.localScale = new Vector3(1, 1, 1);
        newGlyph.transform.localScale = new Vector3(1, 1, 1);
        newGlyph.GetComponent<GlyphHolder>().glyph = glyph;
        newGlyph.GetComponent<SimpleSkillHolder>().skill = GlyphPage.selectedSkill;
        newGlyph.GetComponent<Image>().sprite = glyph.itemImg;
        newSkill.GetComponent<Image>().sprite = newGlyph.GetComponent<SimpleSkillHolder>().skill.skillIMG;

    }

    public static Transform WhoseStatus(Mortal mortal)
    {
        Transform who;
        if (mortal == Battle.player)
        {
            who = playerStatus;
        }
        else
        {
            who = enemyStatus;
        }
        return who;
    }

    public static void RemoveStatus(Transform who, int id)
    {
        foreach (Transform skill in who)
        {
            if (skill.GetComponent<StatusHolder>().skill.skillID == id)
            {
                Destroy(skill.gameObject);
            }
        }
    }
      

    public static void ResetStatus(Mortal mortal)
    {
        foreach (Transform status in WhoseStatus(mortal))
        {
            status.GetComponent<StatusHolder>().skill.skillOnCooldown = false;
            Destroy(status.gameObject);
        }
        foreach (List<Skill> page in mortal.skills)
        {
            foreach (Skill skill in page)
            {
                skill.skillOnCooldown = false;
            }
        }
    }

    public static void ResetAllStatus()
    {
        ResetStatus(Battle.player);
        ResetStatus(Battle.enemy);
    }

    public static void AddStatus(Mortal mortal, Skill skill)
    {
        //mortal.AddStatus(skill);
        Transform where = WhoseStatus(mortal);
        Transform newStatus = Instantiate(battleUI.GetComponent<BattleUI>().statusHolderPrefab, where);
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

    public static void TextAdd(Mortal who, int size, string color, string desc)
    {
        Transform whoScroll;
        if (playerStatus == WhoseStatus(who))
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

    public static void TextAdd(Mortal who, int size, string desc)
    {
        Transform whoScroll;
        if (playerStatus == WhoseStatus(who))
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
        SliderUtilities.UpdateSliderFillWithText(enemyHP, Battle.enemy.health, Battle.enemy.maxHealth.totalAmount, "HP: ", "Enemy HP Text");
        SliderUtilities.UpdateSliderFillWithText(enemyMP, Battle.enemy.mana, Battle.enemy.maxMana.totalAmount, "MP: ", "Enemy MP Text");
    }
}
