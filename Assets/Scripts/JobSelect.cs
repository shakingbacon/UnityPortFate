using UnityEngine;
using System.Collections;

public class JobSelect : MonoBehaviour {

    public static void AddBaseStats()
    {
        PlayerStats.stats.level = 1;
        PlayerStats.stats.strength.baseAmount = 3;
        PlayerStats.stats.intelligence.baseAmount = 3;
        PlayerStats.stats.agility.baseAmount = 3;
        PlayerStats.stats.luck.baseAmount = 3;
        PlayerStats.stats.critMulti.baseAmount = 225;
        PlayerStats.stats.dmgOutput.baseAmount = 100;
        PlayerStats.stats.dmgTaken.baseAmount = 100;
        PlayerStats.stats.manaComs.baseAmount = 100;
        PlayerStats.stats.cash = 100;
        PlayerStats.StatsUpdate();
        PlayerStats.stats.HealFullHP();
        PlayerStats.stats.HealFullMP();
        PlayerStats.SetMaxExp();
        InvEq.UpdateCashText();
        StatusBar.UpdateStatusBar();
    }

    public void SelectMage()
    {
        SoundDatabase.PlaySound(43);
        PlayerStats.stats.job = JobDatabase.GetJob(0);
        AddBaseStats();
        PlayerSkills.ApplyJob();
        SkillPage.currentPage = PlayerSkills.skills;
        SkillPage.UpdateSkillPage(0);
        SkillPage.UpdateSkillPoints();
        GameManager.inIntro = false;
        Tutorial.skip.gameObject.transform.parent.gameObject.SetActive(true);
        StatusBar.statusBar.gameObject.SetActive(true);
        SoundDatabase.PlayMusic(0);
        Destroy(gameObject);
    }
    public void SelectRogue()
    {
        PlayerStats.stats.job = JobDatabase.GetJob(1);
    }
    public void SelectWarrior()
    {
        PlayerStats.stats.job = JobDatabase.GetJob(2);
    }
}
