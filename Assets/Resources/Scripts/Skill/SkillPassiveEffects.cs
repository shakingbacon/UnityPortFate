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

    public static void ApplyRankUpBonus(int id)
    {
        Skill skill = PlayerSkillController.Instance.GetSkill(id);
        switch (id)
        {
            case 3:
                {
                    player.Stats.BuffStat(BaseStat.StatType.MaxMana, skill.extras[0]);
                    UIEventHandler.StatsChanged();
                    break;
                }
        }
    }

    public static void ApplySkillEffect(int id)
    {
        Skill skill = PlayerSkillController.Instance.GetSkill(id);
        switch (id)
        {
            case 4:
                {
                    SoundDatabase.PlaySound(14);
                    int amount = skill.extras[0] + (int)((player.Stats.MaxHealth - player.CurrentHealth) * (skill.extras[1] / 100f));
                    player.AddHealth(amount);
                    FloatingText text = FloatingTextController.CreateFloatingText(amount.ToString(), player.transform);
                    text.SetTextColor(Color.red);
                    break;
                }
        }
    }

}
