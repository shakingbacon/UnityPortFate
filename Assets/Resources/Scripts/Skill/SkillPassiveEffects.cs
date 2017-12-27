using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPassiveEffects : MonoBehaviour
{

    public static Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void ApplyRankUpBonus(int id)
    {
        switch (id)
        {
            case 3:
                {
                    player.BuffStat(BaseStat.StatType.MaxMana, PlayerSkillController.Instance.GetSkill(id).extras[0]);
                    player.StatsUpdate();
                    break;
                }
        }
    }

}
