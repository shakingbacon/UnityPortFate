using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    CameraFollow cameraFollow;
    GameManager manager;
    GameObject player;
    Vector3 playerPos, cameraPos, enemyPos;
    EnemyDatabase enemyDatabase;
    Transform enemy;
    EnemyStats enemyStats;
    RectTransform enemyRect;
    float cameraH;
    float cameraW;
    Vector3 playerOldPosition;
    GameObject canvas;
    Vector3 middle;
    // Use this for initialization
    void Start ()
    {
        middle = gameObject.transform.FindChild("Background").position;
        enemyStats = GetComponentInChildren<EnemyStats>();
        enemy = gameObject.transform.FindChild("Enemy");
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyDatabase = GameObject.FindGameObjectWithTag("Enemy Database").GetComponent<EnemyDatabase>();
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        // Buttons
        canvas.transform.FindChild("Battle UI").transform.FindChild("Attack").GetComponent<Button>().onClick.AddListener(
            () =>  DamageCalc.SkillAttack(player.transform.FindChild("Player Stats").GetComponent<PlayerStats>().stats, 
            enemyStats.enemy.stats, 
            player.transform.FindChild("Player Skills").GetComponent<PlayerSkills>().FindSkill(0)));
        canvas.transform.FindChild("Battle UI").transform.FindChild("Skills").GetComponent<Button>().onClick.AddListener(GameManager.OpenCloseSkillPage);
        canvas.transform.FindChild("Battle UI").transform.FindChild("Run").GetComponent<Button>().onClick.AddListener(EndBattle);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Test") && manager.inBattle)
        {
            EndBattle();
        }
        if (manager.setupBattle)
        {
            playerOldPosition = player.transform.position;
            playerOldPosition = new Vector3(playerOldPosition.x - 1, playerOldPosition.y);
            enemyStats.enemy = enemyDatabase.enemies[Random.Range(0, enemyDatabase.enemies.Count)];
            enemy.GetComponent<SpriteRenderer>().sprite = enemyStats.enemy.enemyIMG;
            BattleUIOn(true);
            manager.setupBattle = false; // setup enemy
           
        }
        if (manager.inBattle)
        {
            // positions are scaled to screen size
            cameraH = 2 * Camera.main.orthographicSize;
            cameraW = cameraH * Camera.main.aspect;
            playerPos = new Vector3 (middle.x - cameraW/4.5f, middle.y + cameraH /3.4f);
            player.transform.position = playerPos;
            enemyPos = new Vector3(middle.x + cameraW / 3.5f, playerPos.y);
            enemy.transform.position = enemyPos;
            cameraFollow.transform.position = new Vector3(gameObject.transform.FindChild("Background").position.x, gameObject.transform.FindChild("Background").position.y, -10);
            //Enemy newEnemy = enemyStats.enemy;
            StatUtilities.StatsUpdate(enemyStats.enemy.stats);
            // Enemy Texts
            canvas.transform.FindChild("Battle UI").transform.FindChild("Enemy HP").GetComponent<Text>().text = "HP: " + StatUtilities.FindStatTotal(enemy.GetComponent<EnemyStats>().enemy.stats, 4).ToString();
            canvas.transform.FindChild("Battle UI").transform.FindChild("Enemy MP").GetComponent<Text>().text = "MP: " + StatUtilities.FindStatTotal(enemy.GetComponent<EnemyStats>().enemy.stats, 6).ToString();
        }
    }

    public void BattleUIOn(bool bol)
    {
        canvas.transform.FindChild("Battle UI").gameObject.SetActive(bol);
    }

    void EndBattle()
    {
        BattleUIOn(false);
        manager.inBattle = false;
        player.transform.position = playerOldPosition;
        Camera.main.transform.position = playerOldPosition;
    }

}
