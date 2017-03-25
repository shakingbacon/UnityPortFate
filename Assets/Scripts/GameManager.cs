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
            if (!OpenClosePage("InventoryEquipment"))
            {
                InvEq.ShowStats(false);
                GameObject.FindGameObjectWithTag("InventoryEquipment").transform.FindChild("Item Desc").gameObject.SetActive(false);
                Inventory.AddItem(InvEq.holdingItem.itemID);
                InvEq.UpdateHoldingItem(new Item(), false);
            }
        }
    }

    public static bool OpenClosePage(string name)
    {
        GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.SetActive(
            !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy));
        return !(GameObject.FindGameObjectWithTag("Canvas").transform.FindChild(name).gameObject.activeInHierarchy);
    }

}
