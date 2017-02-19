using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {
    RectTransform rect;
    CameraFollow cameraFollow;
    GameManager manager;
    GameObject player;
    GameObject playerClone = null;
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
        rect = gameObject.GetComponent<RectTransform>();
        enemyStats = GetComponentInChildren<EnemyStats>();
        enemy = gameObject.transform.FindChild("Enemy");
        manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyDatabase = GameObject.FindGameObjectWithTag("Enemy Database").GetComponent<EnemyDatabase>();
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
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
            Enemy newEnemy = enemyStats.enemy;
            // Enemy Texts
            canvas.transform.FindChild("Enemy HP").GetComponent<Text>().text = "HP: " + enemy.GetComponent<EnemyStats>().enemy.enemyHP.ToString();
            canvas.transform.FindChild("Enemy MP").GetComponent<Text>().text = "MP: " + enemy.GetComponent<EnemyStats>().enemy.enemyMP.ToString();
            
        }
    }
    void OnGUI() {
        // Buttons
        if (GUI.Button(new Rect(middle.x - cameraW / 2.5f, middle.y + cameraH / 3, 50, 50), "Attack"))
        {

        }
    }
    public void EnemyTextOn(bool bol)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Enemy HP").GetComponent<Text>().enabled = bol;
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Enemy MP").GetComponent<Text>().enabled = bol;
    }

    void EndBattle()
    {
        EnemyTextOn(false);
        manager.inBattle = false;
        player.transform.position = playerOldPosition;
        Camera.main.transform.position = playerOldPosition;
    }

}
