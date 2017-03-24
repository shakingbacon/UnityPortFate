using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
    // GUI
    public GUISkin skin;

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width/4, (Screen.height/10),500,150), "Booga's Welcome of Fate", skin.GetStyle("Title"));
        if (GUI.Button(new Rect (Screen.width*0.3f,375, 100, 100),"Start",skin.GetStyle("Yes")))
        {
            //Application.LoadLevel("Instructions");
        }
        if (GUI.Button(new Rect (Screen.width*0.6f, 375, 100, 100),"Quit",skin.GetStyle("No")))
        {
            Application.Quit();
        }
	}
}
