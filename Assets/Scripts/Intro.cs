using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {

    void Awake()
    {
        GameManager.inIntro = true;
        gameObject.transform.FindChild("Version").GetComponent<Text>().text = GameManager.version;
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            StartButtonPress();
        }
    }

    public void StartButtonPress()
    {
        if (gameObject.transform.FindChild("Input Name").GetComponent<InputField>().text.Length != 0)
        {
            GameManager.player = new PlayerData();
            SoundDatabase.PlaySound(43);
            GameManager.player.mingZi = gameObject.transform.FindChild("Input Name").GetComponent<InputField>().text;
            StatusBar.UpdateDescription();
            Destroy(gameObject);
            GameManager.CreateJobSelect();
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }

    public void LoadButtonPress()
    {
        GameManager.CreateSavePage(false);
    }

    public static void LoadGameAfter()
    {
        Destroy(GameObject.FindGameObjectWithTag("Intro"));
        Destroy(GameObject.FindGameObjectWithTag("Job Select"));
        Tutorial.FinishTutorial();
        Camera.main.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameManager.inIntro = false;
    }

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
