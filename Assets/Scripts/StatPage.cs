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
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(GameManager.player.HealFullHP);
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(GameManager.player.HealFullMP);
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(StatusBar.UpdateSliders);
        statPage.FindChild("Finish").GetComponent<Button>().onClick.AddListener(() => SoundDatabase.PlaySound(32));
        GameManager.OpenClosePage("Level Up Screen");
    }
	
    public static void UpdateText(string stat)
    {
        if (stat == "s")
        {
            statPage.FindChild("Strength").GetComponent<Text>().text
                = string.Format("Strength: {0}. Increases max HP, increases Physical Damage, slightly increases Armor", GameManager.player.strength.totalAmount);
        }
        else if (stat == "i")
        {
            statPage.FindChild("Intelligence").GetComponent<Text>().text
                = string.Format("Intelligence: {0}. Increases max MP, increases Magical Damage, slightly increases Resist", GameManager.player.intelligence.totalAmount);
        }
        else if (stat == "a")
        {
            statPage.FindChild("Agility").GetComponent<Text>().text
                = string.Format("Agility: {0}. Slightly increases both max HP/MP, increases Crit Rate and Dodge Rate", GameManager.player.agility.totalAmount);
        }
        else if (stat == "l")
        {
            statPage.FindChild("Luck").GetComponent<Text>().text
                = string.Format("Luck: {0}. Slightly increases many different factors, generally gives good fortune", GameManager.player.luck.totalAmount);
        }
        statPage.FindChild("AP").GetComponent<Text>().text = "AP: " + GameManager.player.abilityPoints;
        if (GameManager.player.abilityPoints == 0)
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
            = string.Format("Strength: {0}. Increases max HP, increases Physical Damage, slightly increases Armor.", GameManager.player.strength.totalAmount);
        statPage.FindChild("Intelligence").GetComponent<Text>().text
            = string.Format("Intelligence: {0}. Increases max MP, increases Magical Damage, slightly increases Resist", GameManager.player.intelligence.totalAmount);
        statPage.FindChild("Agility").GetComponent<Text>().text
            = string.Format("Agility: {0}. Slightly increases both max HP/MP, increases Crit Rate and Dodge Rate", GameManager.player.agility.totalAmount);
        statPage.FindChild("Luck").GetComponent<Text>().text
            = string.Format("Luck: {0}. Slightly increases many different factors, generally gives good fortune", GameManager.player.luck.totalAmount);
        statPage.FindChild("AP").GetComponent<Text>().text = "AP: " + GameManager.player.abilityPoints;
        if (GameManager.player.abilityPoints == 0)
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
        if (GameManager.player.abilityPoints > 0)
        {
            if (stat == "s")
            {
                GameManager.player.strength.baseAmount += 1;
            }
            else if (stat == "i")
            {
                GameManager.player.intelligence.baseAmount += 1;
            }
            else if (stat == "a")
            {
                GameManager.player.agility.baseAmount += 1;
            }
            else if (stat == "l")
            {
                GameManager.player.luck.baseAmount += 1;
            }
            SoundDatabase.PlaySound(20);
            GameManager.player.abilityPoints -= 1;
            GameManager.player.FullUpdate();
            UpdateText(stat);
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
        GameManager.player.HealFullHP();
        GameManager.player.HealFullMP();
        StatusBar.UpdateSliders();
    }

    public void RemStat(string stat)
    {
        if (GameManager.player.abilityPoints >= 0 && !(GameManager.player.abilityPoints == 6))
        {
            bool canDo = false;
            if (stat == "s" && GameManager.player.strength.totalAmount > currentStr)
            {
                GameManager.player.strength.baseAmount -= 1;
                canDo = true;   
            }
            else if (stat == "i" && currentInt < GameManager.player.intelligence.totalAmount)
            {
                GameManager.player.intelligence.baseAmount -= 1;
                canDo = true;
            }
            else if (stat == "a" && currentAgi < GameManager.player.agility.totalAmount)
            {
                GameManager.player.agility.baseAmount -= 1;
                canDo = true;
            }
            else if (stat == "l" && currentLuk < GameManager.player.luck.totalAmount)
            {
                GameManager.player.luck.baseAmount -= 1;
                canDo = true;
            }
            if (canDo)
            {
                SoundDatabase.PlaySound(0);
                GameManager.player.abilityPoints += 1;
                GameManager.player.FullUpdate();
                UpdateText(stat);
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
        GameManager.player.HealFullHP();
        GameManager.player.HealFullMP();
        StatusBar.UpdateSliders();
    }

    public static void SetCurrentStats()
    {
        currentStr = GameManager.player.strength.totalAmount;
        currentInt = GameManager.player.intelligence.totalAmount;
        currentAgi = GameManager.player.agility.totalAmount;
        currentLuk = GameManager.player.luck.totalAmount;
    }

    public static void OpenCloseCelebration(bool on)
    {
        levelUpScreen.FindChild("Celebration").gameObject.SetActive(on);
    }



}
