using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    static CameraFollow cameraFollow;
    static GameObject player;
    RectTransform enemyRect;
    public static int turnCount;


    //
    public static Skill playerUseSkill;
    
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        // Buttons
        //    enemyStats.enemy.stats, 
        //    player.transform.FindChild("Player Skills").GetComponent<PlayerSkills>().FindSkill(0)));
        BattleUI.skills.onClick.AddListener(SkillPage.InstantLearnedSkillPage);
        BattleUI.run.onClick.AddListener(EndBattle);
    }

    public static void SetupBattle()
    {
        GameManager.inBattle = true;
        GameManager.OpenClosePage("Battle UI");
        turnCount = -1;
        BattleUI.NextTurn();
        BattleUI.TextReset();
        BattleUI.ResetAllStatus();
        if (SkillPage.quickSkillsPressed)
        {
            SkillPage.AfterQuickSkillButonPress();
        }
        PlayerStats.stats.ResetStatus();
        SoundDatabase.PlayMusic(Random.Range(1, 8));
        EnemyHolder.enemy = new Enemy(EnemyDatabase.enemies[(Random.Range(0, EnemyDatabase.enemies.Count))]);
        BattleUI.enemyName.text = EnemyHolder.enemy.stats.mingZi;
        EnemyHolder.enemy.stats.HealFullHP();
        EnemyHolder.enemy.stats.HealFullMP();
        EnemyHolder.enemyHolder.GetComponent<Image>().sprite = EnemyHolder.enemy.enemyIMG;
        
        SkillPage.UpdateQuickSkills();
        // positions are scaled to screen size
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        BattleUI.CopyPlayer();
        //player.transform.position = BattleUI.playerPosition;
        // Enemy Texts
        SkillPage.skillPoints.gameObject.SetActive(false);
        SkillPage.quickSkillsButton.gameObject.SetActive(false);
        BattleUI.UpdateEnemySliders();
    }


    public static void EndBattle()
    {
        GameManager.OpenClosePage("Battle UI");
        DestroyImmediate(BattleUI.playerCopy);
        GameManager.inBattle = false;
        SkillPage.skillPoints.gameObject.SetActive(true);
        SkillPage.quickSkillsButton.gameObject.SetActive(true);
        player.transform.position = new Vector3(player.transform.position.x - 0.55f, player.transform.position.y);
        Camera.main.transform.position = player.transform.position;
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        SkillPage.AfterLearnedSkillButtonPress();
        SoundDatabase.PlayMusic(8);
    }

}
