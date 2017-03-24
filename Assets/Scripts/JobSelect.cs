using UnityEngine;
using System.Collections;

public class JobSelect : MonoBehaviour {
    public GUISkin skin;

    //public Player player;
    void Start()
    {
        //player = player.GetComponent<Player>();
    }

    void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width / 3, (Screen.height / 12), 400, 150), "Select Your Job", skin.GetStyle("Title"));
 
        if (GUI.Button(new Rect(Screen.width / 2.6f - 300f, 275,250,250), "Mage", skin.GetStyle("BlueBut")))
        {
            //player.job = "Mage";
            //print(player.job);
            //Application.LoadLevel("Stats");
        }
        if (GUI.Button(new Rect(Screen.width / 2.6f, 275, 250, 250), "Rouge", skin.GetStyle("Yes")))
        {

        }
        if (GUI.Button(new Rect(Screen.width / 2.6f + 300f, 275, 250, 250), "Warrior", skin.GetStyle("No")))
        {
            GUI.Label(new Rect(Screen.width / 4, Screen.height / 11, 500, 150), "Available Soon!", skin.GetStyle("Normal"));
        }
        GUI.Label(new Rect(Screen.width / 4, (Screen.height * 0.7f), 500, 150), "Mage: Excels with magic, high MP and Magical DMG but low HP, armor, and physical dmg", skin.GetStyle("Normal"));
        GUI.Label(new Rect(Screen.width / 4, (Screen.height * 0.75f), 500, 150), "Rouge: Fast and sharp, high crit and dodge but low HP and defense", skin.GetStyle("Normal"));
        GUI.Label(new Rect(Screen.width / 4, (Screen.height * 0.8f), 500, 150), "Warrior: Strong and sturdy, high physical dmg and armor but low hit chance and weak to magic", skin.GetStyle("Normal"));



    }
}
