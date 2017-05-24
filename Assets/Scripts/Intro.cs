using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Intro : MonoBehaviour {


    void Start()
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
            SoundDatabase.PlaySound(43);
            GameManager.player.mingZi = gameObject.transform.FindChild("Input Name").GetComponent<InputField>().text;
            StatusBar.UpdateDescription();
            Destroy(gameObject);
        }
        else
        {
            SoundDatabase.PlaySound(33);
        }
    }

    public void QuitButtonPress()
    {
        Application.Quit();
    }
}
