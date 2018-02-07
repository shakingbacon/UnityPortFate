using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{

    public static StatusBar Instance { get; set; }

    Player player;
    Slider healthBar;
    Text healthBarText, manaBarText, expBarText;
    Slider manaBar;
    Slider expBar;
    Slider shieldBar;
    Text mingZi, job, currentLevel, nextLevel;
    bool hasShield;
    int shieldMax;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        gameObject.SetActive(false);
    }
    void Start()
    {
        player = GameManager.Instance.player;
        healthBar = gameObject.transform.Find("HP Bar").GetComponent<Slider>();
        healthBarText = healthBar.transform.Find("HP Amount").GetComponent<Text>();
        manaBar = gameObject.transform.Find("MP Bar").GetComponent<Slider>();
        manaBarText = manaBar.transform.Find("MP Amount").GetComponent<Text>();
        expBar = gameObject.transform.Find("EXP Bar").GetComponent<Slider>();
        expBarText = expBar.transform.Find("EXP Amount").GetComponent<Text>();
        shieldBar = gameObject.transform.Find("Shield Bar").GetComponent<Slider>();
        Transform playerDesc = gameObject.transform.Find("Player Description");
        mingZi = playerDesc.Find("Name").GetComponent<Text>();
        job = playerDesc.Find("Job").GetComponent<Text>();
        currentLevel = playerDesc.Find("Current Level").GetComponent<Text>();
        nextLevel = playerDesc.Find("Next Level").GetComponent<Text>();
        //UpdateStatusBar();
        UIEventHandler.OnPlayerHealthChanged += UpdateHealthBar;
        UIEventHandler.OnPlayerExpChanged += UpdateExpBar;
        UIEventHandler.OnPlayerManaChanged += UpdateManaBar;
        UIEventHandler.ExpChanged();
        player.StatsUpdate();
        player.HealFullHP();
        player.HealFullMP();
        UpdateDescription();
    }

    void UpdateHealthBar()
    {
        healthBarText.text = string.Format("HP: {0} / {1}", player.CurrentHealth, player.Stats.MaxHealth);
        healthBar.value = player.CurrentHealth / (float)player.Stats.MaxHealth;
    }

    void UpdateManaBar()
    {
        manaBarText.text = string.Format("MP: {0} / {1}", player.CurrentMana, player.Stats.MaxMana);
        manaBar.value = player.CurrentMana / (float)player.Stats.MaxMana;
    }

    void UpdateExpBar()
    {
        expBarText.text = string.Format("{0} / {1}", player.PlayerLevel.CurrentExperience,
            player.PlayerLevel.RequiredExperience);
        expBar.value = player.PlayerLevel.CurrentExperience / (float)player.PlayerLevel.RequiredExperience;
        currentLevel.text = player.PlayerLevel.Level.ToString();
        nextLevel.text = (player.PlayerLevel.Level + 1).ToString();
    }

    public void UpdateDescription()
    {
        mingZi.text = player.Name;
        job.text = player.Stats.JobName;
    }

    public void HealthBarFlash()
    {
        BarFlash(healthBar.gameObject);
    }

    public void ManaBarFlash()
    {
        BarFlash(manaBar.gameObject);
    }

    void BarFlash(GameObject slider)
    {
        Animator bar = slider.GetComponent<Animator>();
        if (bar.GetCurrentAnimatorStateInfo(0).IsName("Nothing"))
            bar.SetTrigger("Used");
    }

}
