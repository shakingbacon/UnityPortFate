using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanel : MonoBehaviour {
    [SerializeField] private Text level;
    [SerializeField]
    private Image levelFill;
    [SerializeField] private Player player;

    // Stats
    private List<Text> playerStatTexts = new List<Text>();
    [SerializeField] private Text playerStatPrefab;
    [SerializeField] private Transform playerStatPanel;

    void Awake() {
        //weaponIcon.sprite = defaultWeaponSprite;
        //playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.OnPlayerExpChanged += UpdateLevel;
        InitializeStats();
        gameObject.SetActive(false);
    }

    void UpdateLevel()
    {
        this.level.text = player.PlayerLevel.Level.ToString();
        this.levelFill.fillAmount = 
            (float)player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
    }


    void InitializeStats()
    {
        //for(int i = 0; i < player.Count; i++)
        //{
        //    playerStatTexts.Add(Instantiate(playerStatPrefab));
        //    playerStatTexts[i].transform.SetParent(playerStatPanel);
        //    playerStatTexts[i].transform.localPosition = new Vector3(1, 1, 1);
        //    playerStatTexts[i].transform.localScale = new Vector3(1, 1, 1);

        //}
        UpdateStats();
    }

    void UpdateStats()
    {
        //for( int i = 0; i < player.Stats.stats.Count; i++)
        //{
        //    playerStatTexts[i].text = player.Stats.stats[i].StatName + ": " + player.Stats.stats[i].GetFullValue().ToString();
        //}
    }

}

