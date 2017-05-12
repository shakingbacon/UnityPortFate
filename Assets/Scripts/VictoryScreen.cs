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
        Battle.SetupBattle(new Enemy(EnemyDatabase.enemies[(Random.Range(0, EnemyDatabase.enemies.Count))]));
        OpenCloseVictoryScreen();
    }
    public static void NoClick()
    {
        OpenCloseVictoryScreen();
        Battle.EndBattle();
    }

    public static void AddDetails(string text)
    {
        victoryScreen.FindChild("Details").GetComponent<Text>().text += "\n" + text;
    }
    public static void ResetDetails()
    {
        victoryScreen.FindChild("Details").GetComponent<Text>().text = "";
    }
}
