using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int draggingPageID;
    public int showingPageTooltipID = -1;
    public bool inBattle;
    public bool setupBattle;
    Battle battle;

    void Start()
    {
        battle = GameObject.Find("Battlefield").GetComponent<Battle>();
        //Screen.SetResolution(1024, 768, true);
        // Set beginning game values here
        battle.EnemyTextOn(false);
    }

    void Update()
    {
       
    }

    public void BuyItem()
    {

    }
}
