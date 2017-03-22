using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int draggingPageID;
    public int showingPageTooltipID = -1;
    public bool inBattle;
    public bool setupBattle;
    Battle battle;
    PlayerSkills playerSkills;

    void Start()
    {
        playerSkills = GameObject.FindGameObjectWithTag("Player Skills").GetComponent<PlayerSkills>();
        battle = GameObject.Find("Battlefield").GetComponent<Battle>();
        //Screen.SetResolution(1024, 768, true);
        // Set beginning game values here
        battle.BattleUIOn(false);
        GameObject.FindGameObjectWithTag("Skill Page").transform.FindChild("Skill Desc").gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Skill Page").SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Skill"))
        {
            //playerSkills.SkillUpdate();
            OpenCloseSkillPage();
        }
        if (Input.GetButtonDown("Inventory"))
        {
            OpenCloseInventoryPage();
        }
    }

    public static void OpenCloseSkillPage()
    {
       
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Skill Page").gameObject.SetActive(
            !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("Skill Page").gameObject.activeInHierarchy));
    }

    public static void OpenCloseInventoryPage()
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("InventoryEquipment").gameObject.SetActive(
            !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild("InventoryEquipment").gameObject.activeInHierarchy));
    }

    public void BuyItem()
    {

    }

}
