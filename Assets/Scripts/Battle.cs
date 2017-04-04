using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    static CameraFollow cameraFollow;
    static GameObject player;
    static Vector3 playerPos, playerOldPosition;
    RectTransform enemyRect;
    static Vector3 middle;


    //
    public static Skill playerUseSkill;
    
    // Use this for initialization
    void Start ()
    {
        middle = gameObject.transform.FindChild("Background").position;
        player = GameObject.FindGameObjectWithTag("Player");
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        // Buttons
        //    enemyStats.enemy.stats, 
        //    player.transform.FindChild("Player Skills").GetComponent<PlayerSkills>().FindSkill(0)));
        BattleUI.skills.onClick.AddListener(() => GameManager.OpenClosePage("Skill Page"));
        BattleUI.run.onClick.AddListener(EndBattle);
    }

    public static void SetupBattle()
    {
        GameManager.inBattle = true;
        SoundDatabase.PlayMusic(Random.Range(1, 8));
        playerOldPosition = player.transform.position;
        playerOldPosition = new Vector3(playerOldPosition.x - 1, playerOldPosition.y);
        EnemyHolder.enemy = new Enemy(EnemyDatabase.enemies[(Random.Range(0, EnemyDatabase.enemies.Count))]);
        EnemyHolder.enemy.stats.health = EnemyHolder.enemy.stats.maxHealth.totalAmount;
        EnemyHolder.enemyHolder.GetComponent<SpriteRenderer>().sprite = EnemyHolder.enemy.enemyIMG;
        BattleUIOn(true);
        // positions are scaled to screen size
        float cameraH = 2 * Camera.main.orthographicSize;
        float cameraW = cameraH * Camera.main.aspect;
        Vector3 playerPos = new Vector3(middle.x - cameraW / 4.5f, middle.y + cameraH / 3.4f);
        player.transform.position = playerPos;
        Vector3 enemyPos = new Vector3(middle.x + cameraW / 3.5f, playerPos.y);
        EnemyHolder.enemyHolder.position = enemyPos;
        cameraFollow.transform.position = new Vector3(middle.x, middle.y, -10);
        //StatUtilities.StatsUpdate(enemyStats.enemy.stats);
        // Enemy Texts
        BattleUI.UpdateEnemySliders();
    }

    public static void BattleUIOn(bool bol)
    {
        BattleUI.battleUI.gameObject.SetActive(bol);
    }

    public static void EndBattle()
    {
        BattleUIOn(false);
        GameManager.inBattle = false;
        player.transform.position = playerOldPosition;
        Camera.main.transform.position = playerOldPosition;
        SoundDatabase.PlayMusic(8);
    }

}
