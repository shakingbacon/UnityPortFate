using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    public static Transform victoryScreen;


    void Start()
    {
        victoryScreen = gameObject.transform;
        victoryScreen.FindChild("Yes").GetComponent<Button>().onClick.AddListener(YesClick);
        victoryScreen.FindChild("No").GetComponent<Button>().onClick.AddListener(NoClick);
        OpenCloseVictoryScreen();
    }

    public static void OpenCloseVictoryScreen()
    {
        victoryScreen.gameObject.SetActive(!victoryScreen.gameObject.activeInHierarchy);
    }

    public static void YesClick()
    {
        Battle.SetupBattle();
        OpenCloseVictoryScreen();
    }
    public static void NoClick()
    {
        OpenCloseVictoryScreen();
        Battle.EndBattle();
    }
}
