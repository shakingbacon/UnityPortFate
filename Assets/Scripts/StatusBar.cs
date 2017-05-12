using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour {

    public static Transform statusBar;
    public static Slider healthBar;
    public static Slider manaBar;
    public static Slider expBar;
    public static Slider shieldBar;
    public static Transform playerDesc;
    public static bool hasShield;
    public static int shieldMax;

    void Start()
    {
        statusBar = gameObject.transform;
        healthBar = gameObject.transform.FindChild("HP Bar").GetComponent<Slider>();
        manaBar = gameObject.transform.FindChild("MP Bar").GetComponent<Slider>();
        expBar = gameObject.transform.FindChild("EXP Bar").GetComponent<Slider>();
        shieldBar = gameObject.transform.FindChild("Shield Bar").GetComponent<Slider>();
        playerDesc = gameObject.transform.FindChild("Player Description");
        //UpdateStatusBar();
    }


    public static void SetNewShield()
    {
        hasShield = true;
        shieldMax = PlayerStats.stats.shield;
        statusBar.FindChild("Shield Bar").gameObject.SetActive(true);
        UpdateShield();
    }

    public static void UpdateShield()
    {
        SliderUtilities.UpdateSliderFillWithText(shieldBar, PlayerStats.stats.shield, shieldMax, "Shield: ", "Shield Amount");
    }

    public static void LoseShield()
    {
        PlayerStats.stats.shield = 0;
        hasShield = false;
        statusBar.FindChild("Shield Bar").gameObject.SetActive(false);
    }

    public static void UpdateDescription()
    {
        playerDesc.FindChild("Name").GetComponent<Text>().text = PlayerStats.stats.mingZi;
        playerDesc.FindChild("Level").GetComponent<Text>().text = "LV: " + PlayerStats.stats.level.ToString();
        playerDesc.FindChild("Job").GetComponent<Text>().text = "Job: " + PlayerStats.stats.job.jobName;
        playerDesc.FindChild("Current Level").GetComponent<Text>().text = PlayerStats.stats.level.ToString();
        playerDesc.FindChild("Next Level").GetComponent<Text>().text = (PlayerStats.stats.level + 1).ToString();

    }

    public static void UpdateSliders()
    {
        SliderUtilities.UpdateSliderFillWithText(healthBar, PlayerStats.stats.health, PlayerStats.stats.maxHealth.totalAmount, "HP: ", "HP Amount");
        SliderUtilities.UpdateSliderFillWithText(manaBar, PlayerStats.stats.mana, PlayerStats.stats.maxMana.totalAmount, "MP: ", "MP Amount");
        SliderUtilities.UpdateSliderFillWithText(expBar, PlayerStats.stats.experience, PlayerStats.stats.maxExperience, "EXP: ", "EXP Amount");
    }
    
    public static void UpdateStatusBar()
    {
        UpdateDescription();
        UpdateSliders();
    }
        
}
