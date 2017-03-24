using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

    public GUISkin skin;

    void OnGUI()
    {
        GUI.skin = skin;
        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 100), "NEXT", skin.GetStyle("Yes")))
        {
            //Application.LoadLevel("JobSelect");
        }

    }
}
