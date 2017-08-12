using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour {
    [SerializeField] private Text health, level;
    [SerializeField] private Image levelFill, healthFill;
    [SerializeField] private Player player;

    // Stats
    private List<Text> playerStatTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    void Awake() {
        //weaponIcon.sprite = defaultWeaponSprite;
        //playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnPlayerLevelChanged += UpdateLevel;
        InitializeStats();
        player.TakeDamage(5);
    }


    void UpdateHealth(int currentHealth, int maxHealth)
    {
        this.health.text = currentHealth.ToString();
        this.healthFill.fillAmount = (float)currentHealth / (float)maxHealth;
    }


    void UpdateLevel()
    {
        this.level.text = player.PlayerLevel.Level.ToString();
        this.levelFill.fillAmount = 
            (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }


    void InitializeStats()
    {
        for(int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts.Add(Instantiate(playerStatPrefab));
            playerStatTexts[i].transform.SetParent(playerStatPanel);
            playerStatTexts[i].transform.localPosition = new Vector3(1, 1, 1);
            playerStatTexts[i].transform.localScale = new Vector3(1, 1, 1);

        }
        UpdateStats();
    }

    void UpdateStats()
    {
        for( int i = 0; i < player.characterStats.stats.Count; i++)
        {
            playerStatTexts[i].text = player.characterStats.stats[i].StatName + ": " + player.characterStats.stats[i].GetCalcStatValue().ToString();
        }
    }

}

