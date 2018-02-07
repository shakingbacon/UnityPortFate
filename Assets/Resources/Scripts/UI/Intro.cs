using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour
{

    Player player;
    InputField inputName;
    Button startGame, load, quit;
    Text version;


    void Start()
    {
        player = GameManager.Instance.player;
        inputName = transform.Find("Input Name").GetComponent<InputField>();
        startGame = transform.Find("Start Game").GetComponent<Button>();
        load = transform.Find("Load").GetComponent<Button>();
        quit = transform.Find("Quit").GetComponent<Button>();
        version = transform.Find("Version").GetComponent<Text>();

        startGame.onClick.AddListener(StartGamePress);


        GameManager.Instance.InIntro = true;
        PlayerMovement.cantMove = true;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGamePress();
        }
    }

    public void StartGamePress()
    {
        if (inputName.text.Length != 0)
        {
            SoundDatabase.PlaySound(43);
            player.Name = inputName.text;
            GameManager.Instance.CreateJobSelect();
            Destroy(gameObject);

        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }
    //    GameManager.inTutorial = true;
    //    if (gameObject.transform.FindChild("Input Name").GetComponent<InputField>().text.Length != 0)
    //    {
    //        GameManager.player = new PlayerData();
    //        SoundDatabase.PlaySound(43);
    //        GameManager.player.mingZi = gameObject.transform.FindChild("Input Name").GetComponent<InputField>().text;
    //        StatusBar.UpdateDescription();
    //        Destroy(gameObject);
    //        GameManager.CreateJobSelect();
    //    }
    //    else
    //    {
    //        SoundDatabase.PlaySound(33);
    //    }
    //    QuickSkills.ResetQuickSkills();
    //}

    //public void LoadButtonPress()
    //{
    //    GameManager.CreateSavePage(false);
    //}

    //public static void LoadGameAfter()
    //{
    //    Destroy(GameObject.FindGameObjectWithTag("Intro"));
    //    Destroy(GameObject.FindGameObjectWithTag("Job Select"));
    //    Tutorial.FinishTutorial();
    //    Camera.main.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    //    SoundDatabase.PlayMusic(11);
    //    GameManager.inIntro = false;
    //    StatusBar.statusBar.gameObject.SetActive(true);
    //    GameManager.player.FullUpdate();
    //    SkillPage.currentPage = GameManager.player.skillsJob.skills;
    //    SkillPage.UpdateSkillPage(0);
    //    GameManager.cantMove = false;
    //}

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
