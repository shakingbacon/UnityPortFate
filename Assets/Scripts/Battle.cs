using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    public static PlayerData player;
    public static Enemy enemy;
    RectTransform enemyRect;
    public static int turnCount;
    public static Skill playerUseSkill;
    
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
        BattleUI.quickSkillDesc.text = "";
        player = GameManager.player;
        Enemy chosenEnemy = new Enemy(vswho);
        enemy = chosenEnemy;
        BattleUI.enemyName.text = enemy.mingZi;
        BattleUI.ResetAllStatus();
        enemy.HealFullHP();
        enemy.HealFullMP();
        BattleUI.enemySprite.sprite = chosenEnemy.enemyIMG;
        BattleUI.UpdateEnemySliders();
        StatusBar.LoseShield();
    }


    public static void EndBattle()
    {
        GameObject playr = GameObject.FindGameObjectWithTag("Player");
        DamageCalc.LoseAllPlayerStatusEffects();
        StatusBar.LoseShield();
        GameManager.OpenClosePage("Battle UI");
        DestroyImmediate(BattleUI.playerCopy);
        GameManager.inBattle = false;
        SkillPage.skillPoints.gameObject.SetActive(true);
        SkillPage.quickSkillsButton.gameObject.SetActive(true);
        SkillPage.quickSkillsInfo.gameObject.SetActive(true);
        playr.transform.position = new Vector3(playr.transform.position.x - 0.55f, playr.transform.position.y);
        Camera.main.transform.position = playr.transform.position;
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        SkillPage.AfterLearnedSkillButtonPress();
        QuickSkills.MoveToSkillPage();
        BattleUI.MovePlayer(InvEq.playerImage.transform);
        SoundDatabase.PlayMusicPrevious();
    }

}
