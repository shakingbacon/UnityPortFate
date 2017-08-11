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

    // Equipped Weapon
    [SerializeField] private Sprite defaultWeaponSprite;
     private PlayerWeaponController playerWeaponController;
    [SerializeField] private Text weaponStatPrefab;
    [SerializeField] private Transform weaponStatPanel;
    [SerializeField] private Text weaponNameText;
    [SerializeField] private Image weaponIcon;

    void Awake() {
        playerWeaponController = player.GetComponent<PlayerWeaponController>();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealth;
        UIEventHandler.OnStatsChanged += UpdateStats;
        UIEventHandler.onItemEquipped += UpdateEquipWeapon;
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
    void UpdateEquipWeapon(NewItem item)
    {
        weaponIcon.sprite = Resources.Load<Sprite>("UI/Icons/Items/" + item.ObjectSlug);
        weaponNameText.text = item.ItemName;

        for (int i = 0; i < item.Stats.Count; i++)
        {
            Text newStat = Instantiate(weaponStatPrefab);
            newStat.transform.SetParent(weaponStatPanel);
            newStat.transform.localScale = new Vector3(1, 1, 1);
            newStat.transform.localPosition = new Vector3(1, 1, 1);
            newStat.text = item.Stats[i].StatName + ": " + item.Stats[i].GetCalcStatValue().ToString();
        }

    }

    public void UnequipWeapon()
    {
        if (playerWeaponController.EquippedWeapon != null)
        {
            weaponNameText.text = "-";
            weaponIcon.sprite = defaultWeaponSprite;
            foreach(Transform child in weaponStatPanel)
            {
                Destroy(child.gameObject);
            }
            playerWeaponController.UnequipWeapon();
        }
    }
}

