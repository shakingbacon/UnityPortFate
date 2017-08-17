using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerScreen : Interactable {

    public static Transform computer;
    public static Button save;
    public static Button load;
    public static Button quit;
    public static Button close;
    public static Button intro;

    void Start()
    {
        //    computer = gameObject.transform;
        //    //save = computer.FindChild("Save").GetComponent<Button>();
        //    //load = computer.FindChild("Load").GetComponent<Button>();
        //    //quit = computer.FindChild("Quit").GetComponent<Button>();
        //    //close = computer.FindChild("Close").GetComponent<Button>();
        //    //intro = computer.FindChild("Intro").GetComponent<Button>();
        //    //save.onClick.AddListener(() => GameManager.CreateSavePage(true));
        //    //load.onClick.AddListener(() => GameManager.CreateSavePage(false));
        //    close.onClick.AddListener(() => gameObject.SetActive(false));
        //    quit.onClick.AddListener(Application.Quit);
        //    intro.onClick.AddListener(GameManager.CreateIntro);
        //    intro.onClick.AddListener(() => GameManager.OpenClosePage("Computer Screen"));
    }

    public override void Interact()
    {
        SoundDatabase.PlaySound(34);
        computer.gameObject.SetActive(false);
        PlayerMovement.cantMove = false;
    }

}
