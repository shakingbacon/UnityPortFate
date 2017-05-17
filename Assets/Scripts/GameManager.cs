using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GUISkin skin;
    public static PlayerData player;
    public static string version;
    public static bool invisibleWallOn = false;
    static string showingPage;
    public static bool inBattle;
    public static bool inTutorial;
    public static bool inIntro;
    public bool setupBattle;
    public static bool hoveringBattleStatus;
    public static Transform hoveringBattleStatusParent;

    void Start()
    {
        player = new PlayerData();
        version = "Dev.v3.10";
        OpenClosePage("Skill Page");
        OpenClosePage("Battle UI");
        OpenClosePage("InventoryEquipment");
        OpenClosePage("Status Bar");
        OpenClosePage("Tutorial");
    }

    void Update()
    {
        if (!invisibleWallOn && !inIntro)
        {
            if (Input.GetButtonDown("Skill"))
            {
                SkillPage.UpdateSkillPoints();
                CheckSkillPage();
            }
            if (Input.GetButtonDown("Inventory"))
            {
                InvEqOpen();
            }
            if (Input.GetButtonDown("Cancel"))
            {
                if (SkillPage.skillPage.gameObject.activeInHierarchy)
                {
                    SkillPage.UpdateSkillPoints();
                    CheckSkillPage();
                }
                if (InvEq.inventoryEquipment.gameObject.activeInHierarchy)
                {
                    InvEqOpen();
                }
            }
        }
    }

    void InvEqOpen()
    {
        SoundDatabase.PlaySound(34);
        if (!OpenClosePage("InventoryEquipment"))
        {
            if (InvEq.showStats)
            {
                InvEq.ShowStats(false);
            }
            GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(false);
            if (InvEq.holdingItem.itemID != -1)
            {
                Inventory.AddItem(InvEq.holdingItem.itemID);
                InvEq.UpdateHoldingItem(new Item(), false);
            }
        }
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void CheckSkillPage()
    {
        SoundDatabase.PlaySound(34);
        //playerSkills.SkillUpdate();
        if (OpenClosePage("Skill Page"))
        {
            if (SkillPage.quickSkillsPressed)
            {
                SkillPage.AfterQuickSkillButonPress();
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
        }

    }

    public static void InvisibleWallOn(bool yes)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Invisible Wall").gameObject.SetActive(yes);
        invisibleWallOn = yes;
    }

    public static bool OpenClosePage(string name)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.SetActive(
            !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy));
        return !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy);
    }

}
