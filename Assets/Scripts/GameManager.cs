using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    static string showingPage;
    public bool inBattle;
    public bool setupBattle;
    Battle battle;

    void Start()
    {
        battle = GameObject.Find("Battlefield").GetComponent<Battle>();
        //Screen.SetResolution(1024, 768, true);
        // Set beginning game values here
        battle.BattleUIOn(false);
        //GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
        //GameObject.FindGameObjectWithTag("Skill Page").SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Skill"))
        {
            //playerSkills.SkillUpdate();
            OpenClosePage("Skill Page");
        }
        if (Input.GetButtonDown("Inventory"))
        {
            OpenClosePage("InventoryEquipment");
        }
    }

    public static void OpenClosePage(string name)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.SetActive(
            !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy));
    }

    public void BuyItem()
    {

    }

}
