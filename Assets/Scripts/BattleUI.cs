using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {
    public static Transform battleUI;
    public static Button run;
    public static Button skills;
    public static Slider enemyHP;
    public static Slider enemyMP;

    void Start()
    {
        battleUI = gameObject.transform;
        enemyHP = battleUI.FindChild("Enemy HP").GetComponent<Slider>();
        enemyMP = battleUI.FindChild("Enemy MP").GetComponent<Slider>();
        skills = battleUI.FindChild("Skills").GetComponent<Button>();
        run = battleUI.FindChild("Run").GetComponent<Button>();
    }

    public static void UpdateEnemySliders()
    {
        SliderUtilities.UpdateSliderFillWithText(enemyHP, EnemyHolder.enemy.stats.health, EnemyHolder.enemy.stats.maxHealth.totalAmount, "HP: ", "Enemy HP Text");
        SliderUtilities.UpdateSliderFillWithText(enemyMP, EnemyHolder.enemy.stats.mana, EnemyHolder.enemy.stats.maxMana.totalAmount, "MP: ", "Enemy MP Text");
    }
}
