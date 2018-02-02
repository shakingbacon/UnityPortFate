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
        healthBar = gameObject.transform.FindChild("HP Bar").GetComponent<Slider>();
        healthBarText = healthBar.transform.FindChild("HP Amount").GetComponent<Text>();
        manaBar = gameObject.transform.FindChild("MP Bar").GetComponent<Slider>();
        manaBarText = manaBar.transform.FindChild("MP Amount").GetComponent<Text>();
        expBar = gameObject.transform.FindChild("EXP Bar").GetComponent<Slider>();
        expBarText = expBar.transform.FindChild("EXP Amount").GetComponent<Text>();
        shieldBar = gameObject.transform.FindChild("Shield Bar").GetComponent<Slider>();
        Transform playerDesc = gameObject.transform.FindChild("Player Description");
        mingZi = playerDesc.FindChild("Name").GetComponent<Text>();
        job = playerDesc.FindChild("Job").GetComponent<Text>();
        currentLevel = playerDesc.FindChild("Current Level").GetComponent<Text>();
        nextLevel = playerDesc.FindChild("Next Level").GetComponent<Text>();
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
