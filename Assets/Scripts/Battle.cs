using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    static GameObject player;
    RectTransform enemyRect;
    public static int turnCount;


    //
    public static Skill playerUseSkill;
    
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Buttons
        //    enemyStats.enemy.stats, 
        //    player.transform.FindChild("Player Skills").GetComponent<PlayerSkills>().FindSkill(0)));
        GameManager.OpenClosePage("Skill Page");
        GameManager.OpenClosePage("Battle UI");
        BattleUI.skills.onClick.AddListener(SkillPage.InstantLearnedSkillPage);
        GameManager.OpenClosePage("Battle UI");
        GameManager.OpenClosePage("Skill Page");
        BattleUI.run.onClick.AddListener(EndBattle);
    }

    public static void SetupBattle()
    {
        if (!GameManager.inBattle)
        {
            GameManager.inBattle = true;
            GameManager.OpenClosePage("Battle UI");
            GameManager.OpenClosePage("Skill Page");
            QuickSkills.MoveToBattleUI();
            GameManager.OpenClosePage("Skill Page");
            if (SkillPage.quickSkillsPressed)
            {
                SkillPage.AfterQuickSkillButonPress();
            }
            Camera.main.GetComponent<CameraFollow>().enabled = false;
            BattleUI.MovePlayer(BattleUI.battleUI.FindChild("Player Image Box"));
            //player.transform.position = BattleUI.playerPosition;
            // Enemy Texts
            SkillPage.skillPoints.gameObject.SetActive(false);
            SkillPage.quickSkillsButton.gameObject.SetActive(false);
            SkillPage.quickSkillsInfo.gameObject.SetActive(false);
        }
        SoundDatabase.PlayMusic(Random.Range(1, 8));
        turnCount = -1;
        BattleUI.NextTurn();
        BattleUI.TextReset();
        BattleUI.ResetAllStatus();
        BattleUI.quickSkillDesc.text = "";
        EnemyHolder.enemy = new Enemy(EnemyDatabase.enemies[(Random.Range(0, EnemyDatabase.enemies.Count))]);
        BattleUI.enemyName.text = EnemyHolder.enemy.stats.mingZi;
        EnemyHolder.enemy.stats.HealFullHP();
        EnemyHolder.enemy.stats.HealFullMP();
        EnemyHolder.enemyHolder.GetComponent<Image>().sprite = EnemyHolder.enemy.enemyIMG;
        BattleUI.UpdateEnemySliders();
    }


    public static void EndBattle()
    {
        GameManager.OpenClosePage("Battle UI");
        DestroyImmediate(BattleUI.playerCopy);
        GameManager.inBattle = false;
        SkillPage.skillPoints.gameObject.SetActive(true);
        SkillPage.quickSkillsButton.gameObject.SetActive(true);
        SkillPage.quickSkillsInfo.gameObject.SetActive(true);
        player.transform.position = new Vector3(player.transform.position.x - 0.55f, player.transform.position.y);
        Camera.main.transform.position = player.transform.position;
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        SkillPage.AfterLearnedSkillButtonPress();
        QuickSkills.MoveToSkillPage();
        BattleUI.MovePlayer(InvEq.playerImage.transform);
        SoundDatabase.PlayMusic(8);
    }

}
