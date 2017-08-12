using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour {

    //public static GameObject statusBar;
    //public static Slider healthBar;
    //public static Slider manaBar;
    //public static Slider expBar;
    //public static Slider shieldBar;
    //public static Transform playerDesc;
    //public static bool hasShield;
    //public static int shieldMax;

    //void Start()
    //{
    //    statusBar = gameObject;
    //    healthBar = gameObject.transform.FindChild("HP Bar").GetComponent<Slider>();
    //    manaBar = gameObject.transform.FindChild("MP Bar").GetComponent<Slider>();
    //    expBar = gameObject.transform.FindChild("EXP Bar").GetComponent<Slider>();
    //    shieldBar = gameObject.transform.FindChild("Shield Bar").GetComponent<Slider>();
    //    playerDesc = gameObject.transform.FindChild("Player Description");
    //    //UpdateStatusBar();
    //}


    //public static void SetNewShield()
    //{
    //    hasShield = true;
    //    shieldMax = GameManager.player.shield;
    //    shieldBar.gameObject.SetActive(true);
    //    UpdateShield();
    //}

    //public static void UpdateShield()
    //{
    //    SliderUtilities.UpdateSliderFillWithText(shieldBar, GameManager.player.shield, shieldMax, "Shield: ", "Shield Amount");
    //}

    //public static void LoseShield()
    //{
    //    GameManager.player.shield = 0;
    //    hasShield = false;
    //    shieldBar.gameObject.SetActive(false);
    //}

    //public static void UpdateDescription()
    //{
    //    playerDesc.FindChild("Name").GetComponent<Text>().text = GameManager.player.mingZi;
    //    playerDesc.FindChild("Level").GetComponent<Text>().text = "LV: " + GameManager.player.level.ToString();
    //    playerDesc.FindChild("Job").GetComponent<Text>().text = "Job: " + GameManager.player.job.jobName;
    //    playerDesc.FindChild("Current Level").GetComponent<Text>().text = GameManager.player.level.ToString();
    //    playerDesc.FindChild("Next Level").GetComponent<Text>().text = (GameManager.player.level + 1).ToString();

    //}

    //public static void UpdateSliders()
    //{
    //    SliderUtilities.UpdateSliderFillWithText(healthBar, GameManager.player.health, GameManager.player.maxHealth.totalAmount, "HP: ", "HP Amount");
    //    SliderUtilities.UpdateSliderFillWithText(manaBar, GameManager.player.mana, GameManager.player.maxMana.totalAmount, "MP: ", "MP Amount");
    //    SliderUtilities.UpdateSliderFillWithText(expBar, GameManager.player.experience, GameManager.player.maxExperience, "EXP: ", "EXP Amount");
    //}
    
    //public static void UpdateStatusBar()
    //{
    //    UpdateDescription();
    //    UpdateSliders();
    //}
        
}
