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
        canvas.transform.FindChild("Attack").GetComponent<Button>().onClick.AddListener(
            () =>  DamageCalc.skillAttack(player.transform.FindChild("Player Stats").GetComponent<PlayerStats>().stats, 
            enemyStats.enemy.stats, 
            player.transform.FindChild("Player Skills").GetComponent<PlayerSkills>().FindSkill(0)));
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
            // setup enemy
            playerOldPosition = player.transform.position;
            playerOldPosition = new Vector3(playerOldPosition.x - 1, playerOldPosition.y);
            enemyStats.enemy = enemyDatabase.enemies[Random.Range(0, enemyDatabase.enemies.Count)];
            enemy.GetComponent<SpriteRenderer>().sprite = enemyStats.enemy.enemyIMG;
            EnemyTextOn(true);
            ButtonsOn(true);
            manager.setupBattle = false;
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
            canvas.transform.FindChild("Enemy HP").GetComponent<Text>().text = "HP: " + StatUtilities.FindStatTotal(enemy.GetComponent<EnemyStats>().enemy.stats, 4).ToString();
            canvas.transform.FindChild("Enemy MP").GetComponent<Text>().text = "MP: " + StatUtilities.FindStatTotal(enemy.GetComponent<EnemyStats>().enemy.stats, 6).ToString();

        }
    }
    void OnGUI() {
        
    }

    //public void skillAttack(List<Stat> user, List<Stat> victim, Skill skill)
    //{
    //    // Mana Cost
    //    StatUtilities.IncreaseStat(user, 6, -(skill.skillManaCost));
    //    // Damage

    //    // Crit Chance

    //    // Hit Chance
    //    bool ifHit = StatUtilities.
    //}


    public void EnemyTextOn(bool bol)
    {
        canvas.transform.FindChild("Enemy HP").GetComponent<Text>().enabled = bol;
        canvas.transform.FindChild("Enemy MP").GetComponent<Text>().enabled = bol;
    }
    public void ButtonsOn(bool bol)
    {
        canvas.transform.FindChild("Attack").gameObject.SetActive(bol);
        canvas.transform.FindChild("Skills").gameObject.SetActive(bol);
        canvas.transform.FindChild("Run").gameObject.SetActive(bol);
    }

    void EndBattle()
    {
        EnemyTextOn(false);
        manager.inBattle = false;
        player.transform.position = playerOldPosition;
        Camera.main.transform.position = playerOldPosition;
    }

}
