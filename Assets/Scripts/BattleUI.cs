using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {
    public static GameObject playerCopy;
    public static Transform battleUI;
    public static Button run;
    public static Button skills;
    public static Slider enemyHP;
    public static Slider enemyMP;
    public static Transform playerStatus;
    public static Transform enemyStatus;
    //public static GameObject playerCopy;

    void Start()
    {
        battleUI = gameObject.transform;
        //playerCopy = battleUI.FindChild("Player Copy").gameObject;
        enemyHP = battleUI.FindChild("Enemy HP").GetComponent<Slider>();
        enemyMP = battleUI.FindChild("Enemy MP").GetComponent<Slider>();
        skills = battleUI.FindChild("Skills").GetComponent<Button>();
        run = battleUI.FindChild("Run").GetComponent<Button>();
        playerStatus = battleUI.FindChild("Player Status");
        enemyStatus = battleUI.FindChild("Enemy Status");
        GameManager.OpenClosePage("Battle UI");
    }

    public static void CopyPlayer()
    {
        if (GameManager.OpenClosePage("InventoryEquipment"))
        {
            GameManager.OpenClosePage("InventoryEquipment");
        }
        playerCopy = Instantiate(GameObject.FindGameObjectWithTag("Player Image"), battleUI);
        playerCopy.GetComponent<Image>().SetNativeSize();
        playerCopy.transform.localPosition = new Vector3(-185, 150);
        GameManager.OpenClosePage("InventoryEquipment");
    }

    public static void UpdateEnemySliders()
    {
        SliderUtilities.UpdateSliderFillWithText(enemyHP, EnemyHolder.enemy.stats.health, EnemyHolder.enemy.stats.maxHealth.totalAmount, "HP: ", "Enemy HP Text");
        SliderUtilities.UpdateSliderFillWithText(enemyMP, EnemyHolder.enemy.stats.mana, EnemyHolder.enemy.stats.maxMana.totalAmount, "MP: ", "Enemy MP Text");
    }
}
