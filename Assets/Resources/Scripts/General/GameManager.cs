using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }

    public Player player;
    public string GameVersion { get; set; }
    public bool invisibleWallOn = false;
    bool showingPage;
    public bool inBattle;
    public bool inTutorial;
    public bool InIntro { get; set; }
    public bool inMonsterArea;
    public bool thereIsShop = false;
    public bool hoveringBattleStatus;
    public Transform hoveringBattleStatusParent;

    [HideInInspector]
    public GameObject canvas;
    [HideInInspector]
    public GameObject characterPanel;

    void Start()
    {
        InIntro = true;
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        characterPanel = canvas.transform.Find("Panel_Character").gameObject;
        StartCoroutine(ScreenFader.FadeToClear());
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Camera.main.transform.position = player.transform.position;
        GameVersion = "Development V10.0";
        FloatingTextController.Initialize();
        EnemyHealthBarController.Initialize();


    }

    void Update()
    {
        if (!InIntro)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                characterPanel.SetActive(!characterPanel.activeInHierarchy);
            }
        }

    }

    
    public GameObject FindCanvasChild(string name)
    {
        return canvas.transform.Find(name).gameObject;
    }


    public void CreateIntro()
    {
        SoundDatabase.PlayMusic(10);
        Transform intro = Instantiate(Resources.Load<Transform>("Prefabs/Intro"), canvas.transform);
        intro.localScale = new Vector3(1, 1, 1);
        intro.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        intro.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    public void CreateJobSelect()
    {
        Transform jobSelect = Instantiate(Resources.Load<Transform>("Prefabs/Pages/Job Select"), canvas.transform);
        jobSelect.localScale = new Vector3(1, 1, 1);
        jobSelect.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        jobSelect.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        //jobSelect.SetAsLastSibling();
    }
}
