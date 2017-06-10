using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GUISkin skin;
    public static PlayerData player;
    public static GameObject playerGameObject;
    public static string version;
    public static bool invisibleWallOn = false;
    static string showingPage;
    public static bool inBattle;
    public static bool inTutorial;
    public static bool inIntro;
    public static bool cantMove;
    public static bool inMonsterArea;
    public static bool thereIsShop = false;
    public bool setupBattle;
    public static bool hoveringBattleStatus;
    public static Transform hoveringBattleStatusParent;

    void Start()
    {
        //StartCoroutine(ScreenFader.FadeToClear());
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        player = new PlayerData();
        version = "Dev.v4.2";
        OpenClosePage("Skill Page");
        OpenClosePage("Battle UI");
        OpenClosePage("InventoryEquipment");
        OpenClosePage("Status Bar");
        //OpenClosePage("Tutorial");
        OpenClosePage("Computer Screen");
        OpenClosePage("Death Screen");
    }

    void Update()
    {
        if (!invisibleWallOn && !inIntro && !ComputerScreen.computer.gameObject.activeInHierarchy)
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
                if (Shop.showBuying)
                {
                    Shop.BuyingNo();
                }
                else if (thereIsShop)
                {
                    Shop.CloseButton();
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                if (Shop.showBuying)
                {
                    Shop.BuyingNo();
                }
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (ComputerScreen.computer.gameObject.activeInHierarchy)
            {
                ComputerScreen.CloseButton();
            }
        }
        if (inMonsterArea)
        {

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
            GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Desc").gameObject.SetActive(false);
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

    public static void CreateSavePage(bool saving)
    {
        SoundDatabase.PlayMusic(14);
        Transform loadPage = Instantiate(Resources.Load<Transform>("Prefabs/Save Page"), GameObject.FindGameObjectWithTag("Canvas").transform);
        loadPage.localScale = new Vector3(1, 1, 1);
        loadPage.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        loadPage.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        loadPage.SetAsLastSibling();
        SavePage.UpdateSavePage(saving);
    }

    public static void CreateIntro()
    {
        SoundDatabase.PlayMusic(10);
        Transform intro = Instantiate(Resources.Load<Transform>("Prefabs/Intro"), GameObject.FindGameObjectWithTag("Canvas").transform);
        intro.localScale = new Vector3(1, 1, 1);
        intro.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        intro.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    public static void CreateJobSelect()
    {
        Transform jobSelect = Instantiate(Resources.Load<Transform>("Prefabs/Job Select"), GameObject.FindGameObjectWithTag("Canvas").transform);
        jobSelect.localScale = new Vector3(1, 1, 1);
        jobSelect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        jobSelect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        jobSelect.SetAsLastSibling();
    }

    public static void CreateTutorialUI()
    {
        Transform tutorial = Instantiate(Resources.Load<Transform>("Prefabs/Tutorial UI"), GameObject.FindGameObjectWithTag("Canvas").transform);
        tutorial.localScale = new Vector3(1, 1, 1);
        tutorial.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        tutorial.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        tutorial.SetSiblingIndex(1);
    }

    public static void IsPlayerDead()
    {
        if (player.IsDead())
        {
            OpenClosePage("Death Screen");
            cantMove = true;
        }
    }

}
