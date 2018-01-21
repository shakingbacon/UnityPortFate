using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour {
    public static Transform deathScreen;
    public static Button quit;
    public static Button load;
    public static Button intro;
	// Use this for initialization
	void Start ()
    {
        deathScreen = gameObject.transform;
        quit = gameObject.transform.FindChild("Quit").GetComponent<Button>();
        load = gameObject.transform.FindChild("Load").GetComponent<Button>();
        intro = gameObject.transform.FindChild("Intro").GetComponent<Button>();
        quit.onClick.AddListener(Application.Quit);
        //load.onClick.AddListener(() => GameManager.CreateSavePage(false));
        intro.onClick.AddListener(GameManager.Instance.CreateIntro);
        intro.onClick.AddListener(() => gameObject.SetActive(false));
    }
}
