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
    }

    public static void SetupBattle(Enemy vswho)
    {
        if (!GameManager.inBattle)
        {
            GameManager.inBattle = true;
            if (GameManager.inTutorial)
            {
                BattleUI.run.interactable = false;
            }
            else
            {
                BattleUI.run.interactable = true;
            }
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
        VictoryScreen.ResetDetails();
        SoundDatabase.PlayMusic(Random.Range(2, 9));
        turnCount = -1;
        BattleUI.NextTurn();
        BattleUI.TextReset();
        BattleUI.ResetAllStatus();
        BattleUI.quickSkillDesc.text = "";
        EnemyHolder.enemy = new Enemy(vswho);
        BattleUI.enemyName.text = EnemyHolder.enemy.stats.mingZi;
        EnemyHolder.enemy.stats.HealFullHP();
        EnemyHolder.enemy.stats.HealFullMP();
        EnemyHolder.enemyHolder.GetComponent<Image>().sprite = EnemyHolder.enemy.enemyIMG;
        BattleUI.UpdateEnemySliders();
        StatusBar.LoseShield();
    }


    public static void EndBattle()
    {
        DamageCalc.LoseAllPlayerStatusEffects();
        StatusBar.LoseShield();
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
        SoundDatabase.PlayMusic(9);
    }

}
