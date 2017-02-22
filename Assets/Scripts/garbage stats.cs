using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public GUISkin skin;
    //public Player player;
    void Start()
    {
        //player = player.GetComponent<Player>();
    }

    void OnGUI()
    {
        GUI.skin = skin;
        // Stren
        GUI.Label(new Rect(Screen.width / 4, 50, 500, 25), "Strength: %i. Increases max HP, increases Physical Damage, slightly increases Armor", skin.GetStyle("Normal"));
        if (GUI.Button(new Rect(Screen.width * 0.1f, 100, 75, 75), "+", skin.GetStyle("Yes")))
        {

        }
        if (GUI.Button(new Rect(Screen.width *0.2f, 100, 75, 75), "-", skin.GetStyle("No")))
        {

        }
        // Intel
        GUI.Label(new Rect(Screen.width / 4, 225, 500, 25), "Intelligence: %i. Increases max MP, increases Magical Damage, slightly increases Resist", skin.GetStyle("Normal"));
        if (GUI.Button(new Rect(Screen.width * 0.1f, 275, 75, 75), "+", skin.GetStyle("Yes")))
        {

        }
        if (GUI.Button(new Rect(Screen.width * 0.2f, 275, 75, 75), "-", skin.GetStyle("No")))
        {

        }
        // Agi
        GUI.Label(new Rect(Screen.width / 4, 400, 500, 25), "Agility: %i. Slightly increases both max HP/MP, increases Crit Rate and Dodge Rate", skin.GetStyle("Normal"));
        if (GUI.Button(new Rect(Screen.width * 0.1f, 450, 75, 75), "+", skin.GetStyle("Yes")))
        {

        }
        if (GUI.Button(new Rect(Screen.width * 0.2f, 450, 75, 75), "-", skin.GetStyle("No")))
        {

        }
        // Luck
        GUI.Label(new Rect(Screen.width / 4, 575, 500, 25), "Luck: %i. Slightly increases many different factors, generally gives good fortune", skin.GetStyle("Normal"));
        if (GUI.Button(new Rect(Screen.width * 0.1f, 625, 75, 75), "+", skin.GetStyle("Yes")))
        {

        }
        if (GUI.Button(new Rect(Screen.width * 0.2f, 625, 75, 75), "-", skin.GetStyle("No")))
        {

        }
        // AP
        GUI.Label(new Rect(Screen.width / 4+125, 325, 500, 25), "AP (Ability Points) Available: %i", skin.GetStyle("Normal+"));

    }

}
