using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    static CameraFollow cameraFollow;
    static GameObject player;
    RectTransform enemyRect;


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
        UpdatePlayerStatus();
        UpdateEnemyStatus();
        SoundDatabase.PlayMusic(Random.Range(1, 8));
        EnemyHolder.enemy = new Enemy(EnemyDatabase.enemies[(Random.Range(0, EnemyDatabase.enemies.Count))]);
        EnemyHolder.enemy.stats.HealFullHP();
        EnemyHolder.enemy.stats.HealFullMP();
        print(EnemyHolder.enemy.enemyID);
        EnemyHolder.enemyHolder.GetComponent<Image>().sprite = EnemyHolder.enemy.enemyIMG;
        GameManager.OpenClosePage("Battle UI");
        // positions are scaled to screen size
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        BattleUI.CopyPlayer();
        //player.transform.position = BattleUI.playerPosition;
        // Enemy Texts
        SkillPage.skillPoints.gameObject.SetActive(false);
        BattleUI.UpdateEnemySliders();
    }

    public static void UpdatePlayerStatus()
    {
        for (int i = 0; i < BattleUI.playerStatus.childCount; i++)
        {
            BattleUI.playerStatus.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
        }
    }
    public static void UpdateEnemyStatus()
    {
        for (int i = 0; i < BattleUI.enemyStatus.childCount; i++)
        {
            BattleUI.enemyStatus.GetChild(i).GetComponent<StatusHolder>().UpdateStatus();
        }
    }

    public static void EndBattle()
    {
        GameManager.OpenClosePage("Battle UI");
        DestroyImmediate(BattleUI.playerCopy);
        GameManager.inBattle = false;
        SkillPage.skillPoints.gameObject.SetActive(true);
        player.transform.position = new Vector3(player.transform.position.x - 0.55f, player.transform.position.y);
        Camera.main.transform.position = player.transform.position;
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        SoundDatabase.PlayMusic(8);
    }

}
