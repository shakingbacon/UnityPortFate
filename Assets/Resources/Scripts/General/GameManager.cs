using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameObject player;
    public static string version;
    public static bool invisibleWallOn = false;
    static string showingPage;
    public static bool inBattle;
    public static bool inTutorial;
    public static bool inIntro;
    public static bool inMonsterArea;
    public static bool thereIsShop = false;
    public bool setupBattle;
    public static bool hoveringBattleStatus;
    public static Transform hoveringBattleStatusParent;

    void Start()
    {  
        //StartCoroutine(ScreenFader.FadeToClear());
        player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.transform.position = player.transform.position;
        version = "Dev.v6.0";

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OpenClosePage("Panel_Character");
        }
    }

    public static void QuitGame()
    {
        Application.Quit();
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

    //public static void CreateSavePage(bool saving)
    //{
    //    SoundDatabase.PlayMusic(14);
    //    Transform loadPage = Instantiate(Resources.Load<Transform>("Prefabs/Save Page"), GameObject.FindGameObjectWithTag("Canvas").transform);
    //    loadPage.localScale = new Vector3(1, 1, 1);
    //    loadPage.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
    //    loadPage.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    //    loadPage.SetAsLastSibling();
    //    SavePage.UpdateSavePage(saving);
    //}

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

    //public static void IsPlayerDead()
    //{
    //    if (player.IsDead())
    //    {
    //        OpenClosePage("Death Screen");
    //        cantMove = true;
    //    }
    //}

}
