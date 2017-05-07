using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPage : MonoBehaviour {

    public static int currentStr;
    public static int currentInt;
    public static int currentAgi;
    public static int currentLuk;

    public static Transform levelUpScreen;
    public static Transform statPage;

	void Start ()
    {
        levelUpScreen = gameObject.transform.parent;
        statPage = gameObject.transform;
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(() => GameManager.OpenClosePage("Level Up Screen"));
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(PlayerStats.stats.HealFullHP);
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(PlayerStats.stats.HealFullMP);
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(StatusBar.UpdateSliders);
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(() => SoundDatabase.PlaySound(21));
        GameManager.OpenClosePage("Level Up Screen");
    }
	
    public static void UpdateText(string stat)
    {
        if (stat == "s")
        {
            statPage.FindChild("Strength").GetComponent<Text>().text
                = string.Format("Strength: {0}. Increases max HP, increases Physical Damage, slightly increases Armor", PlayerStats.stats.strength.totalAmount);
        }
        else if (stat == "i")
        {
            statPage.FindChild("Intelligence").GetComponent<Text>().text
                = string.Format("Intelligence: {0}. Increases max MP, increases Magical Damage, slightly increases Resist", PlayerStats.stats.intelligence.totalAmount);
        }
        else if (stat == "a")
        {
            statPage.FindChild("Agility").GetComponent<Text>().text
                = string.Format("Agility: {0}. Slightly increases both max HP/MP, increases Crit Rate and Dodge Rate", PlayerStats.stats.agility.totalAmount);
        }
        else if (stat == "l")
        {
            statPage.FindChild("Luck").GetComponent<Text>().text
                = string.Format("Luck: {0}. Slightly increases many different factors, generally gives good fortune", PlayerStats.stats.luck.totalAmount);
        }
        statPage.FindChild("AP").GetComponent<Text>().text = "AP: " + PlayerStats.stats.abilityPoints;
        if (PlayerStats.stats.abilityPoints == 0)
        {
            statPage.FindChild("Finish").GetComponent<Button>().interactable = true;
        }
        else
        {
            statPage.FindChild("Finish").GetComponent<Button>().interactable = false;
        }
    }

    public static void UpdateText()
    {
        statPage.FindChild("Strength").GetComponent<Text>().text
            = string.Format("Strength: {0}. Increases max HP, increases Physical Damage, slightly increases Armor.", PlayerStats.stats.strength.totalAmount);
        statPage.FindChild("Intelligence").GetComponent<Text>().text
            = string.Format("Intelligence: {0}. Increases max MP, increases Magical Damage, slightly increases Resist", PlayerStats.stats.intelligence.totalAmount);
        statPage.FindChild("Agility").GetComponent<Text>().text
            = string.Format("Agility: {0}. Slightly increases both max HP/MP, increases Crit Rate and Dodge Rate", PlayerStats.stats.agility.totalAmount);
        statPage.FindChild("Luck").GetComponent<Text>().text
            = string.Format("Luck: {0}. Slightly increases many different factors, generally gives good fortune", PlayerStats.stats.luck.totalAmount);
        statPage.FindChild("AP").GetComponent<Text>().text = "AP: " + PlayerStats.stats.abilityPoints;
        if (PlayerStats.stats.abilityPoints == 0)
        {
            statPage.FindChild("Finish").GetComponent<Button>().interactable = true;
        }
        else
        {
            statPage.FindChild("Finish").GetComponent<Button>().interactable = false;
        }
    }

    public void AddStat(string stat)
    {
        if (PlayerStats.stats.abilityPoints > 0)
        {
            if (stat == "s")
            {
                PlayerStats.stats.strength.baseAmount += 1;
            }
            else if (stat == "i")
            {
                PlayerStats.stats.intelligence.baseAmount += 1;
            }
            else if (stat == "a")
            {
                PlayerStats.stats.agility.baseAmount += 1;
            }
            else if (stat == "l")
            {
                PlayerStats.stats.luck.baseAmount += 1;
            }
            SoundDatabase.PlaySound(20);
            PlayerStats.stats.abilityPoints -= 1;
            PlayerStats.StatsUpdate();
            UpdateText(stat);
            StatusBar.UpdateSliders();
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }

    public void RemStat(string stat)
    {
        if (PlayerStats.stats.abilityPoints >= 0 && !(PlayerStats.stats.abilityPoints == 6))
        {
            bool canDo = false;
            if (stat == "s" && PlayerStats.stats.strength.totalAmount > currentStr)
            {
                PlayerStats.stats.strength.baseAmount -= 1;
                canDo = true;   
            }
            else if (stat == "i" && currentInt < PlayerStats.stats.intelligence.totalAmount)
            {
                PlayerStats.stats.intelligence.baseAmount -= 1;
                canDo = true;
            }
            else if (stat == "a" && currentAgi < PlayerStats.stats.agility.totalAmount)
            {
                PlayerStats.stats.agility.baseAmount -= 1;
                canDo = true;
            }
            else if (stat == "l" && currentLuk < PlayerStats.stats.luck.totalAmount)
            {
                PlayerStats.stats.luck.baseAmount -= 1;
                canDo = true;
            }
            if (canDo)
            {
                SoundDatabase.PlaySound(0);
                PlayerStats.stats.abilityPoints += 1;
                PlayerStats.StatsUpdate();
                UpdateText(stat);
                StatusBar.UpdateSliders();
            }
            else
            {
                SoundDatabase.PlaySound(33);
            }
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }

    public static void SetCurrentStats()
    {
        currentStr = PlayerStats.stats.strength.totalAmount;
        currentInt = PlayerStats.stats.intelligence.totalAmount;
        currentAgi = PlayerStats.stats.agility.totalAmount;
        currentLuk = PlayerStats.stats.luck.totalAmount;
    }

    public static void OpenCloseCelebration(bool on)
    {
        levelUpScreen.FindChild("Celebration").gameObject.SetActive(on);
    }



}
