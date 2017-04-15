using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour {

    public static Slider healthBar;
    public static Slider manaBar;
    public static Slider expBar;
    public static Transform playerDesc;

    void Start()
    {
        healthBar = gameObject.transform.FindChild("HP Bar").GetComponent<Slider>();
        manaBar = gameObject.transform.FindChild("MP Bar").GetComponent<Slider>();
        expBar = gameObject.transform.FindChild("EXP Bar").GetComponent<Slider>();
        playerDesc = gameObject.transform.FindChild("Player Description");
        UpdateStatusBar();
    }

    public static void UpdateDescription()
    {
        playerDesc.FindChild("Name").GetComponent<Text>().text = PlayerStats.stats.mingZi;
        playerDesc.FindChild("Level").GetComponent<Text>().text = "LV: " + PlayerStats.stats.level.ToString();
        playerDesc.FindChild("Job").GetComponent<Text>().text = "Job: " + PlayerStats.stats.job.jobName;
    }

    public static void UpdateSliders()
    {
        SliderUtilities.UpdateSliderFillWithText(healthBar, PlayerStats.stats.health, PlayerStats.stats.maxHealth.totalAmount ,"HP Amount");
        SliderUtilities.UpdateSliderFillWithText(manaBar, PlayerStats.stats.mana, PlayerStats.stats.maxMana.totalAmount, "MP Amount");
        SliderUtilities.UpdateSliderFillWithText(expBar, PlayerStats.stats.experience, PlayerStats.stats.maxExperience, "EXP Amount");
    }
    
    public static void UpdateStatusBar()
    {
        UpdateDescription();
        UpdateSliders();
    }
        
}
